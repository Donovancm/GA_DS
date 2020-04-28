using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Interfaces
{
    public interface ICrossover
    {
        //Divide
        //Combine
        void CreateChildren();
        string Combine(Person parentForm, string parentSubForm, int startPoint);
    }
}
