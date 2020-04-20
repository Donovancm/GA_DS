using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Interfaces
{
    public interface IPerson
    {
        string Form { get; set; }
        int Pregnant { get; set; }
        double Fitness { get; set; }
        double Prediction { get; set; }
    }
}
