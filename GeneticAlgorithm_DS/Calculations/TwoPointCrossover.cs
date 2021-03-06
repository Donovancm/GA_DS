﻿using GeneticAlgorithm_DS.Interfaces;
using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Calculations
{
    class TwoPointCrossover : ICrossover

    {
        public static List<Person> population;
        public static List<double> normalizedValues = RouletteWheel.Values;
        public static double CrossoverRate;
        public static List<double> parents = new List<double>();
        public static List<CoupleParent> cParents;
        public static List<string> children;
        public int firstPointPosition;
        public int secondPointPosition;

        public static void DoCrossover(List<CoupleParent> coupleParents, List<string> crossoverChildren, double crossOverPercentage, List<Person> populations)
        {
            population = populations;
            CrossoverRate = crossOverPercentage;
            cParents = coupleParents;
            children = crossoverChildren;
            SelectionParents();
            SelectionParentsCouple();
            ICrossover iCrossover = new TwoPointCrossover();
            iCrossover.CreateChildren();
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

            while (parents.Count >= 2)
            {
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
        public void CreateChildren()
        {
            //
            foreach (var parent in cParents)
            {
                Person parentForm1 = RouletteWheel.population.Find(x => x.NormalizedFitness == parent.Parent1);
                Person parentForm2 = RouletteWheel.population.Find(x => x.NormalizedFitness == parent.Parent2);
                Random random = new Random();

                //Zet de eerste punt
                firstPointPosition = random.Next(1,18);
                secondPointPosition = random.Next(firstPointPosition + 1,18); //TODO: Optimize random generator
                //Console.WriteLine(firstPointPosition);
                //Console.WriteLine(secondPointPosition);

                var parent1SubForm = Divide(parentForm1.Form);
                var parent2SubForm = Divide(parentForm2.Form);

                //Console.WriteLine(parent1SubForm);
                //Console.WriteLine(parent2SubForm);
                var child1 = Combine(parentForm1.Form, parent2SubForm);

                var child2 = Combine(parentForm2.Form, parent1SubForm);
                children.Add(child1);
                children.Add(child2);
            }
        }

        public string Divide(string form)
        {
            var array = form.ToCharArray();
            var subTemp = "";
            for (int index = firstPointPosition; index < secondPointPosition; index++)
            {
                string subString = array[index].ToString();
                var temp = String.Concat(subTemp, subString);
                subTemp = temp;
            }
            return subTemp;
        }
        public string Combine(string form, string parentSubForm)
        {
            //lijst van 3 helften t.b.c
            var array = form.ToCharArray();
            var child = "";
            for (int i = 0; i < array.Length; i++)
            {
                //eerste helft tot start point combineren.
                if (i < firstPointPosition)
                {
                    string subString = array[i].ToString();
                    var temp = String.Concat(child, subString);
                    child = temp;
                }

            }
            //tweede helft met eerste combineren.
            var tempChild = String.Concat(child, parentSubForm);
            child = tempChild;
            for (int j = secondPointPosition; j < array.Length; j++)
            {
                string subString = array[j].ToString();
                var temp = String.Concat(child, subString);
                child = temp;
            }
            return child;
        }
    }

}
