using CommandLine;

// ReSharper disable ClassNeverInstantiated.Global

namespace XMLNet
{
    public class Options
    {
        [Option('p', "paths", HelpText = "Extract XPaths.")]
        public bool FindPaths { get; set; }

        [Option('n', "spaces", HelpText = "Ignore XML namespaces.")]
        public bool NoPrefix { get; set; }

        [Option('r', "reverse", HelpText = "Swap key and values.")]
        public bool ReverseOut { get; set; }

        [Option('i', "input", HelpText = "Set input directory.")]
        public string InputDir { get; set; }

        [Option('o', "output", HelpText = "Set output directory.")]
        public string OutputDir { get; set; }
    }
}