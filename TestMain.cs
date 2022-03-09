using System;

public static class TestMain
{
	public static void Main()
	{
		Rope rope0 = new Rope("This is a test");
		rope0.PrintLevelOrder();
		//Rope rope = new Rope("This_is_a_test_rope._Testing123.");
		Rope rope = new Rope();
		rope.PrintLevelOrder();
		Console.WriteLine("Start Traversal");
		rope.Traverse(rope.root);
		int Index = rope.IndexOf(rope.root, 'o');
		Console.WriteLine("the first o is stored at index {0} of its node", Index);
		Console.WriteLine(rope.Length());
		Rope rope1 = new Rope();
		rope1 = rope1.Concatenate(rope0, rope);
		rope1.PrintLevelOrder();
	}
}
