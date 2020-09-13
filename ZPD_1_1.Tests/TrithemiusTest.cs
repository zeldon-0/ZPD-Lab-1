using System;
using Xunit;
using ZPD_1_1.Algorithms;
using ZPD_1_1.Interfaces;
using ZPD_1_1.Alphabets;
namespace ZPD_1_1.Tests
{
    public class TrithemiusTest
    {
        [Theory]
        [InlineData("ABCDZ", "ACEGD")]
        [InlineData("BCVBVCBIJOBIJBOIFDBOIDJFOFDIJBDOIBDONBDOFNODINBFDNBOIFNXOIDFNBNDFOBIDFNBOIFDBOIJCVOIJBCVOBOCVOBIVJCBOICJJFGSJFODSNFODSNBVIDUBVCUBVCBVNDSONVSDNFASONASONDSOBFDOBHFDBFHDBFXCNBCXVBJFBKFNBC",
            "BDXEZHHPRXLTVOCXVUTHCYFCMEDJLEHTOILXXMPBTCEUAGVAZKZNIGPASNJMVKXORBPXTWFUIDBAZNIKEYSNPIKEYMAPJDRZNCWWKFAIJGIVNKUKAWPZPFBQLZVNVQYRZUCCXQHXUUDBNYRNGDDRKHHYOLZEDPDKJIHMPMLQJPBQSONUDAXHDMBD")]
        [InlineData("DGDBNBCXNSFOISNFOSDNF SDNFODSNF SDIFN SDJF NDSKJFN DSF DSH OUDIF ODBDJBF SUBFOS FA OAD PAND AIDOFN BSOFN 3 2N32OI N423N4 N``NPRNRPEWN SFSIFN SDONFSOINFSINFOISNFOSN FOISDN FOISDNF",
            "DHFERGIEVBPZUFBUEJVGZ NZKDNDTPI WIOMV BNUR ARHAAXG XNB AQG OVFLJ TJILSLQ EHPUEJ XT IVZ MYMD BKGSKT IAXPY 3 2Z32BW C423D4 E``FILINMCVN THVMKT ZLXXQEBWCVJAGZJEPLEOTP ISNYKV OYTEQBU")]


        public void Encode_MessageInEnglish_ReturnsMessageEncodedForEnglishAlphabet(string message, string expectedEncodedMessage)
        {
            TrithemiusCipher encoder = 
                new TrithemiusCipher( new EnglishAlphabet());

            string encodedMessage = encoder.Encode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }

        [Theory]
        [InlineData("Пароль", "ПБТСПВ")]
        [InlineData("Ой на горі та й женці жнуть, А попід горою, яром - долиною козаки йдуть Гей, долиною, гей, широкою, козаки йдуть. Попереду Дорошенко Веде своє військо, Військо запорізьке хорошенько." +
            " Гей, долиною, гей, широкою, Хорошенько. А позаду Сагайдачний, Що проміняв жінку на тютюн та люльку необачний. Гей, долиною, гей, широкою, Необачний.",
            "ОК ПГ ЄУЦО ЬЗ У ПОЬЄЦ ФБЖЖН, С ЖЖИГЮ ЬЙМЛЩ, ЮРПО - ЖТРМФЦЄ ФЩСЙШХ ЩТЖЖН ФШГ, ЩИЖҐЇКШ, БДЙ, ЩЇУТПФД, ТЧПІЦУ ЧРЕЕЛ. ДДЄШИЬЬМ ЯЙМЛЦДНЛР ДИИЇ ШИЧН ЙУЦВЇЬВ, РЬАЗПҐЗ БЦЙЙМЖЄЩКЄ ЧСФУБЙХЕФЩ." +
            " ЛПЧ, РБЯШГДП, ХЩҐ, РГКЙИЛЩ, ФОСРЮИТГСЦ. З ЩЩСЙПД ҐНСПАЦТНЖВЕ, УЙ ЛНМЛІОБД ЇМУСЮ ЦИ АИВЇЯ ДН АНВОГЙ ЖЮІШШУКЖЇ. ГЄЛ, ЖТРМФЦЄ, ЙНХ, ЖФВБЮГН, ҐЧЄФФПИҐЖ.")]

        public void Encode_MessageInUkrainian_ReturnsMessageEncodedForUkrainianAlphabet(string message, string expectedEncodedMessage)
        {
            TrithemiusCipher encoder =
                new TrithemiusCipher(new UkrainianAlphabet());

            string encodedMessage = encoder.Encode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }

        [Theory]
        [InlineData("ACEGD", "ABCDZ")]
        [InlineData("BDXEZHHPRXLTVOCXVUTHCYFCMEDJLEHTOILXXMPBTCEUAGVAZKZNIGPASNJMVKXORBPXTWFUIDBAZNIKEYSNPIKEYMAPJDRZNCWWKFAIJGIVNKUKAWPZPFBQLZVNVQYRZUCCXQHXUUDBNYRNGDDRKHHYOLZEDPDKJIHMPMLQJPBQSONUDAXHDMBD",
            "BCVBVCBIJOBIJBOIFDBOIDJFOFDIJBDOIBDONBDOFNODINBFDNBOIFNXOIDFNBNDFOBIDFNBOIFDBOIJCVOIJBCVOBOCVOBIVJCBOICJJFGSJFODSNFODSNBVIDUBVCUBVCBVNDSONVSDNFASONASONDSOBFDOBHFDBFHDBFXCNBCXVBJFBKFNBC")]
        [InlineData("DHFERGIEVBPZUFBUEJVGZ NZKDNDTPI WIOMV BNUR ARHAAXG XNB AQG OVFLJ TJILSLQ EHPUEJ XT IVZ MYMD BKGSKT IAXPY 3 2Z32BW C423D4 E``FILINMCVN THVMKT ZLXXQEBWCVJAGZJEPLEOTP ISNYKV OYTEQBU",
            "DGDBNBCXNSFOISNFOSDNF SDNFODSNF SDIFN SDJF NDSKJFN DSF DSH OUDIF ODBDJBF SUBFOS FA OAD PAND AIDOFN BSOFN 3 2N32OI N423N4 N``NPRNRPEWN SFSIFN SDONFSOINFSINFOISNFOSN FOISDN FOISDNF")]


        public void Decode_EncodedMessageInEnglish_ReturnsMessageDecodedForEnglishAlphabet(string message, string expectedEncodedMessage)
        {
            TrithemiusCipher encoder =
                new TrithemiusCipher(new EnglishAlphabet());

            string encodedMessage = encoder.Decode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }


        [Theory]
        [InlineData("ПБТСПВ", "ПАРОЛЬ")]
        [InlineData("ОК ПГ ЄУЦО ЬЗ У ПОЬЄЦ ФБЖЖН, С ЖЖИГЮ ЬЙМЛЩ, ЮРПО - ЖТРМФЦЄ ФЩСЙШХ ЩТЖЖН ФШГ, ЩИЖҐЇКШ, БДЙ, ЩЇУТПФД, ТЧПІЦУ ЧРЕЕЛ. ДДЄШИЬЬМ ЯЙМЛЦДНЛР ДИИЇ ШИЧН ЙУЦВЇЬВ, РЬАЗПҐЗ БЦЙЙМЖЄЩКЄ ЧСФУБЙХЕФЩ." +
            " ЛПЧ, РБЯШГДП, ХЩҐ, РГКЙИЛЩ, ФОСРЮИТГСЦ. З ЩЩСЙПД ҐНСПАЦТНЖВЕ, УЙ ЛНМЛІОБД ЇМУСЮ ЦИ АИВЇЯ ДН АНВОГЙ ЖЮІШШУКЖЇ. ГЄЛ, ЖТРМФЦЄ, ЙНХ, ЖФВБЮГН, ҐЧЄФФПИҐЖ.",
            "ОЙ НА ГОРІ ТА Й ЖЕНЦІ ЖНУТЬ, А ПОПІД ГОРОЮ, ЯРОМ - ДОЛИНОЮ КОЗАКИ ЙДУТЬ ГЕЙ, ДОЛИНОЮ, ГЕЙ, ШИРОКОЮ, КОЗАКИ ЙДУТЬ. ПОПЕРЕДУ ДОРОШЕНКО ВЕДЕ СВОЄ ВІЙСЬКО, ВІЙСЬКО ЗАПОРІЗЬКЕ ХОРОШЕНЬКО." +
            " ГЕЙ, ДОЛИНОЮ, ГЕЙ, ШИРОКОЮ, ХОРОШЕНЬКО. А ПОЗАДУ САГАЙДАЧНИЙ, ЩО ПРОМІНЯВ ЖІНКУ НА ТЮТЮН ТА ЛЮЛЬКУ НЕОБАЧНИЙ. ГЕЙ, ДОЛИНОЮ, ГЕЙ, ШИРОКОЮ, НЕОБАЧНИЙ.")]
        public void Decode_EncodedMessageInUkrainian_ReturnsMessageDecodedForUkrainianAlphabet(string message, string expectedEncodedMessage)
        {
            TrithemiusCipher encoder =
                new TrithemiusCipher(new UkrainianAlphabet());

            string encodedMessage = encoder.Decode(message);

            Assert.Equal(expectedEncodedMessage, encodedMessage);

        }


    }
}
