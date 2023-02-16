
namespace Decision_Tree_Part2
{
    public class DiabeteModel
    {
        public int Pregnancies { get; set; }
        public int Glucose { get; set; }
        public int BloodPressure { get; set; }
        public int SkinThickness { get; set; }
        public int Insulin { get; set; }
        public int BMI { get; set; }
        public int DiabetesPedigreeFunction { get; set; }
        public int Age { get; set; }
        public Bool Outcome { get; set; }
        public bool Output => ((int)Outcome)==1;
        public static readonly Attribute[] Attributes ={
            new Attribute("Pregnancies"),
            new Attribute("Glucose"),
            new Attribute("BloodPressure"),
            new Attribute("SkinThickness"),
            new Attribute("BMI"),
            new Attribute("DiabetesPedigreeFunction"),
            new Attribute("Age"),
        };
    }
    public class Attribute
    {
        public Attribute(string name)
        {
            this.name = name;
        }
        public string name;
        public int choices=>ranges.Count;
        public List<double> ranges=new List<double>();
        // public bool isEnum;
    }
    public enum Bool{
        False,
        True
    }
}