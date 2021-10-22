using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Remove
using UnityEngine.InputSystem;

public class TicTacToe : MonoBehaviour
{
    public bool xTurn = true;

    private string[,] tiles = new string[3, 3];
    private string xValue = "x";
    private string oValue = "o";

    private bool releaseWait = false;
    private Mouse mouse = null;

    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse.leftButton.wasPressedThisFrame)
        {
            releaseWait = true;
        }

        if(mouse.leftButton.wasReleasedThisFrame && releaseWait)
        {
            releaseWait = false;

            //After Mouse Click
        }
    }

    private void SetTile(int row, int col)
    {
        tiles[row, col] = xTurn ? xValue : oValue;
    }

    private bool CheckTileOpen(int row, int col)
    {
        return string.IsNullOrEmpty(tiles[row, col]);
    }

    private bool CheckWin(int row, int col)
    {
        string checkValue = xTurn ? xValue : oValue;

        return TicEvaluator.EvaluateWin(tiles, checkValue, row, col);
    }

    private void ClearTiles()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tiles[i, j] = "";
            }
        }
    }
}
