using Lesson_7;

var acoder = new ACoder("АбCdЕXyZЪыьЭЮяёёё");
var test1 = acoder.Encode();
var test2 = acoder.Decode();

var bcoder = new BCoder("АбCdЕXyZЪыьЭЮяёёё");
var test3 = bcoder.Encode();
var test4 = bcoder.Decode();


Console.WriteLine("END");
Console.ReadLine();