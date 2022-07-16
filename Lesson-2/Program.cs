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
acc5.PutMoney(100);
BankAcc.PrintChange(true);
Console.WriteLine(acc5);
BankAcc.PrintChange(acc5.WithdrawMonye(700));
Console.WriteLine(acc5);
BankAcc.PrintChange(acc5.WithdrawMonye(200));
Console.WriteLine(acc5);
Console.WriteLine("Перевод со счёта 5 на счёт 4.");
acc4.TransferMoney(acc5, 50);
Console.WriteLine($"Баланс 4: {acc4.Balance}");
Console.WriteLine($"Баланс 5: {acc5.Balance}");

Console.ReadLine();