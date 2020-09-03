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

            Dictionary<int, char> a = GetNumberSequence(stringA);
            Dictionary<int, char> b = GetNumberSequence(stringB);

            for (int pos = 0; pos < biggerStringLength; pos++)
            {
                if (arrayCharA[pos] == arrayCharB[pos])
                    continue;

                if (a.Keys.Contains(pos))
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (a.Keys.Count > b.Keys.Count)
                            return 1;

                        if (a.Keys.Count < b.Keys.Count)
                            return -1;

                        if (Convert.ToInt32(string.Join("", a.Values)) > Convert.ToInt32(string.Join("", b.Values)))
                            return 1;

                        if (Convert.ToInt32(string.Join("", a.Values)) < Convert.ToInt32(string.Join("", b.Values)))
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

        private Dictionary<int, char> GetNumberSequence(string str)
        {
            Dictionary<int, char> DictPosNumber = new Dictionary<int, char>();
            for (int i = 0; i < str.Length; i++)
                if (IsNumber(str[i]))
                    DictPosNumber.Add(i, str[i]);

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
