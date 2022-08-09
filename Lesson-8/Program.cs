using Lesson_8;

var conlsole_ui = new ConsoleUserInterface();
var fileManager = new FileManagerLogic(conlsole_ui);

fileManager.Start();

Console.WriteLine("END");
Console.ReadLine();