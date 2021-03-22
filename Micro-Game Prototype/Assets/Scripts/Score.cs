using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float scoreAmount;
    public float pointIncrease;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncrease = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (int)scoreAmount + "";
        scoreAmount += pointIncrease * Time.deltaTime;
    }
}
