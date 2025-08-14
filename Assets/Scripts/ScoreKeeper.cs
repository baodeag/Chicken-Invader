using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    static ScoreKeeper instance;
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false); // Disable the duplicate instance
            Destroy(gameObject);
        }
        else
        {
            instance = this; // Assign the current instance to the static variable
            DontDestroyOnLoad(gameObject);
        }
    }

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
