using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class MoveDirCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Перемещение директорий";

        public MoveDirCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 3 || string.IsNullOrWhiteSpace(args[1]) || string.IsNullOrWhiteSpace(args[2]))
            {
                _UserInterface.WriteLine("Для перемещения директории необходимо указать имя директории и путь, куда необходимо её переместить");
                return;
            }

            var dir = new DirectoryInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));

            if (!dir.Exists)
            {
                _UserInterface.WriteLine($"Директории {dir} не существует");
                return;
            }

            var arr = args[1].Split('\\');
            args[2] += $"\\{arr[arr.Length - 1]}";

            try
            {
                dir.MoveTo(args[2]);
            }
            catch(Exception error)
            {
                _UserInterface.WriteLine(error.Message);
                return;
            }
        }
    }
}
