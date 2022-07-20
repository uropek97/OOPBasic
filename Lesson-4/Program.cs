using Building;

Creator.CreatorBuild();
Creator.CreatorBuild(10, 4);
Creator.CreatorBuild(10, 4, 160);
Creator.CreatorBuild(30, 10, 4, 160);
Console.WriteLine(Creator.PrintTable());
Creator.DeleteBuild(3);
Console.WriteLine(Creator.PrintTable());
Console.Write("Удалить конкретный дом: ");
uint.TryParse(Console.ReadLine(), out uint key);
Creator.DeleteBuild(key);
Console.WriteLine(Creator.PrintTable());

Console.WriteLine("Завершение программы...");
Console.ReadLine();
