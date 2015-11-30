using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTranslateCSharp.Models
{
    public class Translated
    {
        public int code { get; set; }
        public string lang { get; set; }
        public string[] text { get; set; }
    }
}
