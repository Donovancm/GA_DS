using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Calculations
{
    class Elitism
    {
        //Methode aanmaken voor nieuwe populatie, hiervan gaan wij de persoon met de hoogste fitness behouden en mee laten doen aan de volgende Iteratie
        //50 ---> 50 ---> de hoogste fitness bewaren --->
        //
        public static double bestSolution = 0.0;
        public static Person ChildHighestFit(List<Person> children)
        {
            List<Person> bestCandidites = new List<Person>();
            var bestCandite = new Person();
            RouletteWheel.DoCalculation(children);
            if (bestSolution == 0)
            {
                foreach (var child in children)
                {
                    if (child.NormalizedFitness > 0.8)
                    {
                        bestCandidites.Add(child);
                    }
                }
                bestSolution = bestCandidites.Max(candidates => candidates.NormalizedFitness);
                bestCandite = bestCandidites.FirstOrDefault(candidates => candidates.NormalizedFitness == bestSolution);
            }
            else
            {
                // tweede rond
                foreach (var child in children)// 10
                {
                    if(child.NormalizedFitness > bestSolution)
                    {
                        bestCandidites.Add(child);
                    }
                   //vergelijk de eerste beste bewaarde oplossing met de 2 best bewaarde oplossing
                   //In principe moet de Fitness waarde steeds hoger worden ipv lager

                }
                if (bestCandidites.Count != 0)
                {
                    bestSolution = bestCandidites.Max(candidates => candidates.NormalizedFitness);
                    bestCandite = bestCandidites.FirstOrDefault(candidates => candidates.NormalizedFitness == bestSolution);
                }
            }
            return bestCandite;
        }
    }
}
