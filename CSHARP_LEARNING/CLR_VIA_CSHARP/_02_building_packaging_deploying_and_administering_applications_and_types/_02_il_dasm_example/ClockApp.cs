using System;
using ClockerLol;
using Check;

public class Program
{
	public static void Main()
	{
		Console.WriteLine(Clock.GetTime());
		Checker.Main();
		Console.ReadKey();
	}
}
