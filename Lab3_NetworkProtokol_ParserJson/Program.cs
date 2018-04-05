using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParser;

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
                    new JSONNumber("Я ебал твою тёлку", 1488),
                    new JSONString("Я роняю запад", "УУУУУУ"),
                    new JSONArrayCollection("Это правда")
                    {
                        new JSONString(string.Empty, "Я ебал жену обамы"),
                        new JSONString(string.Empty, "Мне сосала дочка трампа"),
                        new JSONString(string.Empty, "Эшкере"),
                    }
                }
            };

            Console.WriteLine(jsonObject);

            var newObj = new JSONParser.JSONParser();

            var parseData = newObj.Parse(jsonObject.ToString());

            Console.ReadKey();
        }
    }
}
