using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ReadingKeysJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> keyValueMap = new Dictionary<string, string>();
            
            using (StreamReader reader = File.OpenText(@"C:\Users\Kevin\data.txt")) 
            {
                var fileContent = reader.ReadToEnd();

                var data = (JObject)JsonConvert.DeserializeObject(fileContent);
                string _rates = JsonConvert.SerializeObject(data["rates"]);

                JObject converted = JsonConvert.DeserializeObject<JObject>(_rates);

                if (converted != null)
                {
                    foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                    {
                        keyValueMap.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                        Console.WriteLine(keyValuePair.Key);
                    }
                }
            }            
        }

    }
}
