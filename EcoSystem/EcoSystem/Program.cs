Console.WriteLine("Enter a number not to be exceeded");
var ceiling = Console.ReadLine();
if(int.TryParse(ceiling,out var top))
{
    var randy = new Random();
    for(var i=0; i<100; i++)
    {
        var rando = randy.Next(top);
        Console.WriteLine(rando);
    }
}