using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParser;
using System.IO;

namespace Lab3_NetworkProtokol_ParserJson
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 5, 5, 34, 1488 };

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

            Console.WriteLine(parseNumber);

            Console.ReadKey();
        }
    }
}
