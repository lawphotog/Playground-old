using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    public static class ExpandoXml
    {
        public static dynamic AsExpando(this XDocument document)
        {
            return CreateExpando(document.Root);
        }

        private static dynamic CreateExpando(XElement element)
        {
            var result = new System.Dynamic.ExpandoObject() as IDictionary<string, object>;
            if(element.Elements().Any(e => e.HasElements))
            {
                var list = new List<System.Dynamic.ExpandoObject>();
                result.Add(element.Name.ToString(), list);
                foreach(var childElement in element.Elements())
                {
                    list.Add(CreateExpando(childElement));
                }
            }
            else
            {
                foreach(var leafElement in element.Elements())
                {
                    result.Add(leafElement.Name.ToString(), leafElement.Value);
                }
            }

            return result;
        }

    }
}
