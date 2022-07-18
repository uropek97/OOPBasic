Console.Write("Введите строку: ");
Console.WriteLine(ReverseString(Console.ReadLine()!));
string nameFile = "data.txt";
if (!File.Exists(nameFile))
{
    var fileWrite = new StreamWriter(nameFile);
    var datastr = "Кучма Андрей Витальевич & Kuchma@mail.ru\nМизинцев Павел Николаевич & Pasha@mail.ru";
    fileWrite.WriteLine(datastr);
    fileWrite.Close();
}
var mailsName = "mails.txt";
if (!File.Exists(mailsName))
{
    StreamReader reader = new StreamReader(nameFile);
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
        SearchMail(ref line);
        File.AppendAllText(mailsName, line + "\n");
    }
}

Console.WriteLine("Завершение программы...");
Console.ReadLine();

static string ReverseString(string primary)
{
    char[] chars = primary.ToCharArray();
    string final = string.Empty;
    for (int i = chars.Length - 1; i >= 0; i--)
    {
        final += chars[i];
    }
    return final;
}
//из предложенной строки ФИО $ mail возвращаем только mail.
void SearchMail(ref string s)
{
    var str_arr = s.Split('&');
    s = str_arr[1].Trim(' ');
}