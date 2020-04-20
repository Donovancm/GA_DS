using GeneticAlgorithm_DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Models
{
    public class CoupleParent : ICoupleParent
    {
        public double Parent1 { get; set; }
        public double Parent2 { get; set; }

    }
}
