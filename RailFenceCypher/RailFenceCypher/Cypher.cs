using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFenceCypher
{
    public class Cypher
    {

        public static string Decode(string inputString, int inputRails)
        {
            return DecodeRails(BuildRails(inputString, inputRails));
        }

        public static string Encode(string inputString, int inputRails)
        {
            var direction = false;
            var rails = new string[inputRails];

            for(int i = 0; i<inputString.Length; i++)
            {
                var rail = i % (inputRails - 1);
                if (rails[rail] == null) rails[rail] = String.Empty;
                if (rail == 0) direction = !direction;
                if (direction) rails[rail] += inputString[i];
                else rails[inputRails-rail-1] += inputString[i];
            }

            return String.Join("", rails);
        }

        public static List<char>[] BuildRails(string encoded, int rails)
        {
            var (valleys, remainder) = (encoded.Length / (2 * rails - 2), encoded.Length % (2 * rails - 2));
            var railsArray = new List<char>[rails];
            // top rail
            var topLineLength = valleys + (remainder > 0 ? 1 : 0);
            railsArray[0] = encoded.ToCharArray().Take(topLineLength).ToList();
            encoded = encoded.Substring(topLineLength);
            // middle rails
            for(var i=1; i<rails-1; i++)
            {
                var extras = (remainder > 2 * (rails - i) ? 2 : remainder > i ? 1 : 0);
                var lineLength = 2 * valleys + extras;
                railsArray[i] = encoded.ToCharArray().Take(lineLength).ToList();
                encoded = encoded.Substring(lineLength);
            }
            // bottom rail
            railsArray[rails - 1] = encoded.ToList<char>();

            return railsArray;
        }

        public static string DecodeRails(List<char>[] rails)
        {
            var direction = false;
            var message = String.Empty;
            var rail = 0;

            for (int i = 0; i <= rails.Length; i++)
            {
                if (i%(rails.Length-1) == 0)
                {
                    direction = !direction;
                    if(rails.Select(r => r.Any()).Any())
                    {
                        i = 0;
                    }
                }
                if (!rails.Where(r => r.Count > 0).Any()) 
                    return message;
                message += rails[rail][0];
                rails[rail].RemoveAt(0);
                if (direction) rail++;
                else rail--;
            }

            return message;
        }

        public static (int, int) FindValleys(string message, int rails) =>
            (message.Length / (2 * rails - 2), message.Length % (2 * rails - 2));

    }
}
