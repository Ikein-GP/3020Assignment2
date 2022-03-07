using System;

public static class TestMain
{
	public static void Main()
	{
		Rope rope0 = new Rope("This is a test");
		rope0.PrintLevelOrder();
		Rope rope = new Rope("This is a test rope. Testing123. I am a test. Testing is fun!");
		rope.PrintLevelOrder();
		Console.WriteLine(rope.Length());
		Rope rope1 = new Rope();
		rope1 = rope1.Concatenate(rope0, rope);
		rope1.PrintLevelOrder();
	}
}
