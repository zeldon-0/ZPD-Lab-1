using System;
using Xunit;
using ZPD_1_1.Algorithms;
using ZPD_1_1.Interfaces;
using ZPD_1_1.Alphabets;
namespace ZPD_1_1.Tests
{
    public class HillCipherTest
    {
        [Theory]
        [InlineData("AVC F", 
            "QHO Z",
            new object[] 
            {
                new int[] { 15, 2, 3, 9 } 
            } )]

        [InlineData("UTGDDSVUZQHBDDTFTOTFZXELJVELRHELRHXUJJJGD RSXPCZSFDETLQVLTOHJRZJJRZJJB IFPMCIVLQVLMGLQVLIZUVIZUVIZU VQNLVRVLYRH M WMWGFTOYFTTBLHT XVTORIXVTONB",
            "VNBTEBAXMXDOPEDQMJDQTGBXFUBXXQBXXQIHTMQXD WRXKHOHXOJLIFREMJLCPCTMPCTMM TJWYSBPIFRECMIFREFJXXFJXXFJX XZPNELIQTXQ S OSODDMJXPRIPIVA JMMJYVJMMJBS",
            new object[]
            {
                new int[] { 4, 1, 5, 5 }
            })]


        [InlineData("fbufghnbunfdbzdfofd gundougdngnudfgdugifdugoifdungifodnugcfgfnggbnduignpdfbgnd gjfjnhkjbkjbljfgvjgvhhvbjbnbkjnffg ghjghjkhjkhjkhZ",
            "BYBJPNXEDPVGJADGRLA XDPCDYAFMXLHBMFKBMEVGYAIKVGDPMEOLFMYAXPVFILHPRMSIXLDUBYXLA XNEPKMDZOHLZWNEZRKVBIFIFOTECFPKPOS WPMPNYLPMNDYLTY",
            new object[]
            {
                new int[] { 6, 23, 17, 17 }
            })]
        [InlineData("fbufghnbunfdbzdfofd gundougdngnudfgdugifdugoifdungifodnugcfgfnggbnduignpdfbgnd gjfjnhkjbkjbljfgvjgvhhvbjbnbkjnffg ghjghjkhjkhjkhZ fasfa",
            "BYBJPNXEDPVGJADGRLA XDPCDYAFMXLHBMFKBMEVGYAIKVGDPMEOLFMYAXPVFILHPRMSIXLDUBYXLA XNEPKMDZOHLZWNEZRKVBIFIFOTECFPKPOS WPMPNYLPMNDYLTY EHPBDJ",
            new object[]
            {
                new int[] { 6, 23, 17, 17 }
            })]
        [InlineData("DETERMINANT",
            "RANYXMYZANPS",
            new object[]
            {
                new int[] { 3, 2, 8, 7}
            })]


        public void Encode_MessageInEnglishAndKey_ReturnsMessageEncodedForEnglishAlphabetAndProvidedKey(string message, string expectedEncodedMessage, object[] key)
        {
            var flattenedKey = (int[])key[0];

            int[,] keyTransformed = new int[2, 2] { 
                { flattenedKey[0], flattenedKey[1] },
                { flattenedKey[2], flattenedKey[3] } };
            HillCipher encoder = 
                new HillCipher(keyTransformed, new EnglishAlphabet());

            string encodedMessage = encoder.Encode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }

        [Theory]


        [InlineData("ивалоиравврвпв г грчмгршгрм іваівг раівшга рвіа твомптвішгп твптва пгварп атвптвап рвапртващшпрва повашпг ващпо рвадлпр вапрбвалпрва лрпдавр И",
        "ЄЕЛФЖКСИХВБІШЧ С ГЛЄАЦДФМШП ЬЇБЙУМ ШТТЩЛОО БІАТ ЙЇКНЦҐБУЕЯЦ ҐРЧЙЇЖ ЦЮПЮИЛ ЦЙЇЦҐЇБЙ ГЇБЙГЙЇЄЮІЄБІЖ ЦТИНКОІ ЇБНФЄ ПЇБЇИЙГ ЇБЙГПОЛФЙГЇБ ТБЮЇЙБР Л",
        new object[]
        {
                new int[] { 6, 23, 17, 17 }
        })]

        public void Encode_MessageInUkrainianAndKey_ReturnsMessageEncodedForUkrainianAlphabetAndProvidedKey(string message, string expectedEncodedMessage, object[] key)
        {
            var flattenedKey = (int[])key[0];

            int[,] keyTransformed = new int[2, 2] {
                { flattenedKey[0], flattenedKey[1] },
                { flattenedKey[2], flattenedKey[3] } };
            HillCipher encoder =
                new HillCipher(keyTransformed, new UkrainianAlphabet());

            string encodedMessage = encoder.Encode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }

        [Theory]
        [InlineData("RANYXMYZANPS",
            "DETERMINANTS",
            new object[]
            {
                new int[] { 3, 2, 8, 7}
            })]

        [InlineData("VNBTEBAXMXDOPEDQMJDQTGBXFUBXXQBXXQIHTMQXD WRXKHOHXOJLIFREMJLCPCTMPCTMM TJWYSBPIFRECMIFREFJXXFJXXFJX XZPNELIQTXQ S OSODDMJXPRIPIVA JMMJYVJMMJBS",
            "UTGDDSVUZQHBDDTFTOTFZXELJVELRHELRHXUJJJGD RSXPCZSFDETLQVLTOHJRZJJRZJJB IFPMCIVLQVLMGLQVLIZUVIZUVIZU VQNLVRVLYRH M WMWGFTOYFTTBLHT XVTORIXVTONB",

            new object[]
            {
                new int[] { 4, 1, 5, 5 }
            })]


        [InlineData("BYBJPNXEDPVGJADGRLA XDPCDYAFMXLHBMFKBMEVGYAIKVGDPMEOLFMYAXPVFILHPRMSIXLDUBYXLA XNEPKMDZOHLZWNEZRKVBIFIFOTECFPKPOS WPMPNYLPMNDYLTY",
            "FBUFGHNBUNFDBZDFOFD GUNDOUGDNGNUDFGDUGIFDUGOIFDUNGIFODNUGCFGFNGGBNDUIGNPDFBGND GJFJNHKJBKJBLJFGVJGVHHVBJBNBKJNFFG GHJGHJKHJKHJKHZ",

            new object[]
            {
                new int[] { 6, 23, 17, 17 }
            })]
        [InlineData("BYBJPNXEDPVGJADGRLA XDPCDYAFMXLHBMFKBMEVGYAIKVGDPMEOLFMYAXPVFILHPRMSIXLDUBYXLA XNEPKMDZOHLZWNEZRKVBIFIFOTECFPKPOS WPMPNYLPMNDYLTY EHPBDJ",
            "FBUFGHNBUNFDBZDFOFD GUNDOUGDNGNUDFGDUGIFDUGOIFDUNGIFODNUGCFGFNGGBNDUIGNPDFBGND GJFJNHKJBKJBLJFGVJGVHHVBJBNBKJNFFG GHJGHJKHJKHJKHZ FASFAZ",
            new object[]
            {
                new int[] { 6, 23, 17, 17 }
            })]
        public void Decode_MessageInEnglishAndKey_ReturnsMessageDecodedForEnglishAlphabetAndProvidedKey(string message, string expectedDecodedMessage, object[] key)
        {
            var flattenedKey = (int[])key[0];

            int[,] keyTransformed = new int[2, 2] {
                { flattenedKey[0], flattenedKey[1] },
                { flattenedKey[2], flattenedKey[3] } };
            HillCipher encoder =
                new HillCipher(keyTransformed, new EnglishAlphabet());

            string encodedMessage = encoder.Decode(message);

            Assert.Equal(expectedDecodedMessage, encodedMessage);

        }

    }
}
