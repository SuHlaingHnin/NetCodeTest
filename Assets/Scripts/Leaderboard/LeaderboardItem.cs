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
            int rank = i + 1;
            RankText.text = rank.ToString();
            PlayerNameText.text = "Player " + rank;

            ScoreText.text = i.ToString();
        }
    }
}
