namespace Lesson_8.Commands.Base
{
    public abstract class FMCommands
    {
        public abstract string? Description { get; }

        public abstract void Execute(string[] args);
    }
}
