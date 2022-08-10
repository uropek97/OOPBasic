namespace Lesson_8
{
    public interface IUserInterface
    {
        void Write(string message);
        void WriteLine(string message);
        string ReadLine(string? Prompt, bool some = true);
    }
}
