using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;

namespace PSNProfilesTrophyScraper
{
    public class Program
    {
        private static string TableXPath = "//*[@id=\"content\"]/div[2]/div[1]/div[4]/table";
        private static string ResultsXPath = "//*[@id=\"search-results\"]/div/div/table";

        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //    var client = new HttpClient();
        //    //var response = client.GetAsync("https://psnprofiles.com/trophies/7523-god-of-war?order=grade").Result;
        //    //var response = client.GetAsync("https://psnprofiles.com/search/games?q=infamous").Result;
        //    //var html = response.Content.ReadAsStringAsync().Result;
        //    //var html = File.ReadAllText("PSNProfilesGodOfWar.html");
        //    var html = File.ReadAllText("PSNProfilesInfamousSearch.html");
        //    var htmlDocument = new HtmlDocument();
        //    htmlDocument.LoadHtml(html);
        //    var table = htmlDocument.DocumentNode.SelectSingleNode(ResultsXPath);
        //    //var rows = table.Descendants("tr");
        //    //foreach (var row in rows)
        //    //{
        //    //    var titleAndCriteria = row.Descendants("td").ElementAt(1);
        //    //    var title = titleAndCriteria.Descendants("a").Single().InnerText.Trim();
        //    //    var criteria = titleAndCriteria.InnerText.Trim().Replace(title, string.Empty);
        //    //    var metal = row.Descendants("td").ElementAt(5).Descendants("img").Single().GetAttributeValue("title", null).Trim();
        //    //    Console.WriteLine($"{title} | {criteria} | {metal}");
        //    //}
        //    var menu = new Menu();
        //    var rows = table.Descendants("tr");
        //    foreach (var row in rows)
        //    {
        //        var title = row.Descendants("a").First(n => n.HasClass("title")).InnerText;
        //        menu.Selected.Add(new Menu.Item(title, () => Console.Write("Hello!")));
        //        //Console.WriteLine(title);
        //    }

        //    menu.Begin();
        //}

        public static void Main(string[] args)
        {
            BuildMyMenu();
        }

        public static void BuildMyMenu()
        {
            void writeMenu(int left, int top, int selected)
            {
                Console.SetCursorPosition(left, top);
                for (var i = 0; i < 3; i++)
                {
                    if (selected == i)
                    {
                        Console.WriteLine($"\t> Option {i + 1}");
                    }
                    else
                    {
                        Console.WriteLine($"\t  Option {i + 1}");
                    }
                }
                Console.CursorVisible = false;
            };


            Console.WriteLine("My Menu:");
            var optionsLeft = Console.CursorLeft;
            var optionsTop = Console.CursorTop;

            writeMenu(optionsLeft, optionsTop, 0);

            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        writeMenu(optionsLeft, optionsTop, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        writeMenu(optionsLeft, optionsTop, 1);
                        break;
                }
            }
        }
    }
}
