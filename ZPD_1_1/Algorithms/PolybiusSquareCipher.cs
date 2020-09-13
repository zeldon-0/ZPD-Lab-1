using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ZPD_1_1.Interfaces;

namespace ZPD_1_1.Algorithms
{
    public class PolybiusSquareCipher
    {
        private IAlphabet _alphabet;
        public PolybiusSquareCipher(IAlphabet alphabet)
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

            var square = _generateSquare();

            StringBuilder codedMessage = new StringBuilder();

            foreach(char symbol in message.ToUpper())
            {

                Regex pattern = new Regex(@"\W|[0-9]");
                if (pattern.Match(symbol.ToString()).Success)
                {
                    codedMessage.Append(symbol);
                }
                else 
                {
                    (int row, int column) = _findSymbol(square, symbol);

                    codedMessage.Append($"{row}{column} ");
                }
                
            }

            return codedMessage.ToString();
        }

        public string Decode(string message)
        {
            if (message == null)
                throw new ArgumentNullException("Provided message is null");

            var square = _generateSquare();

            StringBuilder codedMessage = new StringBuilder();

            foreach (string symbol in message.Split(" "))
            {

                Regex pattern = new Regex(@"\W");
                if (pattern.Match(symbol).Success)
                {
                    codedMessage.Append(symbol);
                }
                else
                {
                    int row = Int32.Parse(symbol[0].ToString());
                    int column = Int32.Parse(symbol[1].ToString());

                    codedMessage.Append($"{square[row-1, column-1]}");
                }

            }

            return codedMessage.ToString();
        }

        private char[,] _generateSquare()
        {
            double unroundedSize = Math.Sqrt( (double) _alphabet.Size);
            int size = (int)Math.Ceiling(unroundedSize);
            char[,] square = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    square[row, column] = _alphabet[row * size + column];
                }
            }

            return square;
        }

        private (int, int) _findSymbol(char[,] square, char symbol)
        {
            int size = square.GetLength(0);
            for (int row = 0; row < size; row ++)
            {
                for (int column = 0; column < size; column ++)
                {
                    if (square[row, column] == symbol)
                        return (row + 1, column + 1);
                }
            }

            throw new ArgumentException($"The character {symbol} is not defined in the alphabet");
        }
    }
}
