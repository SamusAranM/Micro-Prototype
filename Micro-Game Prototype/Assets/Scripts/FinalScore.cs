using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text Score;
    public Text finalText;

    // Update is called once per frame
    void Update()
    {
        finalText.text = "Score = " + Score.text;
        Score.enabled = false;
    }
}
