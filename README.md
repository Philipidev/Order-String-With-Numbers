# Order-String-With-Numbers

<br/>This is a Custom IComparer to sort an array of strings that have numbers mixed with letters like the following
```csharp
string[] arrExample = { "Street 2A", "Street 3", "Street 4", "Street 3C", "Street 12", "Street 1B", "Street 1", "Street 2", "Street 3A1", "Street 3BC", "Street 3A","Street 22C" };
```

<br/><br/>
## Custom IComparer

To use it is simple, just create a class that inheritate the `IComparer` interface then add or create your custom Comparer
```csharp
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

```
<br/>Then all you need to do next e call the OrderBy Method and pass your custom Comparer
```csharp
  string[] arrExample = { "Street 2A", "Street 3", "Street 4", "Street 3C", "Street 12", "Street 1B", "Street 1", "Street 2", "Street 3A1", "Street 3BC", "Street 3A","Street 22C" };

  //Use OrderBy by Linq and call the custom Comparer class
  arrExample = arrExample.OrderBy(ex => ex, new OrderStringNumber()).ToArray();
```
```
Output:
  Street 1
  Street 1B
  Street 12
  Street 2
  Street 2A
  Street 22C
  Street 3
  Street 3A
  Street 3A1
  Street 3BC
  Street 3C
  Street 4
```
