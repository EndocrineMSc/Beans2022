using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public float score;
    public float pointsPerSecond = 1;
    void Update()
    {
        score += pointsPerSecond * Time.deltaTime;
        scoreText.text = "Score: " + (int)score;
    }
}


