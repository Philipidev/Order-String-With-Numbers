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

            Dictionary<int, char> DictionaryStringA = new Dictionary<int, char>();
            Dictionary<int, char> DictionaryStringB = new Dictionary<int, char>();

            for (int pos = 0; pos < biggerStringLength; pos++)
            {
                if (arrayCharA[pos] == arrayCharB[pos])
                    continue;

                if (IsNumber(arrayCharA[pos]) && IsNumber(arrayCharB[pos]))
                {
                    DictionaryStringA = GetNumberSequence(stringA, pos);
                    DictionaryStringB = GetNumberSequence(stringB, pos);

                    if (DictionaryStringA.Keys.Count > DictionaryStringB.Keys.Count)
                        return 1;

                    if (DictionaryStringA.Keys.Count < DictionaryStringB.Keys.Count)
                        return -1;

                    if (Convert.ToInt32(string.Join("", DictionaryStringA.Values)) > Convert.ToInt32(string.Join("", DictionaryStringB.Values)))
                        return 1;

                    if (Convert.ToInt32(string.Join("", DictionaryStringA.Values)) < Convert.ToInt32(string.Join("", DictionaryStringB.Values)))
                        return -1;
                }

                if (IsNumber(arrayCharB[pos]) && IsLetter(arrayCharA[pos]))
                    return -1;

                if (IsNumber(arrayCharA[pos]) && IsLetter(arrayCharB[pos]))
                    return 1;

                if (arrayCharA[pos] > arrayCharB[pos])
                    return 1;

                if (arrayCharA[pos] < arrayCharB[pos])
                    return -1;

            }

            return 0;
        }

        private Dictionary<int, char> GetNumberSequence(string str, int pos = 0)
        {
            Dictionary<int, char> DictPosNumber = new Dictionary<int, char>();
            for (; pos < str.Length; pos++)
            {
                if (IsNumber(str[pos]))
                {
                    DictPosNumber.Add(pos, str[pos]);
                    if (pos + 1 < str.Length && IsLetter(str[pos + 1]))
                        break;
                }
            }


            return DictPosNumber;
        }

        private bool IsLetter(char letter)
        {
            if (letter != PAD && (letter < 48 || letter > 57))
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
