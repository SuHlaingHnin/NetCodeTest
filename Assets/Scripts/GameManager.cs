using UnityEngine;

public enum GAME_STATE
{
    NONE,
    INGAME,
    FINISH
}
public class GameManager : Singleton<GameManager>
{
    public GameUI gameUI;

    public int score;

    public GAME_STATE gameState;

    public override void Awake()
    {
        base.Awake();
        //GamePreferencesManager.Load();
    }

    private void Update()
    {
        switch(gameState)
        {
            case GAME_STATE.INGAME: gameUI.ShowScoreUI();
                break;
            case GAME_STATE.FINISH: OnGameFinish();
                break;
            default: break;
        }
    }

    public void UpdateScore()
    {
        score++;
        gameUI.UpdateScoreUI(score);
    }

    public void OnGameFinish()
    {
        GamePreferencesManager.Save(score);
        GameUI.Instance.OnGameFinish();

        gameState = GAME_STATE.NONE;
    }
}
