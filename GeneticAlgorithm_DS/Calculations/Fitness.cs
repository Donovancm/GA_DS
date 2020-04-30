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
        public static void CalculateCoefSSE(List<double> coeff, List<Person> population)
        {
            var coeffArray = coeff.ToArray();
            //Fitness (Coefficient * Cell) + next
            
            foreach (var person in population)
            {
                double sse = 0.0;
                Int32[] formArray = person.Form.Select(x => Int32.Parse(x.ToString())).ToArray();
               // var formArray = person.Form.ToCharArray();
                for (int i = 0; i < 19; i++)
                {
                    sse += coeffArray[i] * formArray[i];
                }
                person.Fitness = sse;               
            }
        }

        //Fitness (Coefficient * Cell) + next 
        //Betere naam verzinnen
        public static List<Person> CalculateCoefSSEChild(List<double> coeff, List<string> children)
        {
            var coeffArray = coeff.ToArray();
            List<Person> childPopulation = new List<Person>();

            foreach (var child in children)
            {
                double sse = 0.0;
                Int32[] formArray = child.Select(x => Int32.Parse(x.ToString())).ToArray();
                // var formArray = person.Form.ToCharArray();
                for (int i = 0; i < 19; i++)
                {
                    sse += coeffArray[i] * formArray[i];
                }
                childPopulation.Add(new Person() { Form = child, Fitness = sse });
            }
            return childPopulation;
        }
    }
}
