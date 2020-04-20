using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Calculations
{
    public class Fitness
    {
        //FITNESS = SSE= Som((PREGNANT-Prediction) ^2) || Herbenoemen functie
        public static double CalculateSSE(List<Person> population)
        {
            double sse = 0.0;
            foreach (var person in population)
            {
               sse += Math.Pow(person.Pregnant - person.Prediction, 2);
            }
            return sse;
        }

        //Fitness (Coefficient * Cell) + next 
        //Betere naam verzinnen
        public static double CalculateCoefSSE(List<double> coeff, List<Person> population)
        {
            var coeffArray = coeff.ToArray();
            //Fitness (Coefficient * Cell) + next
            double sse = 0.0;
            foreach (var person in population)
            {
                Int32[] formArray = person.Form.Select(x => Int32.Parse(x.ToString())).ToArray();
               // var formArray = person.Form.ToCharArray();
                for (int i = 0; i < 19; i++)
                {
                    sse += coeffArray[i] * formArray[i];
                }
               
            }
            return sse;
        }
    }
}
