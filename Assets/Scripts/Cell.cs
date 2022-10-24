using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public string _TextIndex;
    public Image Image;
    public Sprite xSprite;
    public Sprite oSprite;
    public Button _Buttom;
    public GameManage _GameManage;
    private Board _Board;


    private void Update()
    {
        if (Timer.TimeEnd)
        {
            _Buttom.interactable = false;

        }
    }


    public void Fill()
    {
        Board.buttonIndex[GameManage.currentTurn] = this._Buttom.gameObject;
        GameManage.currentTurn++;
        _Buttom.interactable = false;
        ChangeSprite();
        _GameManage.SwitchTurn();
        
        if (!Menu.itsPlayerMode)
        {
            StartCoroutine(ComputerTurn());
        }
    }

    public void ComFill()
    {
        Board.buttonIndex[GameManage.currentTurn] = this._Buttom.gameObject;
        GameManage.currentTurn++;
        this._Buttom.interactable = false;
        ChangeSprite();
        _GameManage.SwitchTurn();


    }

    public void ChangeSprite()
    {
        if (GameManage.xTurn)
        {
            Image.sprite = xSprite;
            this._TextIndex = "X";
        }
        else
        {
            Image.sprite = oSprite;
            this._TextIndex = "O";
        }


    }

   IEnumerator ComputerTurn()
    {
        yield return new WaitForSeconds(0.5f);
        Board.itsComTurn = true;


    }

}
