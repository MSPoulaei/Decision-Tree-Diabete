using CsvHelper.Configuration.Attributes;

namespace Decision_Tree_Part2
{
    public class Diabete
    {
        [Index(0)]
        public double Pregnancies { get; set; }
        [Index(1)]
        public double Glucose { get; set; }
        [Index(2)]
        public double BloodPressure { get; set; }
        [Index(3)]
        public double SkinThickness { get; set; }
        [Index(4)]
        public double Insulin { get; set; }
        [Index(5)]
        public double BMI { get; set; }
        [Index(6)]
        public double DiabetesPedigreeFunction { get; set; }
        [Index(7)]
        public double Age { get; set; }
        [Index(8)]
        public Bool Outcome { get; set; }
        public bool Output => ((int)Outcome)==1;
    }
    
}