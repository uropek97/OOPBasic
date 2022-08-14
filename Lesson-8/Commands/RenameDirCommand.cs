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

            var arr = dir.FullName.Split('\\');
            var newArr = args[2].Split('\\');//это нужно на случай если в обоих случаях указаные полные пути, в случае если нет, то у нас будет в новых переменных тот же самый элемент
            arr[arr.Length - 1] = newArr[arr.Length-1];
            var newPath = string.Join(null, arr);

            try
            {
                Directory.Move(dir.FullName, newPath);
            }
            catch(Exception error)
            {
                _UserInterface.Write(error.Message);
                return;
            }
        }
    }
}

