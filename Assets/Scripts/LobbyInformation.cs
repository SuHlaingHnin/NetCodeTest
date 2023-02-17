using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyInformation : MonoBehaviour
{
    [SerializeField] private TMP_Text NameText;

    public void AssignData(Lobby lobby)
    {
        NameText.text = lobby.Name;
    }
}
