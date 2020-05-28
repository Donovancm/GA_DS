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
        public static int userOptions;
        public static int _selectedPerson;
        static void Main(string[] args)
        {
            ChooseOptions();
            /*UserInputsFitness();
            RunGeneticAlgorithm();
            //RunExampleOnce();
            Console.WriteLine("Best solution fitness: " + bestPerson.NormalizedFitness);
            Console.WriteLine("Finished");
            Console.ReadLine();*/
        }
        public static void ChooseOptions()
        {
            Console.WriteLine("Press 1 for Calculate new fitness or press 2 for prediction");
            userOptions = int.Parse(Console.ReadLine());
            switch (userOptions)
            {
                case 1:
                    UserInputsFitness();
                    RunGeneticAlgorithm();
                    //RunExampleOnce();
                    Console.WriteLine("Best solution fitness: " + bestPerson.NormalizedFitness);
                    Console.WriteLine("Finished");
                    Console.ReadLine();
                    break;
                case 2:
                    UserInputsPrediction();
                    RunPrediction();
                    Console.WriteLine("Finished");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
        public static void UserInputsPrediction()
        {
            Console.WriteLine("select person betwee 1 to 10");
            _selectedPerson = int.Parse(Console.ReadLine());
        }

        public static void RunPrediction()
        {
            List<Person> population = new List<Person>();
            List<double> coefficient = new List<double>();
            FileReader.CoefficientRead(coefficient);
            FileReader.ReadFile(population, 10);
            Prediction.CalcPrediction(coefficient, population, _selectedPerson);
        }
        public static void UserInputsFitness()
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
            //ICrossover iCrossOver = null;
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
                RunElitism(i, childrenPopulation);
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

        public static void RunElitism(int idx, List<Person> childrenPopulation)
        {
            if (idx > 0)
            {
                var blabla = Elitism.ChildHighestFit(childrenPopulation, crossOverPercentage);
                if (bestPerson.NormalizedFitness != blabla.NormalizedFitness)
                {
                    bestPerson = blabla;
                    
                }
            }
            else if (bestPerson == null) { bestPerson = Elitism.ChildHighestFit(childrenPopulation, crossOverPercentage);   }
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
            var bestPerson = Elitism.ChildHighestFit(childrenPopulation, crossOverPercentage);
            Console.ReadKey();
        }

    }
}
