﻿using Lesson_8.Commands;
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
            var delete_dir_comm = new DeleteDirCommand(UserInterface, this);
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
                {"cd", new ChangeDirCommand(UserInterface, this) },
                {"mkdir", new MakeDirCommand(UserInterface, this) },
                {"touch", new MakeFileCommand(UserInterface, this) },
                {"delete", delete_dir_comm },
                {"-d", delete_dir_comm },
                {"remove", new RemoveFileCommand(UserInterface, this) },
                {"renamedir", new RenameDirCommand(UserInterface, this) },
                {"renamefile", new RenameFileCommand(UserInterface, this) },
                {"movedir", new MoveDirCommand(UserInterface, this) },
                {"movefile", new MoveFileCommand(UserInterface, this) },
                {"copyfile", new CopyFileCommand(UserInterface, this) },
                {"copydir", new CopyDirCommand(UserInterface, this) },
                {"search", new SearchCommand(UserInterface, this) },
                {"attribute", new ChangeAttribCommand(UserInterface, this) },
                {"getinfo", new GetInfoCommand(UserInterface, this) },
            };
        }

        public void Start()
        {
            _UserInterface.WriteLine("Старт");

            Directory.SetCurrentDirectory(CurrentDir.FullName);

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
