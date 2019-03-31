using System;
					
public class Program
{
	public static void Main()
	{
	    int n = int.Parse(Console.ReadLine());
		Console.WriteLine(ChekNum(n));
	}
	public static  string ChekNum(int a)
	{
		int res = 0;
		for(int i = 1; i <= a; i ++)
		{
			if(a%i == 0)
			{
				res++;
			}
		}
		if(res == 2)
		{
			return "prime";
		}
		else
		{
			return "composite";
		}
	}
}