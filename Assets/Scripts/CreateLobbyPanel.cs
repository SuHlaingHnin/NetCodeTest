using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobbyPanel : UIBase
{
    [SerializeField] private TMP_InputField lobbyNameInput;
    [SerializeField] private Button createButton;

    [SerializeField] private LobbyManagerUI lobbyManagerUI;

    private void Awake()
    {
        createButton.onClick.AddListener(async () =>
        {
            await OnCreateLobby();
        });
    }

    private async Task OnCreateLobby()
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

        GameManager.Instance.gameState = GAME_STATE.INGAME;

        lobbyManagerUI.Close();
        this.Close();
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
}
