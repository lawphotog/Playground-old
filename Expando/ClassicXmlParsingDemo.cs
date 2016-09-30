using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace Samples
{
    public class ClassicXmlParsingDemo
    {
        public static void Run()
        {
            var file = @"..\..\sample.xml";
            var persons = GetPersonsFromXml(file);
            foreach(var p in persons)
                Console.WriteLine(p.GetFullName());
        }

        public static IList<Person> GetPersonsFromXml(String file)
        {
            var persons = new List<Person>();

            var doc = XDocument.Load(file);
            var nodes = from node in doc.Root.Descendants("Person")
                        select node;
            foreach (var n in nodes)
            {
                var person = new Person();
                foreach (var child in n.Descendants())
                {
                    if (child.Name == "FirstName")
                        person.FirstName = child.Value.Trim();
                    else
                        if (child.Name == "LastName")
                            person.LastName = child.Value.Trim();
                }
                persons.Add(person);
            }

            return persons;
        }
    }
}
