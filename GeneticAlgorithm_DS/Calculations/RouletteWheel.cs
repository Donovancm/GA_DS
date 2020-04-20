using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Calculations
{
    public static class RouletteWheel
    {
        //Stap 1
        public static double sumFitness = 0.0;
        //Stap 2
        public static List<double> values = new List<double>();
        public static double SumNormalisation = 0.0;
        public static List<Person> population;

        public static List<double> Values { get { return values; } }
        public static void DoCalculation(List<Person> data)
        {
            population = data;
            CalculateSumFitness();
            CalculateValues();
            CalculateSumValues();
            CalculateSumTotal();
        }

        public static void CalculateSumFitness()
        {
            foreach (var person in population)
            {
                sumFitness += person.Fitness;
            }
        }
        //Betere naam verzinnen || Waarde + sumFitness  || Stap 2 & Stap 3 Normaliseren
        public static void CalculateValues()
        {
            foreach (var person in population)
            {
                double normalizeFitness = 1 - (person.Fitness / sumFitness);
                values.Add(normalizeFitness);
                person.NormalizedFitness = normalizeFitness;
            }
        }
        //Stap 4
        public static void CalculateSumValues()
        {
            foreach (var value in values)
            {
                SumNormalisation += value;
            }
        }

        public static bool CalculateSumTotal()
        {
            double totalMultiplier = sumFitness * SumNormalisation;
            double totalSumfitness = 0.0;
            foreach (var person in population)
            {
                totalSumfitness += sumFitness - person.Fitness;
            }

            return totalMultiplier == totalSumfitness;

        } 

        //stap 1 Som berekenen van fitness
        //stap 2 waarde / som 
        //stap 3 Normaliseren  = 1 - waarde == laagste waarde wordt hoogst gewaardeerd
        //stap 4 Som normalisatie
        //stap 5 Som Totaal = (SomNormalisatie * SomFitness)

    }
}
