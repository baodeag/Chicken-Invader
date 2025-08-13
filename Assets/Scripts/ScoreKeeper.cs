using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        score = Mathf.Clamp(score, 0, int.MaxValue); // Ensure score does not go below 0
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
