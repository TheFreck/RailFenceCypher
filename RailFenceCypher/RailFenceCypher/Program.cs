using RailFenceCypher;
using System.Diagnostics;

var keepGoing = true;

do
{
    Console.WriteLine("Would you like to");
    Console.WriteLine("1. Encode");
    Console.WriteLine("2. Decode");
    var choice = Console.ReadLine();

    if(int.TryParse(choice, out var selection))
    {
        var stopwatch = new Stopwatch();
        switch (selection)
        {
            case 1:
                Console.WriteLine("Enter a message to encode");
                var toEncode = Console.ReadLine();
                if (toEncode == "") keepGoing = false;
                Console.WriteLine("How many rails?");
                var encodingRailsStr = Console.ReadLine();
                if (encodingRailsStr == "") keepGoing = false;
                if (int.TryParse(encodingRailsStr, out var encodingRails))
                {
                    stopwatch.Start();
                    var encoded = Cypher.Encode(toEncode, encodingRails);
                    stopwatch.Stop();
                    Console.WriteLine($"It took {stopwatch.ElapsedTicks} ticks to encode the message into: {encoded}");
                }
                break;
            case 2:
                Console.WriteLine("Enter a message to decode");
                var toDecode = Console.ReadLine();
                if (toDecode == "") keepGoing = false;
                Console.WriteLine("How many rails?");
                var decodingRailssStr = Console.ReadLine();
                if (decodingRailssStr == "") keepGoing = false;
                if (int.TryParse(decodingRailssStr, out var decodingRails))
                {
                    stopwatch.Start();
                    var decoded = Cypher.Decode(toDecode, decodingRails);
                    stopwatch.Stop();
                    Console.WriteLine($"It took {stopwatch.ElapsedTicks} ticks to decode the message into: {decoded}");
                }
                break;
        }
    }
} while (true);