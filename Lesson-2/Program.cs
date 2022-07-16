using Lesson_2;

var acc = new BankAcc();
acc.SetAccType(accType.Текущий); acc.SetNumber("00001"); acc.SetBalance(99);
Console.WriteLine(acc);

Console.ReadLine();