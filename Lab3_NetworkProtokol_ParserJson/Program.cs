using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParser;
using System.IO;
using System.Web;
using System.Net;

namespace Lab3_NetworkProtokol_ParserJson
{
    class Program
    {
        static void Main(string[] args)
        {


            /*int[] data = { 5, 5, 34, 1488 };

            JSONObjectCollection jsonObject = new JSONObjectCollection()
            {
                new JSONNumber("hui", 228),
                new JSONString("name1", "dataTest"),
                new JSONObjectCollection("zalupa")
                {
                    new JSONNumber("Я ебал твою тёлку", 1488.765),
                    new JSONString("Я роняю запад", "УУУУУУ"),
                    new JSONBool("Делаю, что я хочу", "null"),
                    new JSONArrayCollection("Это правда")
                    {
                        new JSONString(string.Empty, "Я ебал жену обамы"),
                        new JSONString(string.Empty, "Мне сосала дочка трампа"),
                        new JSONString(string.Empty, "Эшкере"),
                    }
                }
            };

            Console.WriteLine(jsonObject);

            //Достанем 1488 для проверки
            var newObj = new JSONParser.JSONParser();

            var parseData = newObj.Parse(jsonObject.ToString()) as JSONObjectCollection;

            var parseZalupa = parseData["zalupa"] as JSONObjectCollection;

            var parseNumber = (parseZalupa["Я ебал твою тёлку"] as JSONNumber).Value;

            Console.WriteLine(parseNumber);*/

            var str = Console.ReadLine();

            var data = CompleteWordAsync(str, "pdct.1.1.20160505T081345Z.82e9fdb4e0a146c8.7e1a4b712956dd479017072f13b09624744a9687", "ru", 6).Result;

            Console.WriteLine();
            foreach (var a in data)
                Console.WriteLine(a);

            Console.ReadKey();
        }

        static async Task<string[]> CompleteWordAsync(string input, string predictorKey, string lang, int limit=1)
        {
            input = WebUtility.HtmlEncode(input);

            var parser = new JSONParser.JSONParser();

            var requestString =
                $"https://predictor.yandex.net/api/v1/predict.json/complete?key={predictorKey}&q={input}&lang={lang}&limit={limit}";

            var request = WebRequest.Create(requestString);
            request.Credentials = CredentialCache.DefaultCredentials;

            var respose = await request.GetResponseAsync();

            var reader = new StreamReader(respose.GetResponseStream());

            var poolString = await reader.ReadToEndAsync();

            var responseJson = parser.Parse(poolString);

            var textArray = ((JSONObjectCollection)responseJson)["text"] as JSONArrayCollection;

            return ToStringArray(textArray);
        }

        static string[] ToStringArray(JSONArrayCollection arrayCollection)
        {
            var pool = new string[arrayCollection.Count];

            for (int i = 0; i < arrayCollection.Count; i++)
            {
                pool[i] = arrayCollection[i].GetValue() as string;
            }

            return pool;
        }
    }


}
