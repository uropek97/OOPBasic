using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class ChangeDirCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Изменение текущий директории";

        public ChangeDirCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для смены каталога необходимо указать целевой каталог");
                return;
            }

            var dir_path = args[1];

            DirectoryInfo dir;

            if(dir_path == "..")
            {
                dir = _FileManager.CurrentDir.Parent!;
                if(dir is null)
                {
                    _UserInterface.WriteLine("Невозможно подняться по дереву каталогов");
                    return;
                }
            }
            else if(!Path.IsPathRooted(dir_path))
                dir_path = Path.Combine(_FileManager.CurrentDir.FullName, dir_path);
            dir = new DirectoryInfo(dir_path);

            if (!dir.Exists)
            {
                _UserInterface.WriteLine($"Директория {dir} не существует");
            }

            _FileManager.CurrentDir = dir;

            _UserInterface.WriteLine($"Директория изменена на {dir.FullName}");

            Directory.SetCurrentDirectory(dir.FullName);
        }

    }
}
