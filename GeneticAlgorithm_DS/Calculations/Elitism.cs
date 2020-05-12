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
        public static Person bestCandidite = new Person();
        public static Person ChildHighestFit(List<Person> children, double crossOverPercentage)
        {
            List<Person> bestCandidites = new List<Person>();
            RouletteWheel.DoCalculation(children);
            if (bestSolution == 0)
            {
                foreach (var child in children)
                {
                    if (child.NormalizedFitness > crossOverPercentage)
                    {
                        bestCandidites.Add(child);
                    }
                }
                bestSolution = bestCandidites.Max(candidates => candidates.NormalizedFitness);
                bestCandidite = bestCandidites.FirstOrDefault(candidates => candidates.NormalizedFitness == bestSolution);
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
                    bestCandidite = bestCandidites.FirstOrDefault(candidates => candidates.NormalizedFitness == bestSolution);
                }
            }
            Console.WriteLine(bestCandidite.NormalizedFitness);
            return bestCandidite;
        }
    }
}
