namespace Lesson_8.Commands.Base
{
    public abstract class FMCommands
    {
        public abstract string? Title { get; }

        public abstract void Execute(string[] args);
    }
}
