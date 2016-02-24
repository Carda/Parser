using GenericParser.ParserAttributes;

namespace Tester
{
    [ParserClass(ParserClazz = true)]
    class TranObj
    {
        [ParserFieldProperties(BaslangicIndex = 12, Uzunluk = 8)]
        public string CicsName { get; set; }
        [ParserFieldProperties(BaslangicIndex = 21, Uzunluk = 4)]
        public string TranId { get; set; }
        [ParserFieldProperties(BaslangicIndex = 58, Uzunluk = 5, OndalikAyiraci = ".")]
        public double AverageResponseTime { get; set; }

    }
}
