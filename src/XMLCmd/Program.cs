using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace XMLCmd
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var xmlFile = "Resources/sample.xml";

            var doc = new XmlDocument();
            doc.Load(xmlFile);

            var xpaths = new List<XPathed>();
            GenerateXPaths(doc.DocumentElement, "", xpaths);

            foreach (var xpath in xpaths)
            {
                Console.WriteLine(xpath);
            }
        }

        private static void GenerateXPaths(XmlNode node, string currentPath, List<XPathed> xpaths)
        {
            var name = node.Name;
            if (node is XmlAttribute) name = $"@{name}";
            var path = $"{currentPath}/{name}";

            var attrs = node.Attributes?.Cast<XmlNode>() ?? [];
            var children = node.ChildNodes.Cast<XmlNode>();
            foreach (var child in attrs.Concat(children))
            {
                switch (child.NodeType)
                {
                    case XmlNodeType.Element:
                        GenerateXPaths(child, path, xpaths);
                        continue;
                    case XmlNodeType.Attribute:
                        GenerateXPaths(child, path, xpaths);
                        continue;
                    case XmlNodeType.Text:
                        var text = child.Value;
                        xpaths.Add(new XPathed(path, text));
                        continue;
                }
            }
        }
    }
}