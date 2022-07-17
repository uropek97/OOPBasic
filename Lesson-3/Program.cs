Console.Write("Введите строку: ");
Console.WriteLine(ReverseString(Console.ReadLine()));

Console.ReadLine();

static string ReverseString(string primary) 
{
    char[] chars = primary.ToCharArray();
    string final = string.Empty;
    for (int i = chars.Length-1; i >= 0; i--)
    {
        final += chars[i];
    }
    return final;
}