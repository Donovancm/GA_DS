using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Calculations
{
    class Mutation
    {
        //Methode aanmaken voor Probability Error voor elke cel, elke children
        public static void MutationChildren(List<string> children)
        {
            Random random = new Random();
            for (int i = 0; i < children.Count; i++)       
            {
                var cells = children[i].ToCharArray();
                for (int j = 0; j < cells.Length; j++)
                {
                    var mutationProb = random.Next(-1,1);
                    if (mutationProb == 1)
                    {
                        if (cells[j].ToString() == "0")
                        {
                            cells[j] = '1';
                        }
                        else if(cells[j].ToString() == "1")
                        {
                            cells[j] = '0';
                        }
                    }
                }
                children[i] = new string(cells);
            }
        }
        //Aangepaste childrens toevoegen aan population
    }
}
