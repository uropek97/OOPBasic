using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    internal class PrintDirCommand : FMCommands
    {
        public override string? Description => "Выводит содержимое директории";
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public PrintDirCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            var dirs = _FileManager.CurrentDir;
            _UserInterface.WriteLine($"Содержимое директорий: {dirs}");

            var dirs_count = 0;
            foreach (var dir in dirs.EnumerateDirectories())
            {
                _UserInterface.WriteLine($"--d--{dir.Name}");
                dirs_count++;
            }

            var files_count = 0;
            long total_size = 0;
            foreach (var file in dirs.EnumerateFiles())
            {
                _UserInterface.WriteLine($"--f--{file.Name}\t");
                files_count++;
                total_size += file.Length;
            }

            _UserInterface.WriteLine("");
            _UserInterface.WriteLine($"Директорий: {dirs_count}, файлов: {files_count}, размер: {total_size}");

        }
    }
}
