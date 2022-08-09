namespace Lesson_8
{
    internal class ConsoleUserInterface : IUserInterface
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine(string? prompt, bool some = true)
        {
            if(prompt is { Length: > 0})
            if (some)
                this.WriteLine(prompt);
            else
                this.Write(prompt);
            return Console.ReadLine()!;
        }
    }
}
