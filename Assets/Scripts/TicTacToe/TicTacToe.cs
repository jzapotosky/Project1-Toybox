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

    //UI
    public GameObject xTurnUI = null;
    public GameObject oTurnUI = null;

    public GameObject xWinUI = null;
    public GameObject oWinUI = null;

    public GameObject xPrefab = null;
    public GameObject oPrefab = null;

    public GameObject resetButton = null;

    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;

        UpdateTurnUI();
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
            Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Tile hitTile = hit.transform.GetComponent<Tile>();

                if(hitTile != null && CheckTileOpen(hitTile.row, hitTile.col))
                {
                    if(xTurn)
                    {
                        Instantiate(xPrefab, hitTile.transform.position, Quaternion.identity);
                        SetTile(hitTile.row, hitTile.col);
                    }
                    else
                    {
                        Instantiate(oPrefab, hitTile.transform.position, Quaternion.identity);
                        SetTile(hitTile.row, hitTile.col);
                    }

                    if (CheckWin(hitTile.row, hitTile.col))
                    {
                        if (xTurn)
                        {
                            xTurnUI.SetActive(false);
                            xWinUI.SetActive(true);
                        }
                        else
                        {
                            oTurnUI.SetActive(false);
                            oWinUI.SetActive(true);
                        }

                        resetButton.SetActive(true);
                    }
                    else
                    {
                        xTurn = !xTurn;
                        UpdateTurnUI();
                    }
                }
            }
        }
    }

    public void UpdateTurnUI()
    {
        if(xTurn)
        {
            xTurnUI.SetActive(true);
            oTurnUI.SetActive(false);
        }
        else
        {
            xTurnUI.SetActive(false);
            oTurnUI.SetActive(true);
        }
    }

    public void OnClick_Reset()
    {
        //Turn off the Win UI
        //Destroy all of the piece gameobjects
        //Clear tiles
        //turn off reset button
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
