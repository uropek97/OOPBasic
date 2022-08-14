using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class DeleteDirCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Удаление директорий";

        public DeleteDirCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для удаления директории необходимо указать имя каталога, который необходимо удалить");
                return;
            }
            var dir = new DirectoryInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));
            if (!dir.Exists)
            {
                _UserInterface.WriteLine($"Директории {dir} не существует");
                return;
            }
            try
            {
                if (Directory.EnumerateFiles(dir.FullName, "*.*").Any())
                {
                    _UserInterface.WriteLine($"Директория {dir} содержит другие директории или файлы. Вы уверены что её нужно удалить?");
                    string input;
                    do
                        input = _UserInterface.ReadLine("Y/N : ", false);
                    while (input.ToLower() != "y" && input.ToLower() != "n");
                    if (input == "y")
                        dir.Delete(true);
                    else
                        return;
                }
                else
                    dir.Delete();

            }
            catch (Exception error)
            {
                _UserInterface.WriteLine(error.Message);
                return;
            }
        }
    }
}
