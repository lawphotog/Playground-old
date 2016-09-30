using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Dynamic;


namespace Samples
{
    public class ExpandoXmlParsingDemo
    {
        public static void Run()
        {
            var file = @"..\..\sample.xml";
            dynamic settings = GetExpandoSettings(file);
            dynamic persons = GetExpandoFromXml(file);

            foreach (var p in persons)
            {
                var memberNames = (settings.Parameters as String).Split(',');
                var realValues = GetValuesFromExpandoObject(p, memberNames);
                Console.WriteLine(settings.Format, realValues);
            }
        }

        public static IList<dynamic> GetExpandoFromXml(String file)
        {
            var persons = new List<dynamic>();

            var doc = XDocument.Load(file);
            var nodes = from node in doc.Root.Descendants("Person")
                        select node;
            foreach (var n in nodes)
            {
                dynamic person = new ExpandoObject();
                foreach (var child in n.Descendants())
                {
                    (person as IDictionary<String, object>)[child.Name.ToString()] = child.Value.Trim();
                }  
                persons.Add(person);
            }

            return persons;
        }

        public static Object[] GetValuesFromExpandoObject(IDictionary<String, Object> person, String[] memberNames)
        {
            var realValues = new List<Object>();
            foreach (var m in memberNames)
            {
                realValues.Add(person[m]);
            }
            return realValues.ToArray();
        }

        public static dynamic GetExpandoSettings(String file)
        {
            var doc = XDocument.Load(file);
            var node = (from n in doc.Root.Descendants("Output")
                         select n).FirstOrDefault();

            dynamic settings = new ExpandoObject();
            settings.Format = node.Attribute("Format").Value;
            settings.Parameters = node.Attribute("Params").Value.Replace(" ", "");
            return settings;
        }
    }
}
