using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using YandexTranslateCSharp;
namespace YandexTranslateCSharpTest
{
    [TestClass]
    public class YandexTranslaterTest
    {
        [TestMethod]
        public async Task TranslateToSpanish1()
        {
            YandexTranslator yander = new YandexTranslator("trnsl.1.1.20151008T075609Z.cabe07325f92d1c8.271f3e806a14160b082c31d36788cd03138f8498");
            string[] textToTranslate = { "Hello World", "This is a test" };
            string traducido = await yander.Translate("es", textToTranslate);

            Assert.AreEqual("Hola Mundo", traducido);
        }

        [TestMethod]
        public async Task DeteccionDeIdioma1()
        {
            YandexTranslator yander = new YandexTranslator("trnsl.1.1.20151008T075609Z.cabe07325f92d1c8.271f3e806a14160b082c31d36788cd03138f8498");
            string deteccion = await yander.DetectLanguage("Summer Dresses");

            Assert.AreEqual("en", deteccion);
        }
    }
}
