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
                throw new ArgumentNullException("Provided message is null");

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

        public string Decode(string encodedMessage)
        {
            if (encodedMessage == null)
                throw new ArgumentNullException("Provided message is null");

            encodedMessage = encodedMessage.ToUpper();

            StringBuilder originalMessage = new StringBuilder();

            Regex pattern = new Regex(@"\W|[0-9]");
            int shift = 0;
            foreach (char symbol in encodedMessage)
            {
                if (pattern.Match(symbol.ToString()).Success)
                {
                    originalMessage.Append(symbol);
                }
                else
                {
                    int shiftedPosition = _alphabet[symbol];
                    int originalPosition = (shiftedPosition - shift) % _alphabet.Size;

                    if (originalPosition < 0)
                        originalPosition += _alphabet.Size;

                    char shiftedSymbol = _alphabet[originalPosition];
                    shift++;

                    originalMessage.Append(shiftedSymbol);
                }
            }

            return originalMessage.ToString();
        }
    }
}
