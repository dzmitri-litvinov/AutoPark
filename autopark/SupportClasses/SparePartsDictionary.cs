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
       
        public SparePartsDictionary()
        { }

        public SparePartsDictionary(string inFile)
        {
            CreateDictionary(LoadSpareParts(inFile));
        }

        private IEnumerable<string> LoadSpareParts(string inFile)
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

        private void CreateDictionary(IEnumerable<string> spareParts)
        {
            int i;

            foreach (string part in spareParts)
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
