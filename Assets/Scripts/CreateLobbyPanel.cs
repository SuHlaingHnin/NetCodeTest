using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobbyPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField lobbyNameInput;
    [SerializeField] private Button createButton;

    private void Awake()
    {
        createButton.onClick.AddListener(() =>
        {
            string input = lobbyNameInput.text;

            if (input != null && input != "")
            {
                LobbyManager.Instance.CreateLobby(input, CreateLobbySuccessCallback);
                createButton.interactable = true;
            } else
            {
                Debug.LogError("Please enter the lobby name!");
            }
        });
    }
    private void CreateLobbySuccessCallback()
    {
        createButton.interactable = true;
        this.HidePanel();
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
