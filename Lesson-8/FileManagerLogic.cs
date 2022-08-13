using Lesson_8.Commands;
using Lesson_8.Commands.Base;

namespace Lesson_8
{
    public class FileManagerLogic
    {
        private bool _CanWork = true;
        private readonly IUserInterface _UserInterface;

        public DirectoryInfo CurrentDir { get; set; } = new("c:\\");

        public IReadOnlyDictionary<string, FMCommands> Commands { get; }

        public FileManagerLogic(IUserInterface UserInterface)
        {
            _UserInterface = UserInterface;

            var list_dir_comm = new PrintDirCommand(UserInterface, this);
            var help_comm = new HelpCommand(UserInterface, this);
            var quit_comm = new QuitCommand(this);
            Commands = new Dictionary<string, FMCommands>()
            {
                { "drives", new ListDrivesCommand(UserInterface)},
                { "dir", list_dir_comm},
                {"ListDir", list_dir_comm},
                {"ls", list_dir_comm },
                {"help", help_comm },
                {"?", help_comm },
                {"quit", quit_comm },
                {"exit", quit_comm },
            };
        }

        public void Start()
        {
            _UserInterface.WriteLine("Старт");

            do
            {
                var input = _UserInterface.ReadLine("Введите команду: ", false);

                var args = input.Split(' ');
                var command_name = args[0];

                if (!Commands.TryGetValue(command_name, out var command))
                {
                    _UserInterface.WriteLine($"Неизвестная команда {command_name}.");
                    _UserInterface.WriteLine($"Для справки введите help, для выхода quit");
                    continue;
                }
                try
                {
                    command.Execute(args);
                }
                catch(Exception ex)
                {
                    _UserInterface.WriteLine($"При выполнении команды {command_name} произошла ошибка:\n{ex.Message}");
                }

            }while (_CanWork);
        }

        public void Stop()
        {
            _CanWork = false;
        }
    }
}
