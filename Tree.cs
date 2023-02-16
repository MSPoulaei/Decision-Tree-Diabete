namespace Decision_Tree_Part2
{
    public class Tree
    {
        public Node Root;
        public bool Classify(Diabete res)
        {
            var current = Root;
            while (!current.isLeaf)
            {
                var att = current.Data;
                var att_m = DiabeteModel.Attributes.First(a => a.name == att);
                double val = (double)TreeBuilder.GetPropValue(res, att);
                int index = att_m.choices - 1;
                for (int i = 0; i < att_m.choices; i++)
                {
                    if (val < att_m.ranges[i])
                    {
                        index = i;
                        break;
                    }
                }
                current = current.children[index];
            }
            return bool.Parse(current.Data);
        }
    }
}