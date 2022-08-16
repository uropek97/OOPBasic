using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    internal class SearchCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Поиск файлов по маске(только формат, например .txt)";

        public SearchCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для поиска необходимо задать маску");
                return;
            }

            var files = Directory.GetFiles(_FileManager.CurrentDir.FullName, $"*{args[1]}", SearchOption.AllDirectories);

            foreach (var file in files)
                _UserInterface.WriteLine(file);
        }
    }
}
