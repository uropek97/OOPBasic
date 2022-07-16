using Lesson_2;

var acc = new BankAcc();
var acc2 = new BankAcc(100);
var acc3 = new BankAcc(accType.Общий);
var acc4 = new BankAcc(200, accType.Текущий);
Console.WriteLine($"1: {acc}");
Console.WriteLine($"2: {acc2}");
Console.WriteLine($"3: {acc3}");
Console.WriteLine($"4: {acc4}");
var acc5 = new BankAcc(500, accType.Валютный);
Console.WriteLine($"5: {acc5}");

Console.ReadLine();