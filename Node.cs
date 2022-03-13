// Team: Greg Prouty, Bradley Primeau, Avery Chin, Megan Risebrough
using System;
using System.Collections.Generic;
class Node
{
    public string? Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public int TotChars { get; set; }

    public Node() 
    {
        TotChars = 0;
    }

    public Node(string data) 
    {
        Data = data;
        TotChars = data.Length;
    }
}

