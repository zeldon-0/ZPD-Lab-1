using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using ZPD_1_1.Interfaces;
using System.Runtime.InteropServices;

namespace ZPD_1_1.Algorithms
{
    public class HillCipher
    {
        private int[,] _key = new int[2, 2];
        private IAlphabet _alphabet;
        
        public HillCipher(int[,] key, IAlphabet alphabet)
        {
            if (key == null) 
                throw new ArgumentNullException("Key provided is null.");

            if (key.GetLength(0) != 2 || key.GetLength(1) != 2)
                throw new ArgumentException("Provided key dimensions ({key.GetLength(0)} by {key.GetLength(1)}) are not applicable (Should be 2 by 2).");

            _alphabet = alphabet ?? throw new ArgumentNullException("Provided alphabet is null.");

            int size = alphabet.Size;
            int det = _determinant(key);

            if (_gcd(size, det) != 1)
                throw new ArgumentException("Provided key's determinant and the alphabet size aren't relatively prime.");

            _key = key;
        }

        public void SetAlphabet(IAlphabet alphabet)
        {
            if (alphabet == null)
                throw new ArgumentNullException("Provided alphabet is null.");

            int size = alphabet.Size;
            int det = _determinant(_key);

            if (_gcd(size, det) != 1)
                throw new ArgumentException("Provided key's determinant and the alphabet size aren't relatively prime.");

            _alphabet = alphabet;
        }
        public void SetKey(int[,] key)
        {
            if (key == null)
                throw new ArgumentNullException("Key provided is null.");

            if (key.GetLength(0) != 2 || key.GetLength(1) != 2)
                throw new ArgumentException("Provided key dimensions ({key.GetLength(0)} by {key.GetLength(1)}) are not applicable (Should be 2 by 2).");

            int size = _alphabet.Size;
            int det = _determinant(_key);

            if (_gcd(size, det) != 1)
                throw new ArgumentException("Provided key's determinant and the alphabet size aren't relatively prime.");

            _key = key;
        }

        public string Encode(string message)
        {
            if (message == null)
                throw new ArgumentNullException("Provided alphabet is null");

            message = message.ToUpper();

            StringBuilder codedMessage = new StringBuilder();

            for (int i=0; i < message.Length; i++)
            {
                int[,] bigram = new int[2, 1];

                Regex pattern = new Regex(@"\w");

                StringBuilder nonAlpanumericalBeforeBigram = new StringBuilder();
                while (i < message.Length && !pattern.Match(message[i].ToString()).Success)
                {
                    nonAlpanumericalBeforeBigram.Append(message[i]);
                    i++;
                }


                bigram[0, 0] = _alphabet[message[i]];
                i++;

                StringBuilder nonAlpanumericalInTheMiddle = new StringBuilder();

                while (i < message.Length && !pattern.Match(message[i].ToString()).Success)
                {
                    nonAlpanumericalInTheMiddle.Append(message[i]);
                    i++;
                }
                /*
                if (i == message.Length)
                {
                    bigram[1, 0] = bigram[0, 0];// bigram[0, 0] - 1;//_alphabet[bigram[0, 0]];//_alphabet[message[i-1]];  
                    for (int j = i - 1; j>=0; j--)
                    {
                        if (pattern.Match(message.ToString()[j].ToString()).Success)
                            bigram[0, 0] = _alphabet[message[j]];
                    }

                }*/
                if (i == message.Length)
                {
                    bigram[1, 0] = bigram[0, 0] - 1; //For now i'll take the lower value. Unless something changes while decoding this'll stay that way.
                }

                else
                    bigram[1, 0] = _alphabet[message[i]];


                int[,] resultingMatrix = _modMultiplyMatrixes(_key, bigram);


                codedMessage.Append(nonAlpanumericalBeforeBigram);
                codedMessage.Append(_alphabet[resultingMatrix[0, 0]]);

                codedMessage.Append(nonAlpanumericalInTheMiddle);
                codedMessage.Append(_alphabet[resultingMatrix[1, 0]]);

            }

            return codedMessage.ToString();

        }

        public string Decode(string message)
        {

            if (message == null)
                throw new ArgumentNullException("Provided alphabet is null");

            message = message.ToUpper();

            int[,] decodingKey = _getInverseKey();

            StringBuilder decodedMessage = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                int[,] bigram = new int[2, 1];

                Regex pattern = new Regex(@"\w");

                StringBuilder nonAlpanumericalBeforeBigram = new StringBuilder();
                while (i < message.Length && !pattern.Match(message[i].ToString()).Success)
                {
                    nonAlpanumericalBeforeBigram.Append(message[i]);
                    i++;
                }


                bigram[0, 0] = _alphabet[message[i]];
                i++;

                StringBuilder nonAlpanumericalInTheMiddle = new StringBuilder();

                while (i < message.Length && !pattern.Match(message[i].ToString()).Success)
                {
                    nonAlpanumericalInTheMiddle.Append(message[i]);
                    i++;
                }

                if (i == message.Length)
                {
                    bigram[1, 0] = bigram[0, 0] - 1; 
                }

                else
                    bigram[1, 0] = _alphabet[message[i]];


                int[,] resultingMatrix = _modMultiplyMatrixes(decodingKey, bigram);


                decodedMessage.Append(nonAlpanumericalBeforeBigram);
                decodedMessage.Append(_alphabet[resultingMatrix[0, 0]]);

                decodedMessage.Append(nonAlpanumericalInTheMiddle);
                decodedMessage.Append(_alphabet[resultingMatrix[1, 0]]);

            }

            return decodedMessage.ToString();

        }


        private int _gcd(int a, int b)
        {
            if (a < 0) a = -a;
            if (b < 0) b = -b;

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        private int _determinant(int[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[0, 1];
        }

        private int[,] _modMultiplyMatrixes(int[,] matrix1, int[,] matrix2)
        {
            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int column= 0; column < result.GetLength(1); column++)
                {
                    int currentElement = 0;
                    for (int i = 0; i < matrix1.GetLength(1); i++)
                        currentElement += matrix1[row, i] * matrix2[i, column];

                    result[row, column] = currentElement % _alphabet.Size;

                    if (result[row, column] < 0)
                        result[row, column] = result[row, column] + _alphabet.Size;
                }

            }

            return result;

        }


        private int _modInverse(int a, int m)
        {
            a = a % m;

            if (a < 0)
                a = a + m;
            for (int x = 1; x < m; x++)
                if ((a * x) % m == 1)
                    return x;
            return 1;
        }

        private int[,] _getInverseKey()
        {
            int[,] matrix = new int[2, 2]
            {
                { _key[1,1], - _key[0,1]},
                {- _key[1,0],  _key[0,0]}
            };

            int factor = _modInverse(_key[0, 0] * _key[1, 1] - _key[1, 0] * _key[0, 1], _alphabet.Size);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(0); column++)
                {
                    matrix[row, column] = matrix[row, column] * factor;
                    matrix[row, column] = matrix[row, column] % _alphabet.Size;

                    if (matrix[row, column] < 0)
                        matrix[row, column] = matrix[row, column] + _alphabet.Size;

                }
            }

            return matrix;
        }

    }
}
