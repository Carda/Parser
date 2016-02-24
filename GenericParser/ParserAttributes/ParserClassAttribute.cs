using System;

namespace GenericParser.ParserAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ParserClassAttribute : Attribute
    {
        /// <summary>
        /// Parser Sınıfı olup olmadığı belirtir.
        /// </summary>
        public bool ParserClazz { get; set; }
        /// <summary>
        /// Text Dosyası içerisindeki paterni belirler
        /// </summary>
        public ParserPatternType PatternType { get; set; }
        public int RichPatternLenght { get; set; }
        public int WastePatternLenght { get; set; }
        
        public ParserClassAttribute()
        {

        }
    }

    public enum ParserPatternType
    {
        FixedPattern,
        MixedPattern
    }
}
