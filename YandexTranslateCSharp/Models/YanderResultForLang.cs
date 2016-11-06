using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//NAMESPACE
//
namespace YandexTranslateCSharp.Models
{
    public class YanderResultForLang
    {
        public string[] dirs { get; set; }
        public Langs langs { get; set; }
    }


	

    public class Langs
    {
        public string ru { get; set; }
        public string en { get; set; }
        public string pl { get; set; }
        public string uk { get; set; }
        public string de { get; set; }
        public string fr { get; set; }
        public string es { get; set; }
        public string it { get; set; }
        public string bg { get; set; }
        public string cs { get; set; }
        public string tr { get; set; }
        public string ro { get; set; }
        public string sr { get; set; }


    }
}
