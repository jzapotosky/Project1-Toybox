using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicEvaluator
{
    public static bool EvaluateWin(string[,] tiles, string checkValue, int row, int col)
    {
        // Check row
        for (int i = 0; i < 3; i++)
        {
            if (tiles[row, i] != checkValue)
            {
                break;
            }
            else if (i == 2)
            {
                return true;
            }
        }

        //Check column
        for (int i = 0; i < 3; i++)
        {
            if (tiles[i, col] != checkValue)
            {
                break;
            }
            else if (i == 2)
            {
                return true;
            }
        }

        //Check Diagonal
        if ((row == 1 && col == 0) || (row == 0 && col == 1) || (row == 2 && col == 1) || (row == 1 && col == 2))
        {
            return false;
        }
        else if (CheckDownDiag(checkValue, tiles) || CheckUpDiag(checkValue, tiles))
        {
            return true;
        }


        return false;
    }

    private static bool CheckDownDiag(string value, string[,] tiles)
    {
        return tiles[2, 0] == value && tiles[1, 1] == value && tiles[0, 2] == value;
    }

    private static bool CheckUpDiag(string value, string[,] tiles)
    {
        return tiles[0, 0] == value && tiles[1, 1] == value && tiles[2, 2] == value;
    }
}
