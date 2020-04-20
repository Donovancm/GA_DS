using GeneticAlgorithm_DS.Interfaces;
using GeneticAlgorithm_DS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace GeneticAlgorithm_DS
{
    public class FileReader
    {
        public static string envPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        public static string filePath = envPath + "/Files/RetailMart.xlsx";

        public static Excel.Application xlApp = new Excel.Application();
        public static Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
        public static Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[3];
        public static Excel.Range xlRange = xlWorksheet.UsedRange;

        //Seperate methods for reading different parts
        //method about Coefficient read || method about Population read for readability
        public static List<double> CoefficientRead(List<double> coefficientList)
        {
           
            //row 2
            for (int i = 2; i <= 2; i++)
            {
                //column 2 ----> 21
                for (int j = 2; j <= 20; j++)
                {
                    coefficientList.Add(double.Parse(xlRange.Cells[i, j].Value2.ToString()));
                }
            }

            return coefficientList;
        }
        public static void ReadFile(List<Person> population)
        {
            int rows;
            int columns;
            List<string> list = new List<string>();

            rows = xlRange.Rows.Count;
            //Work in progress
            columns = xlRange.Columns.Count;

            for (int i = 8; i <= 13; i++)
            {
                Person person = new Person();
                var form = "";
                for (int j = 2; j <= 23; j++)
                {
                    if (j == 22)
                    {
                        person.Pregnant = int.Parse(xlRange.Cells[i, j].Value2.ToString());
                    }
                    else if(j == 23)
                    {
                        person.Prediction = double.Parse(xlRange.Cells[i, j].Value2.ToString());
                    }
                    else if (j <= 20 && xlRange.Cells[i, j] != null && xlRange.Cells[i, j].value2 != null)
                    {
                        form = String.Concat(form, xlRange.Cells[i, j].Value2.ToString());
                        //To print the result
                        //Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                    }
                }
                person.Form = form;
                population.Add(person);
            }
        }
    }
}
