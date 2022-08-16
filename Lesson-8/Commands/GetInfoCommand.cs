using Lesson_8.Commands.Base;

namespace Lesson_8.Commands
{
    public class GetInfoCommand : FMCommands
    {
        private readonly IUserInterface _UserInterface;
        private readonly FileManagerLogic _FileManager;

        public override string? Description => "Получение информации о текстовом файле";

        public GetInfoCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
        {
            _UserInterface = UserInterface;
            _FileManager = FileManager;
        }

        public override void Execute(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                _UserInterface.WriteLine("Для получения информации, необходимо указать имя текстового файла файла");
                return;
            }

            var file = new FileInfo(Path.Combine(_FileManager.CurrentDir.FullName, args[1]));

            if (file.Exists)
            {
                if(file.Extension != ".txt")
                {
                    _UserInterface.WriteLine("Для получения информации, необходимо указать имя текстового файла файла");
                    return;
                }                   
            }
            else
            {
                _UserInterface.WriteLine($"Файда {file} не существует.");
                return;
            }

            int count_words = 0;
            int count_lines = 0;
            int count_symbols = 0;

            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var arr = line.Split();
                    count_words += arr.Length;
                    count_lines++;
                    count_symbols += line.Length;
                }
            }

            _UserInterface.WriteLine($"В файле содержится {count_words} слов, {count_lines} строк, {count_symbols} символов");
        }
    }
}
