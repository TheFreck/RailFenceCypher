namespace RailFenceCypher
{
    public class Cypher
    {
        public static string Encode(string inputString, int inputRails)
        {
            var direction = false;
            var rails = new string[inputRails];
            for (int i = 0; i < inputString.Length; i++)
            {
                var rail = i % (inputRails - 1);
                if (rails[rail] == null) rails[rail] = String.Empty;
                if (rail == 0) direction = !direction;
                if (direction) rails[rail] += inputString[i];
                else rails[inputRails - rail - 1] += inputString[i];
            }

            return String.Join("", rails);
        }

        public static string Decode(string inputString, int inputRails)
        {
            if (inputRails < 2) return inputString;
            return DecodeRails(BuildRails(inputString, inputRails));
        }

        public static string[] BuildRails(string encoded, int rails)
        {
            var railsArray = new string[rails];
            var (valleys, remainder) = (encoded.Length / (2 * rails - 2), encoded.Length % (2 * rails - 2));
            var line1Len = remainder > 0 ? valleys + 1 : valleys;
            railsArray[0] = string.Join("", encoded.Take(line1Len));
            encoded = encoded.Substring(line1Len);

            for (int i = 1; i < rails - 1; i++)
            {
                var lineLen = 2 * valleys;
                if (remainder > i) lineLen++;
                if (remainder > rails && remainder + 1 >= 2 * rails - i) lineLen++;
                railsArray[i] = string.Join("", encoded.Take(lineLen));
                encoded = encoded.Substring(lineLen);
            }

            railsArray[rails - 1] = encoded;
            return railsArray;
        }

        public static string DecodeRails(string[] rails)
        {
            var direction = false;
            var message = String.Empty;
            var rail = 0;

            for (int i = 0; i <= rails.Length; i++)
            {
                if (i % (rails.Length - 1) == 0)
                {
                    direction = !direction;
                    if (rails.Select(r => r.Any()).Any()) i = 0;
                }
                if (!rails.Where(r => r.Length > 0).Any()) break;
                if (rails[rail].Length > 0)
                {
                    message += rails[rail][0].ToString();
                    rails[rail] = rails[rail].Substring(1);
                }
                if (direction) rail++;
                else rail--;
            }

            return message;
        }

        public static (int, int) FindValleys(string message, int rails) =>
            (message.Length / (2 * rails - 2), message.Length % (2 * rails - 2));

    }
}
