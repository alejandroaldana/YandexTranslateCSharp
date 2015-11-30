using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YandexTranslateCSharp.Models;

namespace YandexTranslateCSharp
{
    public class YandexTranslator
    {
        public string Text
        { 
            get
            {
                return text;
            }
            set
            {
                text = value;
            }    
        }
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
            }
        }

        private string text { get; set; }
        private string apiKey { get; set; }

	#region Constructors
        /// <summary>
        /// Initalize Yandex Transaltor with your own API Key
        /// </summary>
        /// <param name="apiKey">Api key from Yandex. You could get your key in https://tech.yandex.com/keys/get/?service=trnsl if you don't have it yet.</param>
        public YandexTranslator(string apiKey)
        {
            this.apiKey = apiKey;
        }
	#endregion

       

        #region Public Classes
	     /// <summary>
        /// Get languages availiable in Yandex Translator
        /// </summary>
        /// <param name="ui">//O: Terminar de</param>
        public async Task<List<string>> GetLanguagesAvailable(string ui)
        {
            List<string> returnResult = new List<string>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://translate.yandex.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/v1.5/tr.json/getLangs?key=" + ApiKey + "&ui=" + ui);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var jsonString = await response.Content.ReadAsStringAsync();
                YanderResultForLang result = await JsonConvert.DeserializeObjectAsync<YanderResultForLang>(jsonString);


                foreach (var item in result.dirs)
                {
                    returnResult.Add(item);
                }


            }
            return returnResult;
        }
	

	     /// <summary>
        /// Initalize Yandex Transaltor with your own API Key
        /// </summary>
        /// <param name="apiKey">Api key from Yandex. You could get your key in https://tech.yandex.com/keys/get/?service=trnsl if you don't have it yet.</param>
        public async Task<string> DetectLanguage(string text)
        {
            string baseAdress = "https://translate.yandex.net";
            string urlParameter = "api/v1.5/tr.json/detect?key=" + apiKey + "&text=" + text;
            string jsonString = await GenerateJsonCall(baseAdress, urlParameter);
            DetectLangResult result = await JsonConvert.DeserializeObjectAsync<DetectLangResult>(jsonString);
            //TODO: Allow multiple text
            return result.lang;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<string[]> Translate(string lang, string[] text)
        {
            string baseAdress = "https://translate.yandex.net";
            string urlParameter = "api/v1.5/tr.json/translate?key=" + ApiKey + "&lang=" + lang;
            foreach (var item in text)
            {
                urlParameter += "&text=" + item;
            }
            string jsonString = await GenerateJsonCall(baseAdress, urlParameter);
            Translated result = await JsonConvert.DeserializeObjectAsync<Translated>(jsonString);
            //TODO: Allow multiple text
            return result.text;
        }
        #endregion

 	#region Private Classes
        private async Task<string> GenerateJsonCall(string baseAdrress, string urlParameters)
        {
            string jsonString;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAdrress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                HttpResponseMessage response = await client.GetAsync(urlParameters);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                jsonString = await response.Content.ReadAsStringAsync();


            }
            return jsonString;
        }
        #endregion 
    }
}
