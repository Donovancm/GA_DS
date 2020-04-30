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
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            List<Person> population = new List<Person>();
            List<double> coefficient = new List<double>();
            List<CoupleParent> coupleParents = new List<CoupleParent>();
            List<string> crossoverChildren = new List<string>();
            FileReader.CoefficientRead(coefficient);
            FileReader.ReadFile(population);
            Fitness.CalculateSSE(population);
            Fitness.CalculateCoefSSE(coefficient,population);

            //Stap 1 t/m 5
            RouletteWheel.DoCalculation(population);

            //Crossover Methods
            //SinglePointCrossover.DoCrossover(coupleParents, crossoverChildren);
            TwoPointCrossover.DoCrossover(coupleParents, crossoverChildren);

            //Mutation 
            Mutation.MutationChildren(crossoverChildren);

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
