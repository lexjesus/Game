using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    
}
