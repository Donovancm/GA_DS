using GeneticAlgorithm_DS.Interfaces;
using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Calculations
{
    public class SinglePointCrossover : ICrossover
    {
        public static List<double> normalizedValues = RouletteWheel.Values;
        public static double CrossoverRate = 0.8;
        public static List<double> parents = new List<double>();
        public static List<CoupleParent> cParents;

        public static void DoCrossover(List<CoupleParent> coupleParents)
        {
            cParents = coupleParents;
            SelectionParents();
            SelectionParentsCouple();
            ICrossover iCrossover = new SinglePointCrossover();
            iCrossover.Divide();
        }
        public static void SelectionParents()
        {
            foreach (var parent in normalizedValues)
            {
                if (parent >= CrossoverRate)
                {
                    parents.Add(parent);
                }
            }
        }
        //SelectionParents is done for example 5 persoons 
        //We randomly select 2 persons from the population and we remove those 2 from the list<double> parents 5 --> 3
        //Do SinglePointmethods .....to create 2 childrens ---> New population list.
        //Repeat step 2 and 3 till no couple is left.
        //The remainder we throw away, not fit for evolution.
        public static void SelectionParentsCouple()
        {
            Random random = new Random();

            while (parents.Count >= 2) {
                CoupleParent couples = new CoupleParent();
                var idxParent1 = random.Next(0, parents.Count);
                couples.Parent1 = parents[idxParent1];
                parents.RemoveAt(idxParent1);
                var idxParent2 = random.Next(0, parents.Count);
                couples.Parent2 = parents[idxParent2];
                parents.RemoveAt(idxParent2);
                cParents.Add(couples);
            }
        }
        public void Divide()
        {
            //
            foreach (var parent in cParents)
            {
                Person parentForm1 = RouletteWheel.population.Find(x => x.NormalizedFitness == parent.Parent1);
                Person parentForm2 = RouletteWheel.population.Find(x => x.NormalizedFitness == parent.Parent2);
                Random random = new Random();
                int singlePointPosition = random.Next(0,18);
                // divide the form first
                // call combine function
            }
        }
        public void Combine()
        {
            //lijst van 2 helften t.b.c
        }
    }
}
