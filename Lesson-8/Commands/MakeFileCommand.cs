using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class MakeFileCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Создание нового файла";

        public MakeFileCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для создания файла необходимо указать имя файла");
                return;
            }

            using (File.Create(Path.Combine(_FileManager.CurrentDir.FullName, args[1]))) ;

        }
    }
}
