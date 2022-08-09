namespace Lesson_8
{
    internal class FileManagerLogic
    {
        private readonly IUserInterface _UserInterface;

        public FileManagerLogic(IUserInterface UserInterface)
        {
            _UserInterface = UserInterface;
        }

        public void Start()
        {
            _UserInterface.WriteLine("Старт");

            var work = true;
            do
            {
                var input = _UserInterface.ReadLine("Введите команду: ", false);

                if(input == "quit")
                    work = false;
                _UserInterface.WriteLine($"Введена команда: {input}");

            }while (work);
        }
    }
}
