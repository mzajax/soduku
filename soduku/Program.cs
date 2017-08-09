using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soduku
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "input_sudoku.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("Invalid input file! File not found!");
                return;
            }

            string fileContent = "";

            try
            {
                fileContent = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Corrupt file! Please try another file!");
                return;
            }
            try
            {
                var sudoku = new Sudoku(fileContent);
                var result = sudoku.Validate();
                Console.WriteLine("Sudoku status: {0}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid sodoku puzzle!");
                return; 
            }
            
        }
    }
}
