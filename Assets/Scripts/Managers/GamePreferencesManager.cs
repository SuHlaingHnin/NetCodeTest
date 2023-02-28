using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferencesManager
{
    public static void Save(int score)
    {
        PlayerPrefs.SetInt("score", score);
    }

    public static void Load()
    {
        int score = PlayerPrefs.GetInt("score");
        GameManager.Instance.score = score;
    }
}
