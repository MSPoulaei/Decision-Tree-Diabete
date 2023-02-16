namespace Decision_Tree_Part2
{
    public class Node
    {
        public string Data;
        public bool isLeaf = false;
        public List<Node> children = new List<Node>();
        public void PrintPretty(string indent, bool last)
   {
       Console.Write(indent);
       if (last)
       {
           Console.Write("\\-");
           indent += "  ";
       }
       else
       {
           Console.Write("|-");
           indent += "| ";
       }
       Console.WriteLine(Data);
       if (children==null) return;
       for (int i = 0; i < children.Count; i++)
           children[i].PrintPretty(indent, i == children.Count - 1);
   }
    }
}