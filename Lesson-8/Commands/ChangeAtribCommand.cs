using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class ChangeAttribCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Изменение аттрибутов";

        public ChangeAttribCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для смены аттрибутов, необходимо указать имя файла");
                return;
            }

            var file = new FileInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));
            _UserInterface.WriteLine($"Текущие арттрибуты: {file.Attributes.ToString()}");

            _UserInterface.WriteLine("Установить аттрибут: \n1: Hidden \n2: ReadOnly \n3: Перейти к удалению атрибутов \n0: Отмена"); // добавляю только 2 аттрибута в учебных целях. с остальными аттрибутами такая же логика
            string input;
            do
                input = _UserInterface.ReadLine("0-3: ", false);
            while (input != "0" && input != "1" && input != "2" && input != "3");

            if (input == "0")
                return;
            else if (input == "1")
                file.Attributes |= FileAttributes.Hidden;
            else if (input == "2")
                file.Attributes |= FileAttributes.ReadOnly;
            else
            {
                file.Attributes &= ~FileAttributes.ReadOnly;
                file.Attributes &= ~FileAttributes.Hidden;
            }    

        }
    }
}
