using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class CopyDirCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Копирование директорий";

        public CopyDirCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (!(args.Length == 2 || args.Length == 3) || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для копирования файла необходимо указать имя файла");
                return;
            }

            var dir = new DirectoryInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));

            if (!dir.Exists)
            {
                _UserInterface.WriteLine($"Директории {dir} не существует");
                return;
            }

            var files = Directory.GetFiles(dir.Name);

            if (args.Length == 3)
                CopyDir(args[1], args[2]);
            else
                CopyDir(args[1], $"{args[1]}(копия)");


        }

        public void CopyDir(string fromDir, string toDir)
        {
            Directory.CreateDirectory(toDir);

            foreach (string fileName in Directory.GetFiles(fromDir))
            {
                string path = $"{toDir}\\{Path.GetFileName(fileName)}";
                File.Copy(fileName, path);
            }
            foreach (string dirName in Directory.GetDirectories(fromDir))
                CopyDir(dirName, $"{toDir}\\{Path.GetFileName(dirName)}");
        }
    }
}
