using System;
using System.Linq;
using System.Collections.Generic;
namespace Decision_Tree_Part2
{
    class Program
    {

        const int percent_learn=80;
        static void Main(string[] args)
        {
            ReadCSV readCSV=new ReadCSV();
            var data=readCSV.ReadInputs();
            // var data=Ranger.makeRange(data_kham);
            
            var learn_kham=data.Take(percent_learn*data.Count/100).ToList();
            var test=data.Skip(percent_learn*data.Count/100).ToList();
            var learn=Ranger.makeRange(learn_kham);
            TreeBuilder treeBuilder=new TreeBuilder(learn);
            
            Tree decisionTree=new Tree();
            decisionTree.Root=treeBuilder.BuildTree();

            int count=1;int p=0;
            foreach (var t in test)
            {
                var res=decisionTree.Classify(t);
                if (res==t.Output)
                {
                    Console.ForegroundColor=ConsoleColor.Green;
                    System.Console.WriteLine("Test {0}: Passed!",count);
                    Console.ResetColor();
                    p++;
                }
                else{
                    Console.ForegroundColor=ConsoleColor.Red;
                    System.Console.WriteLine("Test {0}: Failed!",count);
                    Console.ResetColor();
                }
                count++;
            }
            decisionTree.Root.PrintPretty("",true);
            System.Console.WriteLine("Accuracy:%{0}",p*100.0/count);

        }
    }
}
