using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public Board _Board;
    public static int currentTurn = 0;
    public static bool xTurn = true;
    public static int turnCount = 0;

    public GameObject winMassage;
    public Text massageText;
    public Text playerText;

    public static string Player1 = "Player 1";
    public static string Player2 = "Player 2";
    

    private void Awake()
    {
        _Board.BuildCells(this);
        currentTurn = 0;
        turnCount = 0;
        print("The PlayerMode is " + Menu.itsPlayerMode);
        print("The Player 1 is X = " + GameManage.xTurn);
        playerText.text = Player1;
    }

    private void Update()
    {
        TimeEnded();

        if (Board.hasReseted)
        {
            playerText.text = Player1;
            Board.hasReseted = false;
        }
    }

    public void TimeEnded()
    {
        if (Timer.currentTime <= 0) // Time End Win Massage
        {
            Timer.TimeEnd = true;

            if (xTurn)
            {
                if (Menu.itsPlayerMode)
                {
                    massageText.text = Player2 + " Win";
                    winMassage.SetActive(true);
                }
                else
                {
                    massageText.text = "The Computer Win";
                    winMassage.SetActive(true);
                }


            }
            else
            {
                massageText.text = Player1 + " Win";
                winMassage.SetActive(true);
            }

        }
    }

    public void SwitchTurn()
    {
        turnCount++;
        if (xTurn)
        {
            playerText.text = Player2;
        }
        else
        {
            playerText.text = Player1;
        }

        bool hasWinner = _Board.WinCheck();
        if (hasWinner || turnCount == 9) // End Game
        {
            if (xTurn && hasWinner)
            {
                print(Player1 + " Win");
                Timer.TimeEnd = true;
                massageText.text = Player1 + " Win";
                winMassage.SetActive(true);
                if (!Menu.itsPlayerMode)
                {
                    xTurn = true;
                }
            }
            if (!xTurn && hasWinner)
            {
                if (Menu.itsPlayerMode)
                {
                    print(Player2 + " Win");
                    massageText.text = Player2 + " Win";
                }
                else
                {
                    print("The Computer Win");
                    massageText.text = "The Computer Win";
                }
                Timer.TimeEnd = true;
                winMassage.SetActive(true);
            }
            if (turnCount == 9 && !hasWinner)
            {
                print("Draw");
                Timer.TimeEnd = true;
                massageText.text = "Draw";
                winMassage.SetActive(true);
            }

        }
        if (!hasWinner)
        {
            xTurn = !xTurn;
            Timer.currentTime = 5;
        }
        

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("MenuManager"));
        xTurn = true;
        
    }

}
