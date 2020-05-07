using GeneticAlgorithm_DS.Calculations;
using GeneticAlgorithm_DS.Interfaces;
using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS
{
    class Program
    {
        public static int populationAmount;
        public static double crossOverPercentage;
        public static int iterations;
        public static Person bestPerson;
        static void Main(string[] args)
        {
            UserInputs();
            RunGeneticAlgorithm();
            //RunExampleOnce();
            Console.WriteLine("Best solution fitness: " + bestPerson.NormalizedFitness);
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
        public static void UserInputs()
        {
            //Populatie kiezen
            Console.WriteLine("Set the amount of persons");
            populationAmount = int.Parse(Console.ReadLine());
            //Crossover Rate kiezen
            Console.WriteLine("Set the Crossoverrate between 0.80 to 0.95");
            crossOverPercentage = double.Parse(Console.ReadLine());
            //Hoeveel iteraties
            Console.WriteLine("Set the amount of iterations");
            iterations = int.Parse(Console.ReadLine());
            //Single or TwoPoint
            ICrossover iCrossOver = null;
        }
        public static void RunGeneticAlgorithm()
        {

            for (int i = 0; i < iterations; i++)
            {
                List<Person> population = new List<Person>();
                List<double> coefficient = new List<double>();
                List<string> crossoverChildren = new List<string>();
                FileReader.CoefficientRead(coefficient);
                FileReader.ReadFile(population, populationAmount);
                List<CoupleParent> coupleParents = new List<CoupleParent>();
                Fitness.CalculateSSE(population);
                Fitness.CalculateCoefSSE(coefficient, population);
                RouletteWheel.DoCalculation(population);
                RunCrossOver(coupleParents, crossoverChildren, population);
                Mutation.MutationChildren(crossoverChildren);
                //Recalculate Fitness for Childrens
                List<Person> childrenPopulation = Fitness.CalculateCoefSSEChild(coefficient, crossoverChildren);
                //Elitism best solution
                RunElitism(i, childrenPopulation, population);
            }
        }

        public static void RunCrossOver(List<CoupleParent> coupleParents, List<string> crossoverChildren, List<Person> population)
        {

            Random random = new Random();
            int setCrossoverPoint = random.Next(0, 1);
            if (setCrossoverPoint == 0)
            {
                SinglePointCrossover.DoCrossover(coupleParents, crossoverChildren, crossOverPercentage, population);
            }
            else
            {
                TwoPointCrossover.DoCrossover(coupleParents, crossoverChildren, crossOverPercentage, population);
            }

        }

        public static void RunElitism(int idx, List<Person> childrenPopulation, List<Person> population)
        {
            if (idx > 0)
            {
                if (bestPerson != Elitism.ChildHighestFit(childrenPopulation))
                {
                    bestPerson = Elitism.ChildHighestFit(childrenPopulation);
                    
                }
            }
            else if (bestPerson == null) { bestPerson = Elitism.ChildHighestFit(childrenPopulation);   }
        }

        public static void RunExampleOnce()
        {
            List<Person> population = new List<Person>();
            List<double> coefficient = new List<double>();
            List<CoupleParent> coupleParents = new List<CoupleParent>();
            List<string> crossoverChildren = new List<string>();
            FileReader.CoefficientRead(coefficient);
            FileReader.ReadFile(population, 5);
            Fitness.CalculateSSE(population);
            Fitness.CalculateCoefSSE(coefficient, population);

            //Stap 1 t/m 5
            RouletteWheel.DoCalculation(population);

            //Crossover Methods
            //SinglePointCrossover.DoCrossover(coupleParents, crossoverChildren);
            TwoPointCrossover.DoCrossover(coupleParents, crossoverChildren, crossOverPercentage, population);

            //Mutation 
            Mutation.MutationChildren(crossoverChildren);

            //Recalculate Fitness for Childrens
            List<Person> childrenPopulation = Fitness.CalculateCoefSSEChild(coefficient, crossoverChildren);

            //Elitism best solution
            var bestPerson = Elitism.ChildHighestFit(childrenPopulation);
            Console.ReadKey();
        }

    }
}
