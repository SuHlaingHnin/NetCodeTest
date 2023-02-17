using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyInformation : MonoBehaviour
{
    [SerializeField] private TMP_Text RoomNameText;
    [SerializeField] private TMP_Text PlayerCountText;
    [SerializeField] private TMP_Text HostNameText;

    public void AssignData(Lobby lobby)
    {
        RoomNameText.text = lobby.Name;

        string playerCount = string.Format("{0} / {1}", lobby.Players.Count, lobby.MaxPlayers);
        PlayerCountText.text = playerCount;

        HostNameText.text = lobby.HostId;
    }
}
