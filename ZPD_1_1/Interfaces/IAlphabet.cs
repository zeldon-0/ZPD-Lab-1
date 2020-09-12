using System;
using System.Collections.Generic;
using System.Text;

namespace ZPD_1_1.Interfaces
{
    public interface IAlphabet
    {
        char this[int index]
        {
            get;
        }

        int this[char symbol]
        {
            get;
        }

        int Size
        {
            get;
        }
    }
}
