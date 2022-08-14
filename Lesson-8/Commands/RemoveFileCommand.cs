using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class RemoveFileCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Удаление файлов";

        public RemoveFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для удаления файлов необходимо указать имя файла, который необходимо удалить");
                return;
            }

            var file = new FileInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));
            if (!file.Exists)
            {
                _UserInterface.WriteLine($"Файла {file} не существует");
                return;
            }
            try
            {
                _UserInterface.WriteLine($"Файл{file} невозможно будет восстановить. Вы уверены что его нужно удалить?");
                string input;
                do
                    input = _UserInterface.ReadLine("Y/N : ", false);
                while (input.ToLower() != "y" && input.ToLower() != "n");
                if (input == "y")
                    file.Delete();
            }
            catch(Exception error)
            {
                _UserInterface.WriteLine(error.Message);
                return;
            }
        }
    }
}
