namespace Lesson_8
{
    internal interface IUserInterface
    {
        void Write(string message);
        void WriteLine(string message);
        string ReadLine(string? Prompt, bool some = true);
    }
}
