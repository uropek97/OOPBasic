﻿using Lesson_5;

var first = new RacionalNumbers(3, 5);
var second = new RacionalNumbers(7, 10);
Console.WriteLine($"Оператор: == : {first == second}");
Console.WriteLine($"Оператор: != : {first != second}");
Console.WriteLine($"Оператор: > : {first > second}");
Console.WriteLine($"Оператор: < : {first < second}");
Console.WriteLine($"Оператор: >= : {first >= second}");
Console.WriteLine($"Оператор: <= : {first <= second}");
Console.WriteLine($"Оператор -(изменение знака) : {-first}");
Console.WriteLine($"Оператор: ++ : {first++}");
Console.WriteLine($"Оператор: -- : {second--}");
Console.WriteLine($"Оператор: + : {first + second}");
Console.WriteLine($"Оператор: - : {first - second}");
Console.WriteLine($"Оператор: * : {first * second}");
Console.WriteLine($"Оператор: / : {first / second}");
Console.WriteLine($"Оператор: +(int) : {first + 2}");
Console.WriteLine($"Оператор: +(int) : {2 + first}");
Console.WriteLine($"Оператор: -(int) : {first - 3}");
Console.WriteLine($"Оператор: -(int) : {3 - first}");
Console.WriteLine($"Оператор: *(int) : {second * 5}");
Console.WriteLine($"Оператор: *(int) : {5 * second}");
Console.WriteLine($"Оператор: /(int) : {second / 4}");
Console.WriteLine($"Оператор: /(int) : {4 / second}");
float someFloat = (float)1.5;
Console.WriteLine($"Оператор: +(float) : {first + someFloat}");
Console.WriteLine($"Оператор: +(float) : {someFloat + first}");
Console.WriteLine($"Оператор: -(float) : {first - someFloat}");
Console.WriteLine($"Оператор: -(float) : {someFloat - first}");
Console.WriteLine($"Оператор: *(float) : {first * someFloat}");
Console.WriteLine($"Оператор: *(float) : {someFloat * first}");
Console.WriteLine($"Оператор: /(float) : {first / someFloat}");
Console.WriteLine($"Оператор: /(float) : {someFloat / first}");
double someDouble = 3.2;
Console.WriteLine($"Оператор: +(double) : {second + someDouble}");
Console.WriteLine($"Оператор: +(double) : {someDouble + second}");
Console.WriteLine($"Оператор: -(double) : {second - someDouble}");
Console.WriteLine($"Оператор: -(double) : {someDouble - second}");
Console.WriteLine($"Оператор: *(double) : {second * someDouble}");
Console.WriteLine($"Оператор: *(double) : {someDouble * second}");
Console.WriteLine($"Оператор: /(double) : {second / someDouble}");
Console.WriteLine($"Оператор: /(double) : {someDouble / second}");

var third = new RacionalNumbers(3, 9);
var fourth = new RacionalNumbers(1, 3);
Console.WriteLine($"== {third == fourth}");

int i = 1;
Console.WriteLine(third.Equals(i));
Console.WriteLine(fourth.Equals(third));

Console.WriteLine("END");
Console.ReadLine();
