using GeneticAlgorithm_DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Models
{
    public class Person : IPerson
    {
        public string Form { get; set; }
        public int Pregnant { get ; set; }

        public double Prediction { get; set; }
    }
}
