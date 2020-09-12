using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ZPD_1_1.Interfaces;

namespace ZPD_1_1.Alphabets
{
    public class UkrainianAlphabet : IAlphabet
    {
        private List<char> _symbols;

        public UkrainianAlphabet()
        {
            _symbols = new List<char>
            {
                'А', 'Б', 'В', 'Г', 'Ґ',
                'Д', 'Е', 'Є', 'Ж', 'З',
                'И', 'І', 'Ї', 'Й', 'К',
                'Л', 'М', 'Н', 'О', 'П',
                'Р', 'С', 'Т', 'У', 'Ф',
                'Х', 'Ц', 'Ч', 'Ш', 'Щ',
                'Ь', 'Ю', 'Я'
            };

        }

        public char this[int index]
        {
            get
            {
                if (Size < index + 1)
                    return '_';

                return _symbols[index];
            }
        }

        public int this[char symbol]
        {
            get
            {
                return _symbols.IndexOf(symbol);
            }
        }

        public int Size
        {
            get
            {
                return _symbols.Count;
            }
        }


    }
}
