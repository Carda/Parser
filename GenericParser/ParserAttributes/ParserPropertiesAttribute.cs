using System;

namespace GenericParser.ParserAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ParserFieldProperties : Attribute
    {
        /// <summary>
        /// Field Bilgisi 
        /// </summary>
        public string Info { get; private set; }
        /// <summary>
        /// Field Başlangıç Noktası
        /// </summary>
        public int BaslangicIndex { get; set; }
        /// <summary>
        /// Field Uzunluğu
        /// </summary>
        public int Uzunluk { get; set; }
        /// <summary>
        /// Numeric tipler için ondalık ayıraç
        /// </summary>
        public string OndalikAyiraci { get; set; }

        public ParserFieldProperties()
        {

        }

        /// <summary>
        /// Özellik ile ilgili bilgi girilmek istenirse kullanılır.
        /// </summary>
        /// <param name="userDefinedInfo">Bilgi alanı</param>
        public ParserFieldProperties(string userDefinedInfo)
        {
            Info = userDefinedInfo;
        }
    }
}
