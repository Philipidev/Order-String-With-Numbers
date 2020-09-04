# Order-String-With-Numbers

<br/>This is a Custom IComparer to sort an array of strings that have numbers mixed with letters like the following
```csharp
string[] arrExample = { "Street 2A", "Street 3", "Street 4", "Street 3C", "Street 12", "Street 1B", "Street 1B1", "Street 1B2", "Street 1B2a", "Street 1B23", "Street 1", "Street 2", "Street 31", "Street 3BC", "Street 3A", "Street 22C" };
```

<br/><br/>
## Custom IComparer

To use it is simple, just create a class that inheritate the `IComparer` interface then add or create your custom Comparer
```csharp
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

```
<br/>Then all you need to do next e call the OrderBy Method and pass your custom Comparer
```csharp
  string[] arrExample = { "Street 2A", "Street 3", "Street 4", "Street 3C", "Street 12", "Street 1B", "Street 1B1", "Street 1B2", "Street 1B2a", "Street 1B23", "Street 1", "Street 2", "Street 31", "Street 3BC", "Street 3A", "Street 22C" };

  //Use OrderBy by Linq and call the custom Comparer class
  arrExample = arrExample.OrderBy(ex => ex, new OrderStringNumber()).ToArray();
```
```
Output:
Street 1
Street 1B
Street 1B1
Street 1B2
Street 1B2a
Street 1B23
Street 2
Street 2A
Street 3
Street 3A
Street 3BC
Street 3C
Street 4
Street 12
Street 22C
Street 31
```
