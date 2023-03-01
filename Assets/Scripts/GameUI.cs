using TMPro;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private LeaderboardPanel leaderboardPanel;

    private void Start()
    {
        scoreText.gameObject.SetActive(false);
    }

    public void UpdateScoreUI(int value)
    {
        scoreText.text = string.Format("Score : {0}", value);
    }
    
    public void OnGameFinish()
    {
        HideScoreUI();
        leaderboardPanel.Show();
    }

    public void HideScoreUI()
    {
        scoreText.gameObject.SetActive(false);
    }

    public void ShowScoreUI()
    {
        scoreText.gameObject.SetActive(true);
    }
}
