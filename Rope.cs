using System;

class Rope
{
    public Node root;
    private string name = "";

    // Empty Rope Constructor 
    public Rope()
    {
        root = new Node();
    }

    // Rope constructor with string
    public Rope(string S)
    {
        root = new Node();
        if (S != null && S != "")
        {
            root.TotChars = S.Length;
            MakeRope(root, S);
        }

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

        // Setting the number of total characters for the current node
        root.TotChars = S.Length;

        // Split the string in half
        string sub1 = S.Substring(0, (S.Length / 2));
        string sub2 = S.Substring((S.Length / 2), S.Length - (S.Length / 2));

        // Check if the halves are less than the max
        if (sub1.Length <= 10 && sub2.Length <= 10) // If so, make them leaf nodes
        {
            root.Left = new Node(sub1);
            root.Left.TotChars = sub1.Length;
            root.Right = new Node(sub2);
            root.Right.TotChars = sub2.Length;
        }
        else // If not, call the function again for each of the substrings 
        {
            root.Left = new Node();
            root.Right = new Node();
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
        if (R2.root.TotChars == 0)
        {
            return R1;
        }
        else if (R1.root.TotChars == 0)
        {
            return R2;
        }
        else
        {
            if (Math.Abs(GetHeight(R1.root) - GetHeight(R2.root)) > 1)
            {
                string S = R1.ToString() + R2.ToString();
                //Console.WriteLine(S);
                Rope R = new Rope(S);
                return R;
            }
            else
            {
                Rope R = new Rope();
                R.root.Left = R1.root;
                R.root.TotChars = R1.Length() + R2.Length();
                R.root.Right = R2.root;
                return R;
            }
        }
    } // End of Concatenate

    /// <summary>
    /// Splits the rope into two ropes at a given index. The left part will be stored in R1
    /// and the right half will be stored in R2. The original rope will remain the same.
    /// This version of Split is in the same format as seen in the assignment 2 details.
    /// NOTE: the character found at index i will be included with the left split (R1).
    /// </summary>
    /// <param name="i">The index to be split at</param>
    /// <param name="R1">The new rope for the first part of the split</param>
    /// <param name="R2">The new rope for the second part of the split</param>
    public void Split(int i, ref Rope R1, ref Rope R2)
    {
        String thisString = this.ToString();
        if (i > 0 && i < this.Length())
        {

            String a = thisString.Substring(0, i + 1);
            String b = thisString.Substring(i + 1);
            R1 = new Rope(a);
            R2 = new Rope(b);
        }
        else
        {
            R1 = new Rope(thisString);
            R2 = new Rope();
        }


    } // End of Split

    /// <summary>
    /// Splits the rope into two parts at a given index and returns a Rope that contains 
    /// the right part that was split. The reason for this deviation is because this method will
    /// actually split the original rope and eliminates the need to provide 2 new Ropes as parameters.
    /// NOTE: the character found at index i will be excluded from the split (right part will contain i+1....n)
    /// </summary>
    /// <param name="i">The index to be split at</param>
    public Rope Split(int i)
    {
        Stack<Node> nodeStack = new Stack<Node>(); // to hold the nodes that will be split
        Node current = root; // to keep track of current node

        if ((i < 0) || (i >= root.TotChars)) return new Rope(); // index out of bounds 
        else if (current == null) return new Rope(); // rope is empty

        while (current != null && current.Data == null) // if Data is null then there MUST be a left node otherwise we done goofed
        {
            if ((i < current.Left.TotChars)) // Right node will be split and move to the left
            {
                if (current.Right != null)
                {
                    nodeStack.Push(current.Right); // push right subtree to stack
                    current.Right = null; // sever the right subtree from current
                }

                current = current.Left;
            }
            else // subtract index by the number of left chars and move right
            {
                i -= (current.Left.TotChars);
                current = current.Right;
            }

        }// end while

        // Now we should be in a leaf node containing the index
        String leftStr = current.Data.Substring(0, i + 1);
        String rightStr = current.Data.Substring(i + 1);

        if (rightStr.Length > 0) // we need to split the string into nodes
        {
            current.Data = null;
            current.Left = new Node(leftStr);
            current.TotChars = leftStr.Length;

            nodeStack.Push(new Node(rightStr));
        }

        Rope ropeRight = new Rope();
        Rope tempRope = new Rope();


        while (nodeStack.Count() > 0)
        {
            tempRope.root = nodeStack.Pop();
            ropeRight = Concatenate(ropeRight, tempRope);
            tempRope = new Rope();
        }

        tempRope = new Rope(this.ToString());
        this.root = tempRope.root;


        return ropeRight;

    } // End of Split

    /// <summary>
    /// Insert a string into the rope at a given index. 
    /// Note that the inserted string will "push" the character at index i to the right.
    /// If index is out of range, it will insert at the front/end of rope accordingly
    /// </summary>
    /// <param name="S">The string to be inserted</param>
    /// <param name="i">The integer index where the string needs to be inserted at.</param>
    public void Insert(String S, int i)
    {

        if (S != null || S == "") // do nothing to the rope if S is null of empty
        {
            Rope insertRope = new Rope(S);
            Rope tempRope = new Rope();
            tempRope.root = this.root;

            if (i <= 0) // Just concatenate at the beggining in this case
            {
                tempRope = Concatenate(insertRope, tempRope);
                this.root = tempRope.root;

            }
            else if (i >= this.root.TotChars) // concatenate at the end
            {
                tempRope = Concatenate(tempRope, insertRope);
                this.root = tempRope.root;
            }
            else // 1 split 2 concatenate
            {
                Rope rightRope = this.Split(i - 1);
                tempRope = Concatenate(tempRope, insertRope);
                tempRope = Concatenate(tempRope, rightRope);
                this.root = tempRope.root;
            }
        }


    } // End of Insert

    /// <summary>
    /// Deletes a substring from the given indexes.
    /// This method will delete characters starting at i and up to (but not including) j
    /// </summary>
    /// <param name="i">The index of the start of the substring to be deleted</param>
    /// <param name="j">The index of the end of the substring to be deleted</param>
    public void Delete(int i, int j)
    {


    } // End of Delete

    /// <summary>
    /// Finds the index of a given character
    /// </summary>
    /// <param name="root"> The root node of the given rope, passed as Rope.root in main</param>
    /// <param name="c"> The target character to find the first instance of</param>
    public int IndexOf(Node root, char c)
    {
        if (root.TotChars == 0)
        {
            return -1;
        }
        else
        {
            if (root.Left == null && root.Right == null) //check if the current node is a leaf node
            {
                for (int i = 0; i < root.Data.Length; i++) //iterate through the data in the leaf node to find the specific index of the target
                {
                    if (root.Data[i].Equals(c)) //if the target is found
                    {
                        return i; //return the index of the target
                    }
                }
                return -1; //else return -1
            }
            else //if the current node is not a leaf
            {
                int left = IndexOf(root.Left, c); //recursively call a search of the left child
                int right = IndexOf(root.Right, c); //recursively call a search of the right child
                if (left >= 0) //if the target was found in the left node
                {
                    return left; //return the location of the target
                }
                else if (right == -1) //if the target was not found in the right node
                {
                    return -1; //return -1
                }
                else //if the target was found in the right node return the target location plus the number of characters to the left
                {
                    return (right + root.Left.TotChars);
                }
            }
        }
    }

    public void Traverse(Node root)
    {
        if (root != null)
        {
            Traverse(root.Left);
            if (root.Data != null)
            {
                //Console.WriteLine(root.Data);
                name += root.Data;
            }
            Traverse(root.Right);
        }
    }

    public override string ToString()
    {
        name = "";
        if (root.TotChars != 0)
        {
            Traverse(root);
        }
        return name;
    }

    /// <summary>
    /// Gets the length of the string in the rope
    /// </summary>
    /// <returns>An integer of the length of the string in the rope</returns>
    public int Length()
    {
        return root.TotChars;
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
        int between = Convert.ToInt32(Math.Pow(2, floor + 1)) - 10;
        PrintSpaces(first);

        List<Node> newNodes = new List<Node>();
        foreach (Node node in nodes)
        {
            if (node != null)
            {
                Console.Write("{" + node.Data + " Tot: " + node.TotChars + " }");
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
