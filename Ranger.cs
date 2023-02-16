namespace Decision_Tree_Part2
{
    public class Ranger
    {
        private const int N = 10;
        public static List<DiabeteModel> makeRange(ICollection<Diabete> data)
        {
            List<DiabeteModel> result = new List<DiabeteModel>();
            for (int i = 0; i < DiabeteModel.Attributes.Length; i++)
            {
                var att = DiabeteModel.Attributes[i];
                string n_attr = att.name;
                double min = double.MaxValue, max = double.MinValue;
                foreach (var dat in data)
                {
                    min = Math.Min(min, (double)TreeBuilder.GetPropValue(dat, n_attr));
                    max = Math.Max(max, (double)TreeBuilder.GetPropValue(dat, n_attr));
                }
                double distance = (max - min) / N;
                for (int j = 0; j <= N; j++)
                {
                    DiabeteModel.Attributes[i].ranges.Add(min + j * distance);
                }

            }
            foreach (var dat in data)
            {
                DiabeteModel datModel=new DiabeteModel();

                foreach (var att in DiabeteModel.Attributes)
                {
                    double val = (double)TreeBuilder.GetPropValue(dat, att.name);
                    int index = att.choices - 1;
                    for (int i = 0; i < att.choices; i++)
                    {
                        if (val < att.ranges[i])
                        {
                            index = i;
                            break;
                        }
                    }
                    SetPropValue(datModel,att.name,index);
                }
                datModel.Outcome=dat.Outcome;
                result.Add(datModel);
            }
            return result;
        }
        public static void SetPropValue(object src, string propName,object value)
        {
            src.GetType().GetProperty(propName).SetValue(src, value);
        }
    }
}