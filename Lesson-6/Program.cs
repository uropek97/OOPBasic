using Lesson_6;

var point1 = new Point(false, "малиновый", 5, 6);
Console.WriteLine(point1);
point1.Move(-5, -6);
Console.WriteLine(point1);
var point2 = new Point(10, 20);
Console.WriteLine(point2);
point2.Move(10, -10);
Console.WriteLine(point2);


var circle1 = new Circle(true, "пурпурный", 20, 20, 7.5);
Console.WriteLine(circle1);
circle1.Move(10, -10);
Console.WriteLine(circle1);
var circle2 = new Circle(0, 0, 15);
Console.WriteLine(circle2);
circle2.Move(100, 1571);
Console.WriteLine($"Площадь 1 круга: {circle1.CalcSqure()}");
Console.WriteLine($"Площадь 2 круга: {circle2.CalcSqure()}");

var rect1 = new Rectangle(true, "розовый", 10, 15, 40, 40);
Console.WriteLine(rect1);
Console.WriteLine($"Центр: {rect1.Center}");
rect1.Move(10, 15);
Console.WriteLine(rect1);
Console.WriteLine($"Центр: {rect1.Center}");
var rect2 = new Rectangle(25, -25, 5, 2);
Console.WriteLine(rect2);
Console.WriteLine($"Центр: {rect2.Center}");
rect2.Move(-25, 25);
Console.WriteLine(rect2);
Console.WriteLine($"Центр: {rect2.Center}");
Console.WriteLine($"Площадь 1 квадрата: {rect1.CalcSqure()}");
Console.WriteLine($"Площадь 2 квадрата: {rect2.CalcSqure()}");

point2.ChangeVisible(); 
point2.ChangeColor("чёрный");
Console.WriteLine(point2);

circle2.ChangeVisible();
circle2.ChangeColor("чёрный");
Console.WriteLine(circle2);

rect2.ChangeVisible();
rect2.ChangeColor("чёрный");
Console.WriteLine(rect2);

Console.WriteLine("END");
Console.ReadLine();