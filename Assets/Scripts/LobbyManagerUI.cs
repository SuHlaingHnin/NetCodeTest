using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManagerUI : MonoBehaviour
{
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button showLobbyButton;

    [SerializeField] private CreateLobbyPanel createLobbyPanel;
    [SerializeField] private ShowLobbyPanel showLobbyPanel;

    private void Awake()
    {
        createLobbyPanel.HidePanel();
        showLobbyPanel.HidePanel();

        createLobbyButton.onClick.AddListener(() =>
        {
            createLobbyPanel.ShowPanel();
            showLobbyPanel.HidePanel();
        });

        showLobbyButton.onClick.AddListener(() => {
            showLobbyPanel.ShowPanel();
            createLobbyPanel.HidePanel();
        });
    }

}
