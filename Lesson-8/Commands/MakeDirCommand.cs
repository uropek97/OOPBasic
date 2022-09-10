using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class MakeDirCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Создаёт директорию";

        public MakeDirCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для создания каталога необходимо указать имя каталога");
                return;
            }

            Directory.CreateDirectory(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));

        }
    }
}
