using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class HelpCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Выводит список команд";

        public HelpCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            _UserInterface.WriteLine("Файловый менеджер поддерживает следующие команды: ");

            foreach (var (name, command) in _FileManager.Commands)
            {
                _UserInterface.WriteLine($"    {name.PadRight(12, '-')}{command.Description}");
            }
            
        }
    }
}
