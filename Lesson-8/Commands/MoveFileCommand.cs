using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class MoveFileCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Перемещение файлов";

        public MoveFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 3 || string.IsNullOrWhiteSpace(args[1]) || string.IsNullOrWhiteSpace(args[2]))
            {
                _UserInterface.WriteLine("Для перемещения файла необходимо указать имя файла и путь, куда необходимо его переместить");
                return;
            }

            var file = new FileInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));

            if (!file.Exists)
            {
                _UserInterface.WriteLine($"Файла {file} не существует");
                return;
            }

            var arr = args[1].Split('\\');
            args[2] += $"\\{arr[arr.Length - 1]}";

            file.MoveTo(args[2], false);

        }
    }
}
