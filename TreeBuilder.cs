namespace Decision_Tree_Part2
{
    public class TreeBuilder
    {
        List<DiabeteModel> learningSet;
        List<Attribute> attributes;

        public Node BuildTree()
        {
            return buildTree(learningSet, attributes);
        }
        Node buildTree(List<DiabeteModel> learningSet, List<Attribute> attributes)
        {
            // if (attributes.Count == 0)
            // {//example is empty

            // }
            Attribute att = attributes.MaxBy(a => Gain(learningSet, a));
            List<Node> children = new List<Node>();
            int p = learningSet.Count(s => s.Output);
            int n = learningSet.Count - p;
            if (p == 0 || n == 0)
            {
                return new Node()
                {
                    Data = p >= n ? "True" : "False",
                    isLeaf = true,
                    children = null
                };
            }
            var remaining_att = attributes.Where(a => a.name != att.name).ToList();
            for (int i = 0; i < att.choices; i++)
            {
                var exs = learningSet.Where(s => (int)GetPropValue(s, att.name) == i).ToList();
                Node child;
                // int pk=exs.Count(s => s.Output);
                // int nk=exs.Count-pk;
                if (exs.Count == 0 || remaining_att.Count == 0)
                {
                    child = new Node()
                    {
                        Data = p >= n ? "True" : "False",
                        isLeaf = true,
                        children = null
                    };
                }
                // else if (pk == 0 || nk == 0)
                // {
                //     child=new Node()
                //     {
                //         Data = pk >= nk ? "True" : "False",
                //         isLeaf = true,
                //         children = null
                //     };
                // }
                else child = buildTree(exs, remaining_att);

                children.Add(child);
            }
            return new Node()
            {
                Data = att.name,
                children = children
            };
        }
        public TreeBuilder(List<DiabeteModel> learningSet)
        {
            attributes = DiabeteModel.Attributes.ToList();
            this.learningSet = learningSet;
        }
        private double remainder(List<DiabeteModel> set, Attribute attribute)
        {
            double r = 0;
            for (int i = 0; i < attribute.choices; i++)
            {
                int pk = 0, nk = 0;
                foreach (var item in set)
                {
                    int val = (int)GetPropValue(item, attribute.name);
                    if (val == i)
                    {
                        if (item.Output) pk++;
                        else nk++;
                    }
                }
                double sigma = (pk + nk) / set.Count;
                sigma *= B(pk / (double)(pk + nk));
                r += sigma;
            }
            return r;
        }
        private double B(double q)
        {
            return -(q * Math.Log2(q) + (1 - q) * Math.Log2(1 - q));
        }
        private double Gain(List<DiabeteModel> set, Attribute attribute)
        {
            int all = set.Count;
            int p = set.Count(s => s.Output);
            return B(p / (double)all) - remainder(set, attribute);
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}