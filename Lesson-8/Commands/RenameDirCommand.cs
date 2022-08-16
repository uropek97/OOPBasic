using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class RenameDirCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Изменение имени директории";

        public RenameDirCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 3 || string.IsNullOrWhiteSpace(args[1]) || string.IsNullOrWhiteSpace(args[2]))
            {
                _UserInterface.WriteLine("Для переименования директории необходимо указать текущее имя директории и имя, на которое необходимо изменить");
                return;
            }

            var dir = new DirectoryInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));

            if (!dir.Exists)
            {
                _UserInterface.WriteLine($"Директории {dir} не существует");
                return;
            }

            var newdir = new DirectoryInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[2]));

            if (dir.Parent.Name != newdir.Parent.Name)
            {
                _UserInterface.WriteLine($"Команда {args[0]} предназначена для переименования директорий. Для перемещения воспользуйтесь другой командрой.");
                _UserInterface.WriteLine($"Чтобы узнать все команды введите help");
                return;
            }

            Directory.Move(dir.FullName, args[2]);

        }
    }
}

