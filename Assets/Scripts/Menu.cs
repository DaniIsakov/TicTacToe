using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool itsPlayerMode;
    private bool HasPressed = false;
    public Button PlayerModeBT;
    public Button ComModeBT;
    public GameObject errorText;

    void Start()
    {
        DontDestroyOnLoad(this);
        
    }

    public void StartLevel()
    {
        if (HasPressed)
        {
            SceneManager.LoadScene("Level");
            Timer.currentTime = 5;
            Timer.TimeEnd = false;
            GameManage.xTurn = true;
        }
        else
        {
            StartCoroutine(Error());
        }
        
    }

    public void PlayerMode()
    {
        itsPlayerMode = true;
        PlayerModeBT.interactable = false;
        PlayerModeBT.image.color = Color.red;
        ComModeBT.interactable = true;
        ComModeBT.image.color = Color.white;
        HasPressed = true;

    }

    public void ComMode()
    {
        itsPlayerMode = false;
        PlayerModeBT.interactable = true;
        PlayerModeBT.image.color = Color.white;
        ComModeBT.interactable = false;
        ComModeBT.image.color = Color.red;
        HasPressed = true;

    }

    IEnumerator Error()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(2);
        errorText.SetActive(false);
    }


}
