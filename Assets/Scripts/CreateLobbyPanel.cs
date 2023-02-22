using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobbyPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField lobbyNameInput;
    [SerializeField] private Button createButton;

    private void Awake()
    {
        createButton.onClick.AddListener(OnCreateLobby);
    }

    private async void OnCreateLobby()
    {
        string input = lobbyNameInput.text;

        if (input == null || input == "")
        {
            Debug.LogError("Please enter the lobby name!");
            return;
        }
        
        await LobbyManager.Instance.CreateLobby(input, OnCreateLobbySuccess, OnCreateLobbyFail);
    }

    private void OnCreateLobbySuccess()
    {
        createButton.interactable = true;
        this.HidePanel();
    }

    private void OnCreateLobbyFail()
    {
        createButton.interactable = true;
    }

    public void TogglePanel()
    {
        if(gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        } 
        else
        {
            gameObject.SetActive(true);
        }
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
