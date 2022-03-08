using System;

public static class TestMain
{
	public static void Main()
	{
		Rope rope0 = new Rope("This is a test");
		rope0.PrintLevelOrder();
		Rope rope = new Rope("This is a test rope. Testing123. I am a test. Testing is fun!");
		rope.PrintLevelOrder();
		Console.WriteLine("Start Traversal");
		rope.Traverse(rope.root);
		int Index = rope.IndexOf(rope.root, '2');
		Console.WriteLine("the first o is stored at index {0} of its node", Index);
		Console.WriteLine(rope.Length());
		Rope rope1 = new Rope();
		//rope1 = rope1.Concatenate(rope0, rope);
		rope1.PrintLevelOrder();
	}
}
