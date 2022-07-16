Console.Write("Введите строку: ");
Console.WriteLine(ReverseString(Console.ReadLine()));

Console.ReadLine();

static string ReverseString(string primary) 
{
    char[] chars = primary.ToCharArray();
    char[] reverse = new char[chars.Length];
    string final = string.Empty;
    for (int i = chars.Length-1; i >= 0; i--)
    {
        int a = 0;
        reverse[a] = chars[i];
        final+=reverse[a];
        a++;
    }
    return final;
}