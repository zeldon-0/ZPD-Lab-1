using System;
using Xunit;
using ZPD_1_1.Algorithms;
using ZPD_1_1.Interfaces;
using ZPD_1_1.Alphabets;
namespace ZPD_1_1.Tests
{
    public class PolybiusSquareTest
    {
        [Theory]
        [InlineData("ABC", "11 12 13 ")]
        [InlineData("abc", "11 12 13 ")]
        [InlineData("ABCDASGDBNCBCLVKBNCVBCVBRDMBTRPOBRTBNMNMBVNMVNPRNMGFNMBVNLBVMNTRPNMPRNMFGNMVPN",
            "11 12 13 14 11 41 21 14 12 32 13 12 13 26 44 25 12 32 13 44 12 13 44 12 36 14 31 12 42 36 34 33 12 36 42 12 32 31 32 " +
            "31 12 44 32 31 44 32 34 36 32 31 21 16 32 31 12 44 32 26 12 44 31 32 42 36 34 32 31 34 36 32 31 16 21 32 31 44 34 32 ")]
        [InlineData("asbcvbncboicnbdndfinbfdophgfdbfgbxckvkvdsvidfvibudfbfdbnbfndbpdobdpoofjdbfdjbjdfdhfdbcbfasfefsgfbcbcvbcbssdgrgthgvnvbnvsdsgthgfnnvbndgawsfwegrdghfhjvjnv",
            "11 41 12 13 44 12 32 13 12 33 23 13 32 12 14 32 14 16 23 32 12 16 14 33 34 22 21 16 14 12 16 21 12 46 13 25 44 25 44 14 41 44 23 14 16 44 " +
            "23 12 43 14 16 12 16 14 12 32 12 16 32 14 12 34 14 33 12 14 34 33 33 16 24 14 12 16 14 24 12 24 14 16 14 22 16 14 12 13 12 16 11 41 16 15 " +
            "16 41 21 16 12 13 12 13 44 12 13 12 41 41 14 21 36 21 42 22 21 44 32 44 12 32 44 41 14 41 21 42 22 21 16 32 32 44 12 32 14 21 11 45 41 16 " +
            "45 15 21 36 14 21 22 16 22 24 44 24 32 44 ")]

        
        public void Encode_MessageInEnglish_ReturnsMessageEncodedForEnglishAlphabet(string message, string expectedEncodedMessage)
        {
            PolybiusSquareCipher encoder = 
                new PolybiusSquareCipher(new EnglishAlphabet());

            string encodedMessage = encoder.Encode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }

        [Theory]
        [InlineData("A B * 1 5 ? ! C", "11  12  * 1 5 ? ! 13 ")]
        [InlineData("A B     C", "11  12      13 ")]
      

        public void Encode_MessageWithNon_Alphabetic_Characters_ReturnsMessageEncodedWithCharactersIntact(string message, string expectedEncodedMessage)
        {
            PolybiusSquareCipher encoder =
                new PolybiusSquareCipher(new EnglishAlphabet());

            string encodedMessage = encoder.Encode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }

        [Theory]
        [InlineData("АБВ", "11 12 13 ")]
        [InlineData("абв", "11 12 13 ")]
        [InlineData("мвамравмифілгвпшфгівгіфасгчмчсомрчсломруіагуцілвірловірамолвчраловіалоіварілоавчмичсмьстчимьчстимгіпаівимьвіимлірщшвйщВЙЦФШГВАПЦУАНАВІАІИВИАФІАФІВФВФВФЧВІПКУПВ",
            "35 13 11 35 43 11 13 35 25 51 26 34 14 13 42 55 51 14 26 13 14 26 51 11 44 14 54 35 54 44 41 35 43 54 44 34 41 35 43 46 26 11 14 46 53 26 34 13 26 43 34 41 13 26 43 11 35 " +
            "41 34 13 54 43 11 34 41 13 26 11 34 41 26 13 11 43 26 34 41 11 13 54 35 25 54 44 35 61 44 45 54 25 35 61 54 44 45 25 35 14 26 42 11 26 13 25 35 61 13 26 25 35 34 26 43 56 " +
            "55 13 32 56 13 32 53 51 55 14 13 11 42 53 46 11 36 11 13 26 11 26 25 13 25 11 51 26 11 51 26 13 51 13 51 13 51 54 13 26 42 33 46 42 13 ")]

        public void Encode_MessageInUkrainian_ReturnsMessageEncodedForUkrainianAlphabet(string message, string expectedEncodedMessage)
        {
            PolybiusSquareCipher encoder =
                new PolybiusSquareCipher(new UkrainianAlphabet());

            string encodedMessage = encoder.Encode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);
        }
        
        [Fact]
        public void Encode_MessageInUkrainianForEnglishAlphabet_ThrowsArgumentException()
        {
            PolybiusSquareCipher encoder =
                new PolybiusSquareCipher(new EnglishAlphabet());


            Assert.Throws<ArgumentException>( () => encoder.Encode("АБВ"));
        }

        [Fact]
        public void Encode_MessageInEnglishForUkrainianAlphabet_ThrowsArgumentException()
        {
            PolybiusSquareCipher encoder =
                new PolybiusSquareCipher(new UkrainianAlphabet());


            Assert.Throws<ArgumentException>(() => encoder.Encode("ABC"));
        }

        [Theory]
        [InlineData("11 12 13", "ABC")]
        [InlineData("11 12 13 14 11 41 21 14 12 32 13 12 13 26 44 25 12 32 13 44 12 13 44 12 36 14 31 12 42 36 34 33 12 36 42 12 32 31 32 " +
            "31 12 44 32 31 44 32 34 36 32 31 21 16 32 31 12 44 32 26 12 44 31 32 42 36 34 32 31 34 36 32 31 16 21 32 31 44 34 32",
            "ABCDASGDBNCBCLVKBNCVBCVBRDMBTRPOBRTBNMNMBVNMVNPRNMGFNMBVNLBVMNTRPNMPRNMFGNMVPN")]
        [InlineData("11 41 12 13 44 12 32 13 12 33 23 13 32 12 14 32 14 16 23 32 12 16 14 33 34 22 21 16 14 12 16 21 12 46 13 25 44 25 44 14 41 44 23 14 16 44 " +
            "23 12 43 14 16 12 16 14 12 32 12 16 32 14 12 34 14 33 12 14 34 33 33 16 24 14 12 16 14 24 12 24 14 16 14 22 16 14 12 13 12 16 11 41 16 15 " +
            "16 41 21 16 12 13 12 13 44 12 13 12 41 41 14 21 36 21 42 22 21 44 32 44 12 32 44 41 14 41 21 42 22 21 16 32 32 44 12 32 14 21 11 45 41 16 " +
            "45 15 21 36 14 21 22 16 22 24 44 24 32 44",
            "ASBCVBNCBOICNBDNDFINBFDOPHGFDBFGBXCKVKVDSVIDFVIBUDFBFDBNBFNDBPDOBDPOOFJDBFDJBJDFDHFDBCBFASFEFSGFBCBCVBCBSSDGRGTHGVNVBNVSDSGTHGFNNVBNDGAWSFWEGRDGHFHJVJNV")]

        public void Decode_MessageInEnglish_ReturnsMessageDecodedForEnglishAlphabet(string message, string expectedDecodedMessage)
        {
            PolybiusSquareCipher encoder =
                new PolybiusSquareCipher(new EnglishAlphabet());

            string encodedMessage = encoder.Decode(message);

            Assert.Equal(expectedDecodedMessage, encodedMessage);

        }

        [Theory]
        [InlineData("11 12 13", "АБВ")]
        [InlineData(
            "35 13 11 35 43 11 13 35 25 51 26 34 14 13 42 55 51 14 26 13 14 26 51 11 44 14 54 35 54 44 41 35 43 54 44 34 41 35 43 46 26 11 14 46 53 26 34 13 26 43 34 41 13 26 43 11 35 " +
            "41 34 13 54 43 11 34 41 13 26 11 34 41 26 13 11 43 26 34 41 11 13 54 35 25 54 44 35 61 44 45 54 25 35 61 54 44 45 25 35 14 26 42 11 26 13 25 35 61 13 26 25 35 34 26 43 56 " +
            "55 13 32 56 13 32 53 51 55 14 13 11 42 53 46 11 36 11 13 26 11 26 25 13 25 11 51 26 11 51 26 13 51 13 51 13 51 54 13 26 42 33 46 42 13",
            "МВАМРАВМИФІЛГВПШФГІВГІФАСГЧМЧСОМРЧСЛОМРУІАГУЦІЛВІРЛОВІРАМОЛВЧРАЛОВІАЛОІВАРІЛОАВЧМИЧСМЬСТЧИМЬЧСТИМГІПАІВИМЬВІИМЛІРЩШВЙЩВЙЦФШГВАПЦУАНАВІАІИВИАФІАФІВФВФВФЧВІПКУПВ")]

        public void Decode_MessageInUkrainian_ReturnsMessageDecodedForUkrainianAlphabet(string message, string expectedDecodedMessage)
        {
            PolybiusSquareCipher encoder =
                new PolybiusSquareCipher(new UkrainianAlphabet());

            string encodedMessage = encoder.Decode(message);

            Assert.Equal(expectedDecodedMessage, encodedMessage);
        }
    }
}
