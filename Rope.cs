using System;

class Rope 
{
    public Node root;

    public Rope() 
    {
        root = new Node();
    }

    void Insert(String S, int i) 
    {
        Node current = root;
        if (S.Length > 10) //if the given string is too long
        {
            Console.WriteLine("String must be 10 characters or less");
        }
        else if (current.LeftChars == 0) //check to see if the rope is empty
        {
            root.Left = new Node(S); //if the rope is empty the specified index is irrelevant and the new node should just go to the left
            root.LeftChars = S.Length;
        }
        while (current.Left != null) 
        {
            if (current.LeftChars > i) 
            {
                i = i - current.LeftChars;
                if (current.Right == null)
                {
                    current.Right = new Node(S);
                }
                else
                {
                    current = current.Right;
                }
            }
        }
    }

}
