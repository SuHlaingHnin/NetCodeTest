using TMPro;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private LeaderboardPanel leaderboardPanel;

    public void UpdateScoreUI(int value)
    {
        scoreText.text = string.Format("Score : {0}", value);
    }
    
    public void OnGameFinish()
    {
        leaderboardPanel.Show();
    }
}
