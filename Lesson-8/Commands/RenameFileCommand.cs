using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class RenameFileCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Изменение имени файла";

        public RenameFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 3 || string.IsNullOrWhiteSpace(args[1]) || string.IsNullOrWhiteSpace(args[2]))
            {
                _UserInterface.WriteLine("Для переименования файла необходимо указать текущее имя файла и имя, на которое необходимо изменить");
                return;
            }
            var file = new FileInfo(args[1]);

            if (!File.Exists(args[1]))
            {
                _UserInterface.WriteLine($"Файл {file} не существует");
                return;
            }

            File.Move(file.Name, args[2]);

        }
    }
}
