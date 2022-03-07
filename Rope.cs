using System;

class Rope 
{
    public Node root;
    private int length=0;

    // Empty Rope Constructor 
    public Rope() 
    {
        root = new Node();
    }

    // Rope constructor with string
    public Rope(string S)
    {
        root = new Node();
        length = S.Length;
        MakeRope(root, S);
    }

    /// <summary>
    /// Used to recursively create a rope based on the string. Only called by the 
    /// Rope constructor.
    /// </summary>
    /// <param name="root">Root of the rope to be created</param>
    /// <param name="S">The string to be made into a rope</param>
    /// <returns></returns>
    private Node MakeRope(Node root, string S)
    {
        // Split the string in half
        string sub1 = S.Substring(0, (S.Length / 2));
        string sub2 = S.Substring((S.Length / 2), S.Length-(S.Length / 2));

        // Setting the number of left characters for the current node
        root.Data = S.Length.ToString();
        root.LeftChars = sub1.Length;

        // Check if the halves are less than the max
        if (sub1.Length <= 10 && sub2.Length <= 10) // If so, make them leaf nodes
        {
            root.Left = new Node(sub1);
            root.Right = new Node(sub2);
        }
        else // If not, call the function again for each of the substrings 
        {
            root.Left = new Node(sub1.Length.ToString());
            root.Right = new Node(sub2.Length.ToString());
            root.Left = MakeRope(root.Left, sub1);
            root.Right = MakeRope(root.Right, sub2);
        }

        return root;
    } // End of MakeRope

    // Note: needs to be optimized
    /// <summary>
    /// Concatenate two ropes into one.
    /// </summary>
    /// <param name="R1">The first rope to be combined</param>
    /// <param name="R2">The second rope to be combined</param>
    /// <returns>The rope containing the two ropes</returns>
    public Rope Concatenate(Rope R1, Rope R2)
    {
        Rope R = new Rope();
        R.root.Left = R1.root;
        R.root.Right = R2.root;
        return R;
    } // End of Concatenate

    /// <summary>
    /// Splits a rope into two ropes at a given index.
    /// </summary>
    /// <param name="i">The index to be split at</param>
    /// <param name="R1">The new rope for the first part of the split</param>
    /// <param name="R2">The new rope for the second part of the split</param>
    public void Split(int i, Rope R1, Rope R2)
    {

    } // End of Split

    /// <summary>
    /// Insert a string into a rope with a given index
    /// </summary>
    /// <param name="S">The string to be inserted</param>
    /// <param name="i">The integer index where the string needs to be inserted at.</param>
    public void Insert(String S, int i) 
    {
        Rope R1 = new Rope(S);
        
    } // End of Insert

    /// <summary>
    /// Deletes a substring from the given indexes
    /// </summary>
    /// <param name="i">The index of the start of the substring to be deleted</param>
    /// <param name="j">The index of the end of the substring to be deleted</param>
    public void Delete(int i, int j)
    {

    } // End of Delete

    /// <summary>
    /// Gets the length of the string in the rope
    /// </summary>
    /// <returns>An integer of the length of the string in the rope</returns>
    public int Length()
    {
        return length;
    }// End of Length


    //-----------------------------------------------------------------------------------
    // Stupid printing for testing
    //-----------------------------------------------------------------------------------
    // Calculates and returns the height of the tree
    public int GetHeight(Node current)
    {
        int height = 0;
        if (current != null)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int m = Math.Max(l, r);
            height = m + 1;
        }
        return height;

    }// end GetHeight

    // Calculates and returns the balance factor of the tree to determine how it needs to be balanced
    public int Balance_factor(Node current)
    {
        int l = GetHeight(current.Left);
        int r = GetHeight(current.Right);
        int b_factor = l - r;
        return b_factor;

    }// end Balance_Factor

    //Level order traversal repurposed from http://www.geeksforgeeks.org/level-order-tree-traversal/
    public void PrintLevelOrder()
    {
        int treeHeight = GetHeight(root);
        List<Node> nodes = new List<Node>();
        nodes.Add(root);
        Console.WriteLine();
        PrintGivenLevel(nodes, 1, treeHeight);

    }// end PrintLevelOrder

    // Print tree repurposed from https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.exists?view=netcore-3.1
    // Displays the tree like how it would be drawn
    public void PrintGivenLevel(List<Node> nodes, int level, int height)
    {
        if (nodes.Count == 0 || nodes.TrueForAll(x => x == null))
            return;
        int floor = height - level;
        int edge = Convert.ToInt32(Math.Pow(2, (Math.Max(floor - 1, 0))));
        int first = Convert.ToInt32(Math.Pow(2, floor)) - 1;
        int between = Convert.ToInt32(Math.Pow(2, floor + 1)) - 1;
        PrintSpaces(first);

        List<Node> newNodes = new List<Node>();
        foreach (Node node in nodes)
        {
            if (node != null)
            {
                Console.Write(node.Data + " L: " + node.LeftChars);
                newNodes.Add(node.Left);
                newNodes.Add(node.Right);
            }
            else
            {
                newNodes.Add(null);
                newNodes.Add(null);
                Console.Write(" ");
            }

            PrintSpaces(between);
        }
        Console.WriteLine();

        for (int i = 1; i <= edge; i++)
        {
            for (int j = 0; j < nodes.Count; j++)
            {
                PrintSpaces(first - i);
                if (nodes[j] == null)
                {
                    PrintSpaces(edge + edge + i + 1);
                    continue;
                }

                if (nodes[j].Left != null)
                    Console.Write("/");
                else
                    PrintSpaces(1);

                PrintSpaces(i + i);

                if (nodes[j].Right != null)
                    Console.Write("\\");
                else
                    PrintSpaces(1);

                PrintSpaces(edge + edge - i);
            }

            Console.WriteLine();
        }

        PrintGivenLevel(newNodes, level + 1, height);

    }// end PrintGivenLevel

    // Used for tree displaying, prints the specified amount of spaces
    private void PrintSpaces(int count)
    {
        if (count > 0)
        {
            string temp = new string(' ', count);//formatting
            Console.Write(temp);//the formatting being printed
        }
    }// end PrintSpaces

}
