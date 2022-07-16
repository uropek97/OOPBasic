using Lesson_2;

var acc = new BankAcc();
acc.SetAccType(accType.Текущий); acc.SetNumber("0000001"); acc.SetBalance(99);
Console.WriteLine(acc);
var acc2 = new BankAcc();
acc2.SetAccType(accType.Накопительный); acc2.SetNumber(); acc2.SetBalance(3);
Console.WriteLine(acc2);
Console.ReadLine();