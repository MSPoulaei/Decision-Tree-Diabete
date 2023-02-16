using CsvHelper.Configuration;

namespace Decision_Tree_Part2
{
    public class DiabeteMap : ClassMap<Diabete>
    {
        public DiabeteMap()
        {
            Map(r=>r.Pregnancies).Index(0);
            Map(r=>r.Glucose).Index(1);
            Map(r=>r.BloodPressure).Index(2);
            Map(r=>r.SkinThickness).Index(3);
            Map(r=>r.Insulin).Index(4);
            Map(r=>r.BMI).Index(5);
            Map(r=>r.DiabetesPedigreeFunction).Index(6);
            Map(r=>r.Age).Index(7);
            Map(r=>r.Outcome).Index(8);
        }
    }
}