using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace autopark
{
    public class SparePartsDictionary
    {
        public Dictionary<string, int> SparePartsDict { get; set; } = new();
        public string[] SparePartsNames { get; set; }

        public SparePartsDictionary()
        { }

        public SparePartsDictionary(string inFile)
        {
            SparePartsNames = LoadSpareParts(inFile).ToArray();
            CreateDictionary();
        }

        public IEnumerable<string> LoadSpareParts(string inFile)
        {
            if (File.Exists(inFile))
            {
                string[] lines = File.ReadAllLines(inFile);
                foreach (string str in lines)
                {
                    foreach (string part in str.Split(','))
                    {
                        yield return part;
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist...");
            }
        }

        public void CreateDictionary()
        {
            int i;

            foreach (string part in SparePartsNames)
            {
                if (SparePartsDict.TryGetValue(part, out i))
                {
                    SparePartsDict.Remove(part);
                    SparePartsDict.Add(part, i + 1);
                }
                else
                {
                    SparePartsDict.Add(part, 1);
                }
            }
        }

        public void PrintDictionary()
        {
            foreach (var v in SparePartsDict)
            {
                Console.WriteLine("{0, 15} - {1}", v.Key, v.Value);
            }
        }
    }
}
