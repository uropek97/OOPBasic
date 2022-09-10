using Lesson_8;
using Lesson_8.Commands;

var conlsole_ui = new ConsoleUserInterface();
var fileManager = new FileManagerLogic(conlsole_ui);


fileManager.Start();

Console.WriteLine("END");
Console.ReadLine();