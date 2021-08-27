using System;
using System.IO;
using System.Linq;

namespace new_empty_file
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = ParseNumberArgument(args, "--size", "-s");
            var count = ParseNumberArgument(args, "--count", "-c");
            var name = args.First();

            if (count == 1 || count == 0) 
                File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, name), new byte[size]);
            else
                for (int i = 0; i < count; i++)
                {
                    var filepath = Path.Combine(Environment.CurrentDirectory, $"{name}-{(i + 1).ToString().PadLeft(count.ToString().Length, '0')}");
                    File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, name), new byte[size]);
                }
        }

        static int ParseNumberArgument(string[] args, string argument, string abreviation)
        {
            if (args.Contains(argument) || args.Contains(abreviation))
            {
                var longIndex = Array.FindIndex(args, x => x == argument);
                var shortIndex = Array.FindIndex(args, x => x == abreviation);
                if (!(Math.Max(longIndex, shortIndex) == args.Length))
                { // Next index of size argument is in bounds?
                    string sizeArgument = string.Empty;
                    if (longIndex != -1)
                        sizeArgument = args[longIndex + 1];
                    if (shortIndex != -1)
                        sizeArgument = args[longIndex + 1];

                    if (int.TryParse(sizeArgument, out var size))
                        return size;
                }
            }

            return 0;
        }
    }
}
