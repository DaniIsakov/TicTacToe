using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static float currentTime = 0f; // The Current Time
    float startingTime = 5f; // The Counter TIme
    [SerializeField] Text Text; // The Text GameObject
    public static bool TimeEnd = false; // a boolian for End Time

    void Awake()
    {
        currentTime = startingTime; // Starting The game Time
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeEnd)
        {
            currentTime -= 1 * Time.deltaTime; // get the timer 1 per frame *deltaTime

        }
        Text.text = currentTime.ToString("f1"); // transfer the float to string.

        


    }
}
