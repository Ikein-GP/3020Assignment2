using System;

public static class TestMain
{
	public static void Main()
	{
		Console.WriteLine("Enter the String you'd like to be a rope:");
		Rope rope = new Rope(Console.ReadLine());
		rope.PrintLevelOrder();
		Console.WriteLine("Start Traversal");
		rope.Traverse(rope.root);
		Console.WriteLine("enter the charater you'd like to find: ");
		char FindMe = Convert.ToChar(Console.ReadLine());
		int Index = rope.IndexOf(rope.root, FindMe);
		if (Index != -1)
		{
			Console.WriteLine("the first {0} is stored at index {1} of its node (index count starts at 0)", FindMe, Index);
		}
		else
        {
			Console.WriteLine("the character: {0}, is not part of this rope ", FindMe);
        }
		Console.Write("the length of the rope is: ");
		Console.WriteLine(rope.Length());
		Console.WriteLine("Please enter the rope you'd like to concatinate to the previous rope:");
		Rope rope0 = new Rope(Console.ReadLine());
		Rope rope1 = new Rope();
		Console.WriteLine("the conctinated rope is:");
		rope1 = rope1.Concatenate(rope0, rope);
		rope1.PrintLevelOrder();
		Console.WriteLine("enter the index you'd like to veiw:");
		Console.WriteLine("The letter at that index is {0}",
		rope.CharAt(rope.root, Convert.ToInt32(Console.ReadLine())));
		rope.Reverse();
		rope.PrintLevelOrder();
	}
}
