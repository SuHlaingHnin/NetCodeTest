using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LeaderboardItem : MonoBehaviour
{
    [SerializeField] private TMP_Text RankText;
    [SerializeField] private TMP_Text PlayerNameText;
    [SerializeField] private TMP_Text ScoreText;

    public void AssignData(Lobby lobby)
    {
        for (int i = 0; i < lobby.Players.Count; i++)
        {
            RankText.text = i.ToString();
            PlayerNameText.text = "Player " + i;

            ScoreText.text = i.ToString();
        }
    }
}
