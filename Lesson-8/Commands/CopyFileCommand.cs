using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class CopyFileCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Копирование файлов";

        public CopyFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (!(args.Length == 2 || args.Length == 3)|| string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для копирования файла необходимо указать имя файла");
                return;
            }

            var file = new FileInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));

            if (!file.Exists)
            {
                _UserInterface.WriteLine($"Файла {file} не существует");
                return;
            }

            if (args.Length == 3)
                file.CopyTo(args[2]);
            else
                file.CopyTo($"(копия){file.Name}");

        }
    }
}
