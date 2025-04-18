using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle4
{
    public class CrossWordDecipher
    {

        private char[] XmasCharacters = new char[]
        {
            'M',
            'A',
            'S'
        };

        #region Increments counter and returns counter
        public int Decipher(string crossword)
        {
            char[,] crosswordCharArr = BuildCharArray(crossword);
            int counter = 0;
            
            for (int i = 0; i < crosswordCharArr.GetLength(0); i++)
            {
                for (int j = 0; j < crosswordCharArr.GetLength(1); j++)
                {
                    if (crosswordCharArr[i,j]!='X')
                    {
                        continue;
                    }
                    //Its not really ideal but it allows for reduced redundancy
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if (CheckCrossWord(crosswordCharArr, i, j, k, l))
                            {
                                counter++;
                            }
                        }
                    }

                }
            }
            return counter;
        }
        #endregion

        #region Evaluates the crossword diagonally, across and above/below
        private bool CheckCrossWord(char[,] charArr, int row, int col,int increment, int increment2)
        { 
            //Row                                                   //Col
            if (CheckIndex(row, increment, charArr.GetLength(0)) || CheckIndex(col, increment2, charArr.GetLength(1)))
            {
                return false;
            }
            for (int i = 0; i<3;i++)
            { 
                row += increment;
                col += increment2;
                if(charArr[row,col] != XmasCharacters[i])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Evalutes if index is out of bounds
        private bool CheckIndex(int index, int increment, int length)
       {
            if(increment>0)
            {
                if (index + 3 < length)
                {
                    return false;
                }
            }
            else if(increment==0)
            {
                return false;
            }
            else
            {
                if(index-3>=0)
                {
                    return false;
                }
            }
            return true;
       }
        #endregion

        #region Builds Character 2D Array to evaluate the crossword puzzle
        private char[,] BuildCharArray(string crossword)
        {
            var splitCrossword = crossword.Split("\r\n");
            char[,] crosswordCharArr = new char[splitCrossword.Length, splitCrossword[0].Length];
            for (int i = 0; i < splitCrossword.Length; i++)
            {
                for (int j = 0; j < splitCrossword[i].Length; j++)
                {
                    crosswordCharArr[i, j] = splitCrossword[i][j];
                }
            }
            return crosswordCharArr;
        }
        #endregion
    }
}
