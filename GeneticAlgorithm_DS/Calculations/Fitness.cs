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
        //FITNESS = SSE= Som((PREGNANT-Prediction) ^2)
        public static double CalculateSSE(List<Person> population)
        {
            double sse = 0.0;
            foreach (var person in population)
            {
               sse += Math.Pow(person.Pregnant - person.Prediction, 2);
            }
            return sse;
        }
    }
}
