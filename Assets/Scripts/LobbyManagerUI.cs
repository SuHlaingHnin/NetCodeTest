using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManagerUI : UIBase
{
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button showLobbyButton;

    [SerializeField] private CreateLobbyPanel createLobbyPanel;
    [SerializeField] private ShowLobbyPanel showLobbyPanel;

    private void Awake()
    {
        createLobbyButton.onClick.AddListener(() =>
        {
            createLobbyPanel.TogglePanel();
            showLobbyPanel.Close();
        });

        showLobbyButton.onClick.AddListener(() => {
            showLobbyPanel.TogglePanel();
            createLobbyPanel.Close();
        });
    }

    private void Start()
    {
        showLobbyPanel.Close();
        createLobbyPanel.Close();
    }

}
