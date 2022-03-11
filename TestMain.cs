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



		Rope rope2 = new Rope("Insert Here: __________");
		Console.WriteLine(rope2);
		rope2.PrintLevelOrder();

		/*Rope temp1 = new Rope();
		Rope temp2 = new Rope();

		rope2.Split(10, ref temp1, ref temp2);
		temp1.PrintLevelOrder();
		temp2.PrintLevelOrder();

		Rope splitrope = rope2.Split(10);
		Console.WriteLine(rope2);
		rope2.PrintLevelOrder();
		Console.WriteLine(splitrope);
		splitrope.PrintLevelOrder();*/

		rope2.Insert("Avery Chin", 15);
		Console.WriteLine(rope2);
		rope2.PrintLevelOrder();
	}
}
