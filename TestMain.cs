// Team: Greg Prouty, Bradley Primeau, Avery Chin, Megan Risebrough
using System;

public static class TestMain
{
	public static void Main()
	{
		/* --------------------------------------------------------
		| Rope Constructor Tests
		---------------------------------------------------------*/
		/*// Test 0 parameter constructor
		Rope rope = new Rope();
		rope.PrintLevelOrder();

		// Test string of 0 characters
		Rope rope0 = new Rope("");
		rope0.PrintLevelOrder();

		// Test string of 1 character
		Rope rope1 = new Rope("T");
		rope1.PrintLevelOrder();

		// Test string of several characters
		Rope rope2 = new Rope("This_is_a_test_rope._Testing123.");
		rope2.PrintLevelOrder();*/

		/* --------------------------------------------------------
		| Concatenate Tests
		---------------------------------------------------------*/

		/*// Both Empty
		rope = rope.Concatenate(rope1, rope2);
		rope.PrintLevelOrder();

		// First One Empty
		rope = rope.Concatenate(rope0, rope2);
		rope.PrintLevelOrder();

		// Second One Empty
		rope = rope.Concatenate(rope2, rope0);
		rope.PrintLevelOrder();

		// None Empty
		rope = rope.Concatenate(rope, rope2);
		rope.PrintLevelOrder();*/

		/* --------------------------------------------------------
		| Split Tests
		---------------------------------------------------------*/

		Rope rope3 = new Rope("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
		Console.WriteLine(rope3);
		rope3.PrintLevelOrder();

		/*Rope temp1 = new Rope();
		Rope temp2 = new Rope();

		// First Split method of invalid index
		rope3.Split(-1, ref temp1, ref temp2);
		Console.WriteLine(temp1);
		temp1.PrintLevelOrder();
		Console.WriteLine(temp2);
		temp2.PrintLevelOrder();

		// First Split method of valid index
		rope3.Split(10, ref temp1, ref temp2);
		Console.WriteLine(temp1);
		temp1.PrintLevelOrder();
		Console.WriteLine(temp2);
		temp2.PrintLevelOrder();*/

		//-----------------------------------------------------------

		// Second Split method of invalid index
		Console.WriteLine(rope3);
		Rope splitrope = rope3.Split(-1);
		Console.WriteLine(rope3);
		rope3.PrintLevelOrder();
		Console.WriteLine(splitrope);
		splitrope.PrintLevelOrder();

		// Second Split method of valid index
		Console.WriteLine(rope3);
		Rope splitrope2 = rope3.Split(1);
		Console.WriteLine(rope3);
		rope3.PrintLevelOrder();
		Console.WriteLine(splitrope2);
		splitrope2.PrintLevelOrder(); 

		/* --------------------------------------------------------
		| Insert Tests
		---------------------------------------------------------*/

		/*rope2.Insert("Avery Chin", 15);
		Console.WriteLine(rope2);
		rope2.PrintLevelOrder();*/

		/* --------------------------------------------------------
		| Delete Tests
		---------------------------------------------------------*/

		/* --------------------------------------------------------
		| Substring Tests
		---------------------------------------------------------*/
		/*Rope rope4 = new Rope("xxxDELETE");
		Console.WriteLine(rope4);
		rope4.PrintLevelOrder();

		// Invalid index
		Console.WriteLine(rope4.Substring(6, 900));
		Console.WriteLine(rope4);
		rope4.PrintLevelOrder();

		// Valid index
		Console.WriteLine(rope4.Substring(6, 9));
		Console.WriteLine(rope4);
		rope4.PrintLevelOrder();*/

		/* --------------------------------------------------------
		| CharAt Tests
		---------------------------------------------------------*/
		/*
		rope.PrintLevelOrder();
		Console.WriteLine("enter the index you'd like to veiw:");
		Console.WriteLine("The letter at that index is {0}",
		rope.CharAt(rope.root, Convert.ToInt32(Console.ReadLine())));
		*/

		/* --------------------------------------------------------
		| Insert Tests
		---------------------------------------------------------*/

		/* --------------------------------------------------------
		| IndexOf Tests
		---------------------------------------------------------*/

		// Valid index
		//Console.WriteLine("the first o is stored at index {0}", rope.IndexOf(rope.root, 'o'));

		/* --------------------------------------------------------
		| Reverse Tests
		---------------------------------------------------------*/

		/*
		Console.WriteLine(rope2);
		rope2.PrintLevelOrder();
		rope2.Reverse();
		Console.WriteLine(rope2);
		rope2.PrintLevelOrder();
		*/

		/* --------------------------------------------------------
		| Length Tests
		---------------------------------------------------------*/

		// Empty rope
		/*Console.WriteLine(rope0.Length());

		// Not Empty rope
		Console.WriteLine(rope2.Length());*/

		/* --------------------------------------------------------
		| PrintRope Tests
		---------------------------------------------------------*/

		/*rope2.PrintLevelOrder();
		rope2.PrintRope();*/
	}
}
