using Machine.Specifications;

namespace RailFenceCypher.Specs
{
    public class When_Encoding_A_Secret_Message
    {
        Establish context = () =>
        {
            inputString = "WEAREDISCOVEREDFLEEATONCE";
            inputRails = new int[] { 3,4,7 };
            expect = new string[] { "WECRLTEERDSOEEFEAOCAIVDEN","WIREEEDSEEEACAECVDLTNROFO", "WREEEECAVDNROFOECLTDSEAIE" };
            answers = new string[expect.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < expect.Length; i++)
            {
                answers[i] = Cypher.Encode(inputString, inputRails[i]);
            }
        };

        It Should_Return_Encoded_String = () =>
        {
            for (var i = 0; i < expect.Length; i++)
            {
                answers[i].ShouldEqual(expect[i]);
            }
        };

        private static string inputString;
        private static int[] inputRails;
        private static string[] expect;
        private static string[] answers;
    }

    public class When_Decoding_A_Secret_Message
    {
        Establish context = () =>
        {
            inputStrings = new string[]
            {
                "WECRLTEERDSOEEFEAOCAIVDEN","WIREEEDSEEEACAECVDLTNROFO", "WREEEECAVDNROFOECLTDSEAIE"
            };
            inputRails = new int[] { 3, 4, 7 };
            expect = "WEAREDISCOVEREDFLEEATONCE";
            answers = new string[inputStrings.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputStrings.Length; i++)
            {
                answers[i] = Cypher.Decode(inputStrings[i], inputRails[i]);
            }
        };

        It Should_Return_A_Decoded_String = () =>
        {
            for (var i = 0; i < inputStrings.Length; i++)
            {
                answers[i].ShouldEqual(expect);
            }
        };

        private static string[] inputStrings;
        private static int[] inputRails;
        private static string expect;
        private static string[] answers;
    }

    public class When_Finding_How_Many_Valleys_There_Are
    {
        Establish context = () =>
        {
            inputStrings = new[] { "1234", "12345", "123456", "1234567", "12345678", "123456789", "1234567890" };
            rails = 3;
            expectedValleys = new[] { 1, 1, 1, 1, 2, 2, 2 };
            expectedRemainders = new[] { 0, 1, 2, 3, 0, 1, 2 };
            answer = new (int, int)[inputStrings.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputStrings.Length; i++)
            {
                answer[i] = Cypher.FindValleys(inputStrings[i], rails);
            }
        };

        It Should_Return_The_Valleys_And_The_Remainder = () =>
        {
            for (var i = 0; i < expectedValleys.Length; i++)
            {
                answer[i].ShouldEqual((expectedValleys[i], expectedRemainders[i]));
            }
        };

        private static string[] inputStrings;
        private static int rails;
        private static int[] expectedValleys;
        private static int[] expectedRemainders;
        private static (int,int)[] answer;
    }

    public class When_Building_Rails_From_An_Encoded_Message
    {
        Establish context = () =>
        {
            inputStrings = new string[] { "1243", "15243", "152463", "1524637", "15246837" };
            rails = new[] { 3, 3, 3, 3, 3 };
            expected = new List<char>[][]
            {
                new List<char>[]
                {
                    new List<char> { '1' },
                    new List<char> { '2', '4' },
                    new List<char> { '3' }
                },
                new List<char>[]
                {
                    new List<char> { '1','5' },
                    new List<char> { '2', '4' },
                    new List<char> { '3' }
                },
                new List<char>[]
                {
                    new List<char> { '1','5' },
                    new List<char> { '2', '4','6' },
                    new List<char> { '3' }
                },
                new List<char>[]
                {
                    new List<char> { '1','5' },
                    new List<char> { '2', '4','6' },
                    new List<char> { '3','7' }
                },
                new List<char>[]
                {
                    new List<char> { '1','5' },
                    new List<char> { '2', '4','6','8' },
                    new List<char> { '3','7' }
                },
            };
            answer = new List<char>[expected.Length][];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputStrings.Length; i++)
            {
                answer[i] = Cypher.BuildRails(inputStrings[i], rails[i]);
            }
        };

        It Should_Return_The_Rails_Used_To_Encode = () =>
        {
            for (var i = 0; i < expected.Length; i++)
            {
                for(var j=0; j< expected[i].Length; j++)
                {
                    answer[i][j].ShouldEqual(expected[i][j]);
                }
            };
        };

        private static string[] inputStrings;
        private static int[] rails;
        private static List<char>[][] expected;
        private static List<char>[][] answer;
    }

    public class When_Decoding_A_Message_From_The_Rails
    {
        Establish context = () =>
        {
            input = new List<char>[][]
            {
                //new List<char>[]
                //{
                //    new List<char> { '1' },
                //    new List<char> { '2', '4' },
                //    new List<char> { '3' }
                //},
                //new List<char>[]
                //{
                //    new List<char> { '1','5' },
                //    new List<char> { '2', '4' },
                //    new List<char> { '3' }
                //},
                new List<char>[]
                {
                    new List<char> { '1','5' },
                    new List<char> { '2', '4','6' },
                    new List<char> { '3' }
                },
                new List<char>[]
                {
                    new List<char> { '1','5' },
                    new List<char> { '2', '4','6' },
                    new List<char> { '3','7' }
                },
                new List<char>[]
                {
                    new List<char> { '1','5' },
                    new List<char> { '2', '4','6','8' },
                    new List<char> { '3','7' }
                },
            };
            expected = new string[] { /*"1234",*/ /*"12345",*/ "123456", "1234567", "12345678" };
            answers = new string[input.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answers[i] = Cypher.DecodeRails(input[i]);
            }
        };

        It Should_Return_A_Decoded_Message = () =>
        {
            for (var i = 0; i < input.Length; i++)
            {
                answers[i].ShouldEqual(expected[i]);
            }
        };

        private static List<char>[][] input;
        private static string[] expected;
        private static string[] answers;
    }
}