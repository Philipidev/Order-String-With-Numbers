using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStringWithNumbers
{
    public class OrderStringNumber : IComparer<string>
    {
        const char PAD = '#';

        public int Compare(string stringA, string stringB)
        {
            int biggerStringLength = stringA.Length > stringB.Length ? stringA.Length : stringB.Length;

            stringA = stringA.PadRight(biggerStringLength, PAD);
            stringB = stringB.PadRight(biggerStringLength, PAD);

            char[] arrayCharA = stringA.ToLower().ToCharArray();
            char[] arrayCharB = stringB.ToLower().ToCharArray();

            int result = 0;

            for (int pos = 0; pos < biggerStringLength; pos++)
            {
                if (arrayCharA[pos] == arrayCharB[pos])
                    continue;

                if (IsNumber(arrayCharB[pos]) && IsLetter(arrayCharA[pos]))
                {
                    result = -1;
                    break;
                }

                if (IsNumber(arrayCharA[pos]) && IsLetter(arrayCharB[pos]))
                {
                    result = 1;
                    break;
                }

                if (arrayCharA[pos] > arrayCharB[pos])
                {
                    result = 1;
                    break;
                }

                if (arrayCharA[pos] < arrayCharB[pos])
                {
                    result = -1;
                    break;
                }
            }

            return result;
        }

        private bool IsLetter(char letter)
        {
            if (letter < 48 || letter > 57)
                return true;
            return false;
        }

        private bool IsNumber(char letter)
        {
            if (letter >= 48 && letter <= 57)
                return true;
            return false;
        }

    }
}
