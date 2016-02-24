
using System;
using System.Collections.Generic;
using System.Reflection;
namespace GenericParser.ParserWorker
{
    public class ParseIt
    {
        #region Properties
        public static ParseIt Instance = new ParseIt();
        public string Result { get; set; }
        internal static byte[] allText { get; set; }
        #endregion

        #region Constructer
        private ParseIt()
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Byte dizi olarak alınan text dosyayı istenen tipte objeler listesi olarak parse eder
        /// </summary>
        /// <typeparam name="T">Dönüş objesi</typeparam>
        /// <param name="readText">Okunan textin bütünü</param>
        /// <param name="baslama">İlk satırın başlangıç indeksi</param>
        /// <param name="son">Son satırın bitiş indeksi</param>
        /// <param name="satirUzunlugu">Her bir satır uzunluğu</param>
        /// <returns></returns>
        public List<T> ConvertFromText<T>(byte[] readText, int baslama, int son, int satirUzunlugu)
            where T : new()
        {
            try
            {
                if (!typeof(T).GetCustomAttribute<ParserAttributes.ParserClassAttribute>(false).ParserClazz)
                {
                    Result = "Oluşturulacak objeler sınıfı ParserClassAttribute ozelliklerini içermeli";
                    return null;
                }
            }
            catch (Exception)
            {
                Result = "Oluşturulacak objeler sınıfı ParserClassAttribute ozelliklerini içermeli";
                return null;
            }
            List<T> convertedList = new List<T>();
            allText = readText;
            T tempListItem;
            int startPoint = 0;
            int lenght = 0;
            int counter = 0;
            Type propType;


            for (int i = baslama; i < son; )
            {
                counter++;
                tempListItem = new T();
                string tempStr = "";
                foreach (PropertyInfo PropertyItem in typeof(T).GetProperties())
                {
                    ParserAttributes.ParserFieldProperties PropertyAttributeInfo = PropertyItem.GetCustomAttribute<ParserAttributes.ParserFieldProperties>(false);

                    if (PropertyAttributeInfo == null)
                    {
                        continue;
                    }

                    startPoint = PropertyAttributeInfo.BaslangicIndex;
                    lenght = PropertyAttributeInfo.Uzunluk;
                    propType = PropertyItem.PropertyType;

                    tempStr = GetString(i + startPoint, lenght);

                    if (propType == typeof(int) || propType == typeof(double) || propType == typeof(long))
                    {
                        if (tempStr.Contains(PropertyAttributeInfo.OndalikAyiraci) && string.IsNullOrEmpty(tempStr.Split(new char[] { PropertyAttributeInfo.OndalikAyiraci[0] })[0].Trim()))
                        {
                            tempStr = (propType == typeof(double) ? "0," : "") + tempStr.Split(new char[] { PropertyAttributeInfo.OndalikAyiraci[0] })[1].Trim();
                        }
                    }

                    tempListItem.GetType().GetProperty(PropertyItem.Name).SetValue(tempListItem, Convert.ChangeType(tempStr, propType));
                }

                i = baslama + (counter * satirUzunlugu);

                convertedList.Add(tempListItem);
            }

            return convertedList;
        }
        #endregion

        #region Private Methods
        private string GetString(int firstIndex, int lenght)
        {
            string str = "";

            do
            {
                str += Convert.ToChar(allText[firstIndex]);
                firstIndex++;
                lenght--;
            } while (lenght > -1);

            return str;
        }
        #endregion

    }
}
