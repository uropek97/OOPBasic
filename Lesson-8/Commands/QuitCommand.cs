using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    internal class QuitCommand : FMCommands
    {
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Выход";

        public QuitCommand(FileManagerLogic FileManager) => _FileManager = FileManager;

        public override void Execute(string[] args)
        {
            _FileManager.Stop();
        }
    }
}
