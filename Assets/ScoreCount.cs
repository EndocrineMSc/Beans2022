using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCount : MonoBehaviour
{
    public Text ScoreText;

    public float score;

    public float pointsPerSecond = 1;

    public void IncreaseScore(float amount)
    {
        score += amount;
        UpdateScoreCount();
    }
    public void UpdateScoreCount()
    {
        ScoreText.text = "Score: " + (int)score;
    }
    void Update()
    {
        score += pointsPerSecond * Time.deltaTime;
    }
}
