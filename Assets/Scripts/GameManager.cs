using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameUI gameUI;

    public int score;

    public override void Awake()
    {
        base.Awake();
        GamePreferencesManager.Load();
    }

    public void UpdateScore()
    {
        score++;
        gameUI.UpdateScoreUI(score);
    }

    public void GameFinish()
    {
        GamePreferencesManager.Save(score);
        GameUI.Instance.OnGameFinish();
    }
}
