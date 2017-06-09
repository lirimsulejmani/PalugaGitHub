using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace ServiceLayer.APIs.Goodreads.CSV
{
    public static class CsvProcessor
    {
        private static string _Path = System.IO.Directory.GetCurrentDirectory() + @"\Infrastructure\CSV\language-codes-full.csv";
        public static List<Language> ListLanguages()
        {

            using (TextReader reader = File.OpenText(_Path))
            {

                var csv = new CsvReader(reader);

                var records = csv.GetRecords<Language>().ToList();

                return records;
            }

        }

        public static string GetLanguageName(string code)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            using (TextReader reader = File.OpenText(_Path))
            {

                var csv = new CsvReader(reader);

                var records = csv.GetRecords<Language>().ToList();
                var language = records.Find(t => t.AlphaT == code || t.AlphaB == code || t.Alpha2 == code);

                return language != null ? language.EnglishName : "Unknown";;
            }

        }
    }

    public class Language
    {
        public string AlphaB { get; set; }
        public string AlphaT { get; set; }
        public string Alpha2 { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }
    }
}
