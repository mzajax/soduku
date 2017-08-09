using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soduku
{
    public class Sudoku
    {
        private List<List<int>> grid = null;

        public Sudoku(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Invalid input provided!");
            }

            this.initializeGrid(input);
        }


        private void initializeGrid(string input)
        {
            var sodokuRows = input.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            if (sodokuRows.Length != 9)
            {
                return; // if grid is null, false is returned; 
            }

            var listOfRows = new List<List<int>>();

            foreach (var row in sodokuRows)
            {
                var trimmedRow = row.Trim();

                if (trimmedRow.Length != 9)
                {
                    return; // if grid is null, false is returned; 
                }
                
                var rowList = new List<int>();

                foreach (var c in trimmedRow)
                {
                    int outValue;
                    if (!int.TryParse(c.ToString(), out outValue))
                    {
                        return; // if grid is null, false is returned; 
                    }

                    rowList.Add(outValue);
                }
                listOfRows.Add(rowList);
            }

            this.grid = listOfRows;
        }


        public bool Validate()
        {
            return grid != null && ValidateGrid(this.grid);
        }

        private static bool ValidateGrid(List<List<int>> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                int[] row = new int[9];
                int[] square = new int[9];
                int[] column = new int[9];

                for (int j = 0; j < 9; j++)
                {
                    row[j] = grid[i][j];
                    column[j] = grid[j][i];
                    square[j] = grid[(i / 3) * 3 + j / 3][i * 3 % 9 + j % 3];
                }

                // temp
                //var a = string.Join(",", row);
                //var b = string.Join(",", column);
                //var c = string.Join(",", square);

                if (!(ValidateSlice(column) && ValidateSlice(row) && ValidateSlice(square)))
                {
                    return false;
                }
            }
            return true; 
        }

        private static bool ValidateSlice(int[] slice)
        {
            var i = 0;
            var sortedSlice = new List<int>(slice);
            sortedSlice.Sort();
            foreach (var number in sortedSlice)
            {
                if (number != ++i)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
