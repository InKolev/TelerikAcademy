namespace Words_Count
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Startup
    {
        static void Main(string[] args)
        {
            var text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";
            var separator = new char[6] { ' ', '.', ',', '!', '?', '-' };

            var pattern = "^[a-zA-Z]+$";
            var regex = new Regex(pattern);

            var result = text
                .Split(separator)
                .Where(x => regex.IsMatch(x))
                .GroupBy(x => x.ToLowerInvariant())
                .ToDictionary(x => x.Key, v => v.Count());

            foreach (var word in result)
            {
                Console.WriteLine("Word: {0} --> {1}", word.Key, word.Value);
            }
        }
    }
}