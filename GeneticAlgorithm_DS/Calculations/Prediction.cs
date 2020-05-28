using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm_DS.Calculations
{
    class Prediction
    {
        public static List<Person> _population;
        public static List<double> _coeff;
        public static int _selectedPerson;
 
        public static Person SelectPerson()
        {
            //Console.WriteLine("Selected person form: "+_population[_selectedPerson].Form);
            return _population[_selectedPerson];
        }
        public static string ChangeValues( string form)
        {
            Random random = new Random();
            var cells = form.ToCharArray();
            for (int j = 0; j < cells.Length; j++)
            {
                var changeProb = random.Next(-1, 1);
                if (changeProb == 1)
                {
                    if (cells[j].ToString() == "0")
                    {
                        cells[j] = '1';
                    }
                    else if (cells[j].ToString() == "1")
                    {
                        cells[j] = '0';
                    }
                }
            }
            //Console.WriteLine("Changed form cells: " + new string(cells));
            return new string(cells);
        }
        public static void CalcPrediction(List<double> coeff, List<Person> population, int index)
        {
            //Kies een persoon/rij
            //Verander de waardes per eigenschappen
            //bereken prediction
            //print prediction + wel of niet reclame geven?
            _population = population;
            _coeff = coeff;
            _selectedPerson = index;
            var changedValue = ChangeValues(SelectPerson().Form);
            double sse = 0.0;
            Int32[] formArray = changedValue.Select(x => Int32.Parse(x.ToString())).ToArray();
            // var formArray = person.Form.ToCharArray();
            for (int i = 0; i < 19; i++)
            {
                sse = Math.Abs(_coeff[i] * formArray[i]) + sse;
            }
            if (sse >= 1.4)
            {
                Console.WriteLine("Prediction: " + sse + ", Should be Guaranteed advertised to this person");
                //De persoon heeft geen waarde bij de birth control en femine hygiene, daardoor zijn wij meer geneigd om de persoon
                //zwangerschap reclame te geven.
            }
            else if (sse < 1.4  && sse >= 0.8)
            {
                Console.WriteLine("Prediction: " + sse + ", We could advertised to this person");
            }
            else
            {
                Console.WriteLine("Prediction: " + sse + ", Should not be advertised to this person");
                //De persoon heeft waarschijnlijk wel waardes bij birth control en femine hygiene, daardoor zijn wij minder geneigd om deze persoon
                //zwangerschap reclame te geven.
            }

        }
    }
}
