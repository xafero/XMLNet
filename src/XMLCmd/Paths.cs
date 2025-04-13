using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace XMLNet
{
    public static class Paths
    {
        public static void Extract(Options options)
        {
            var inputDir = Path.GetFullPath(options.InputDir);
            var ignoreNsp = options.NoPrefix;

            var o = SearchOption.AllDirectories;
            var files = Directory.EnumerateFiles(inputDir, "*.xml", o);
            foreach (var file in files)
            {
                ExtractXPath(file, ignoreNsp);
            }
        }

        private static void ExtractXPath(string xmlFile, bool ignoreNsp)
        {
            var doc = new XmlDocument();
            doc.Load(xmlFile);

            var xpaths = new List<XPathed>();
            GenerateXPaths(doc.DocumentElement, "", xpaths, ignoreNsp);

            foreach (var xpath in xpaths)
            {
                Console.WriteLine(xpath);
            }
        }

        private static void GenerateXPaths(XmlNode node, string currentPath,
            List<XPathed> xpaths, bool ignoreNsp)
        {
            var name = node.Name;
            if (ignoreNsp) name = node.LocalName;
            if (node is XmlAttribute) name = $"@{name}";
            var path = $"{currentPath}/{name}";

            var attrs = node.Attributes?.Cast<XmlNode>() ?? [];
            var children = node.ChildNodes.Cast<XmlNode>();
            foreach (var child in attrs.Concat(children))
            {
                switch (child.NodeType)
                {
                    case XmlNodeType.Element:
                        GenerateXPaths(child, path, xpaths, ignoreNsp);
                        continue;
                    case XmlNodeType.Attribute:
                        GenerateXPaths(child, path, xpaths, ignoreNsp);
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