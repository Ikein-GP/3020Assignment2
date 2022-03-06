using System;
using System.Collections.Generic;
class Node
{
    public string? Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public int LeftChars { get; set; }

    public Node() 
    {
        LeftChars = 0;
    }

    public Node(string data) 
    {
        Data = data;
        LeftChars = 0;
    }
}

