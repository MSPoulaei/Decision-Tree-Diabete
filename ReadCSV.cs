using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Decision_Tree_Part2
{
    public class ReadCSV
    {
        private readonly string _filename = "diabetes.csv";
        public ICollection<Diabete> ReadInputs()
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Comment = '#',
                HasHeaderRecord = false
            };
            List<Diabete> restaurants;
            using (var reader = new StreamReader(_filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DiabeteMap>();
                restaurants= csv.GetRecords<Diabete>().ToList();
            }
            return restaurants;
        }
    }
}