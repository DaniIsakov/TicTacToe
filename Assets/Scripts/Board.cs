using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour 
{
    public GameObject cellPrefab; //The Buttons

    private Cell[] cells = new Cell[9];
    public static int[] turnIndex = new int[9];
    public static GameObject[] buttonIndex = new GameObject[9];
    public Sprite Sprite;
    private GameManage _gameManage;
    public static bool itsComTurn = false;
    public static bool hasReseted = false;



    private void Update()
    {

        if (itsComTurn)
        {
            ComTurn();
            itsComTurn = false;
        }


    }

    public void BuildCells(GameManage Main)
    {
        for (int i = 0; i <= 8; i++)
        {
            GameObject newCell = Instantiate(cellPrefab, transform);
            cells[i] = newCell.GetComponent<Cell>();
            cells[i]._GameManage = Main;

        }


    }

    public bool WinCheck() // check if there is a match of winning
    {
        int i = 0;
        //Horizontal
        for (i = 0; i <= 6; i += 3)
        {
            if (!CheckValues(i, i + 1))
                continue;

            if (!CheckValues(i, i + 2))
                continue;

            return true;
        }


        //Vertical
        for (i = 0; i <= 2; i++)
        {
            if (!CheckValues(i, i + 3))
                continue;

            if (!CheckValues(i, i + 6))
                continue;

            return true;
        }

        //Diagonal
        if (CheckValues(0, 4) && CheckValues(0, 8))
            return true;
        if (CheckValues(2, 4) && CheckValues(2, 6))
            return true;

        return false;
    }

    private bool CheckValues(int FirstIndex, int SecondIndex)
    {
        string firstValue = cells[FirstIndex]._TextIndex;
        string secondValue = cells[SecondIndex]._TextIndex;


        if (firstValue == "" || secondValue == "")
            return false;

        if (firstValue == secondValue)
            return true;
        else
            return false;
    }

    public void ResetBoard()
    {
        int randomXO = Random.Range(1, 2); 
        if (randomXO == 1)
        {
            GameManage.xTurn = true;
            if (Menu.itsPlayerMode)
            {
                GameManage.Player1 = "Player 2";
                GameManage.Player2 = "Player 1";
            }



        }
        else
        {
            if (Menu.itsPlayerMode)
            {
                GameManage.Player2 = "Player 2";
                GameManage.Player1 = "Player 1";
            }

            GameManage.xTurn = false;


        }
        foreach (Cell cell in cells)
        {
            cell._Buttom.interactable = true;
            cell.Image.sprite = Sprite;
            cell._TextIndex = "";
        }
        Timer.TimeEnd = false;
        Timer.currentTime = 5;
        GameManage.turnCount = 0;
        GameManage.currentTurn = 0;
        hasReseted = true;
        if (GameObject.Find("WinMassage").activeInHierarchy)
        {
            GameObject.Find("WinMassage").SetActive(false);
        }
    }

    public void Hint()
    {

        int RandomButton = Random.Range(0, 8);

        if (cells[RandomButton]._Buttom.interactable == true)
        {
            cells[RandomButton].Fill();
        }
        else
        {
            foreach (Cell cell in cells)
            {
                if (cell._Buttom.interactable == true)
                {
                    cell.Fill();
                    break;
                }
            }
        }
    }

    public void ComTurn()
    {
        int RandomButton = Random.Range(0, 8);

        if (cells[RandomButton]._Buttom.interactable == true)
        {
            cells[RandomButton].ComFill();
        }
        else
        {
            foreach (Cell cell in cells)
            {
                if (cell._Buttom.interactable == true)
                {
                    cell.ComFill();
                    break;
                }
            }

        }
    }

    public void Undo()
    {
        
        buttonIndex[GameManage.currentTurn - 1].GetComponent<Cell>()._Buttom.interactable = true;
        buttonIndex[GameManage.currentTurn - 1].GetComponent<Cell>().Image.sprite = Sprite;
        buttonIndex[GameManage.currentTurn - 1].GetComponent<Cell>()._TextIndex = "";
        GameManage.currentTurn--;
        GameManage.turnCount--;
        Timer.currentTime = 5;
        GameManage.xTurn = !GameManage.xTurn;
        

    }

}
