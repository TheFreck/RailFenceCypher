using Machine.Specifications;
using System.Threading;

namespace RailFenceCypher.Specs
{
    public class When_Encoding_A_Secret_Message
    {
        Establish context = () =>
        {
            //inputStrings = new string[] { "WEAREDISCOVEREDFLEEATONCE","WEAREDISCOVEREDFLEEATONCE","WEAREDISCOVEREDFLEEATONCE","WEAREDISCOVEREDFLEEATONCE",
            //    "distinctio Deserunt minima iure provident, veritatis Porro fugiat alias sit! excepturi exercitationem non autem iure ipsa iure quibusdam Amet officiis asperiores unde, maiores!jk unde! facere molestiae. Voluptate ipsam quasi eveniet",
            //    "Deserunt quasi ipsa distinctio Voluptate fugiat sit! exercitationem autem provident, non eveniet unde! iure iure minima alias Porro iure quibusdam officiis veritatis asperiores molestiae. Amet unde, facere maiores!jk ipsam excepturi",
            //    "veritatis exercitationem iure quasi ipsa provident, unde! molestiae. iure eveniet autem Deserunt Porro Voluptate sit! alias maiores!jk iure asperiores ipsam non minima excepturi quibusdam unde, facere Amet officiis distinctio fugiat"
            //};
            //inputRails = new int[] { 3,4,7,6, 39,3,30};
            //expect = new string[] { "WECRLTEERDSOEEFEAOCAIVDEN","WIREEEDSEEEACAECVDLTNROFO", "WREEEECAVDNROFOECLTDSEAIE", "WVTEOEAOACRENRSEECEIDLEDF",
            //    "d sni!eapeistx eveticsretiseii n pioicstcrstauieaiirfsuolif q a ou D e nmetxtdasaeeeseirm,prgcA iuui m nftmaet aait otdoamrisrtirouepnonbsuiPei!lm mujoas qkV in   itoeu.uanrnert udaeiaiei ru !tpeta srvesfeo mpalv, icoiti emdnuer ere" ,
            //    "vm!ue ot trtr!liapiaieesle itds icqganteaxuutuitseifi aa  b s,etmauo t.pamsien uiidtxeilonaceduorimnrirVem icve s utio o!nnstrerjodiapvrknedt eo  , ianPim sosi uafinpetrsaieitnepccm  u iei iara rfisuessefuatspe orueeerA eqmDromt  ie"
            //};
            inputStrings = new string[] {
                "WEAREDISCOVEREDFLEEATONCE",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ abcdefghijklmnopqrstuvwxyz",
            };
            inputRails = new int[] { 5, 5, 9, 25, 19, 20, 40, 50, 10 };
            expect = new string[] {
                "WCLEESOFECAIVDENRDEEAOERT",
                "19GOWdlt28 FHNPVXcekmsu37AEIMQUYbfjnrvz46BDJLRTZagioqwy5CKS hpx",
                "1GWl2FHVXkm3EIUYjnz4DJTZioy5CKS hpx6BLRagqw7AMQbfrv8 NPcesu9Odt",
                "1l2km3jn4io5hp6gq7fr8es9dt cuAbvBawC xDZyEYzFXGWHVIUJTKSLRMQNPO",
                "1 2Za3Yb4Xc5Wd6Ve7Uf8Tg9Sh RiAQjzBPkyCOlxDNmwEMnvFLouGKptHJqsIr",
                "1b2ac3 d4Ze5Yf6Xg7Wh8Vi9Uj TkASlBRmCQnDPoEOpzFNqyGMrxHLswIKtvJu",
                "123456789 ABCDEFGzHyIxJwKvLuMtNsOrPqQpRoSnTmUlVkWjXiYhZg faebdc",
                "123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ zaybxcwdveuftgshriqjpkolnm",
                "1I r2HJZaqs3GKYbpt4FLXcou5EMWdnv6DNVemw7COUflx8BPTgky9AQShjz Ri"
            };
            answers = new string[expect.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < expect.Length; i++)
            {
                answers[i] = Cypher.Encode(inputStrings[i], inputRails[i]);
            }
        };

        It Should_Return_Encoded_String = () =>
        {
            for (var i = 0; i < expect.Length; i++)
            {
                answers[i].ShouldEqual(expect[i]);
            }
        };

        private static string[] inputStrings;
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
               "ACEGIKMOQSUWYBDFHJLNPRTVXZ",
               "AEIMQUYBDFHJLNPRTVXZCGKOSW",
               "AGMSYBFHLNRTXZCEIKOQUWDJPV",
               "AIQYBHJPRXZCGKOSWDFLNTVEMU",
               "AKUBJLTVCIMSWDHNRXEGOQYFPZ",
               "AMYBLNXZCKOWDJPVEIQUFHRTGS",
               "AOBNPCMQDLRZEKSYFJTXGIUWHV",
               "AQBPRCOSDNTEMUFLVGKWHJXZIY",
               "ASBRTCQUDPVEOWFNXGMYHLZIKJ"
            };
            inputRails = new int[] 
            {
                2,3,4,5,6,7,8,9,10
            };
            expect = new string[] 
            { 
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            };
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
                if (answers[i] != expect[i])
                {
                    var ans = answers[i];
                    var exp = expect[i];
                    var inp = inputStrings[i];
                    var rails = inputRails[i];
                }
                answers[i].ShouldEqual(expect[i]);
            }
        };

        private static string[] inputStrings;
        private static int[] inputRails;
        private static string[] expect;
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
            inputStrings = new string[] { "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ","1243", "15243", "152463", "1524637", "15246837" };
            rails = new[] { 10,3, 3, 3, 3, 3 };
            expected = new string[][]
            {
                new string[]
                {
                    "12",
                    "345",
                    "6789",
                    "ABCD",
                    "EFGH",
                    "IJKL",
                    "MNOP",
                    "QRST",
                    "UVWX",
                    "YZ"
                },
                new string[]
                {
                    "1",
                    "24",
                    "3"
                },
                new string[]
                {
                    "15",
                    "24",
                    "3"
                },
                new string[]
                {
                    "15",
                    "246",
                    "3"
                },
                new string[]
                {
                    "15",
                    "246",
                    "37"
                },
                new string[]
                {
                    "15",
                    "2468",
                    "37"
                },
            };
            answer = new string[expected.Length][];
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
        private static string[][] expected;
        private static string[][] answer;
    }

    public class When_Decoding_A_Message_From_The_Rails
    {
        Establish context = () =>
        {
            input = new string[][]
            {
                new string[]
                {
                    "1",
                    "24",
                    "3"
                },
                new string[]
                {
                    "15",
                    "24",
                    "3"
                },
                new string[]
                {
                    "15",
                    "246",
                    "3"
                },
                new string[]
                {
                    "15",
                    "246",
                    "37"
                },
                new string[]
                {
                    "15",
                    "2468",
                    "37"
                },
            };
            expected = new string[] { "1234","12345", "123456", "1234567", "12345678" };
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

        private static string[][] input;
        private static string[] expected;
        private static string[] answers;
    }
}