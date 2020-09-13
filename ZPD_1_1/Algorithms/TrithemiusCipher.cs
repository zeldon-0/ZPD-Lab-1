using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ZPD_1_1.Interfaces;

namespace ZPD_1_1.Algorithms
{
    public class TrithemiusCipher
    {
        private IAlphabet _alphabet;

        public TrithemiusCipher(IAlphabet alphabet)
        {
            _alphabet = alphabet ?? throw new ArgumentNullException("Provided alphabet is null.");
        }

        public void SetAlphabet(IAlphabet alphabet)
        {
            _alphabet = alphabet ?? throw new ArgumentNullException("Provided alphabet is null.");
        }

        public string Encode(string message)
        {

            if (message == null)
                throw new ArgumentNullException("Provided alphabet is null");

            message = message.ToUpper();

            StringBuilder encodedMessage = new StringBuilder();

            Regex pattern = new Regex(@"\W|[0-9]");
            int shift = 0;
            foreach (char symbol in message)
            {
                if(pattern.Match(symbol.ToString()).Success)
                {
                    encodedMessage.Append(symbol);
                }
                else
                {
                    int originalPosition = _alphabet[symbol];
                    char shiftedSymbol = _alphabet[(originalPosition + shift) % _alphabet.Size];
                    shift++;

                    encodedMessage.Append(shiftedSymbol);
                }
            }

            return encodedMessage.ToString();
        }
    }
}
