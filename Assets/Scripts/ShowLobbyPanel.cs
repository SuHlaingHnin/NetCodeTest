using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class ShowLobbyPanel : UIBase
{
    [SerializeField] private GameObject lobbyInformationPrefab;
    [SerializeField] private Transform scrollViewContent;

    [SerializeField] private Button joinButton;

    [SerializeField] private LobbyManagerUI lobbyManagerUI;

    private LobbyTabGroup lobbyTabGroup;

    private void Awake()
    {
        joinButton.onClick.AddListener(async () =>
        {
            await OnJoinLobby();
        });
    }

    public override async void OnShowAsync(params object[] objects)
    {
        base.OnShowAsync(objects);
        await ShowLobbies();
    }

    private void Start()
    {
        lobbyTabGroup = scrollViewContent.GetComponent<LobbyTabGroup>();
    }

    private async Task OnJoinLobby()
    {
        joinButton.interactable = false;

        LobbyInformation lobbyInformation = lobbyTabGroup.selectedTabItem.GetComponent<LobbyInformation>();

        await LobbyManager.Instance.JoinLobbyById(lobbyInformation.myLobby.Id, OnJoinLobbySuccess, OnJoinLobbyFail);
    }

    private void OnJoinLobbySuccess()
    {
        joinButton.interactable = true;

        GameManager.Instance.gameState = GAME_STATE.INGAME;

        lobbyManagerUI.Close();
        this.Close();
    }

    private void OnJoinLobbyFail()
    {
        joinButton.interactable = true;
    }

    public async Task ShowLobbies()
    {
        List<Lobby> lobbies = await LobbyManager.Instance.GetLobbies();

        if(lobbies == null)
        {
            Debug.Log("There are no lobbies to show!");
            return;
        }

        if (scrollViewContent.childCount > 0)
        {
            DeleteExistingLobbyDatas();
        }

        for (int i = 0; i < lobbies.Count; i++)
        {
            GameObject lobbyItem = Instantiate(lobbyInformationPrefab, scrollViewContent);
            lobbyItem.GetComponent<LobbyInformation>().AssignData(lobbies[i]);
            //lobbyItem.GetComponent<LobbyTabItem>().lobbyTabGroup = lobbyTabGroup;
        }
    }

    public void DeleteExistingLobbyDatas()
    {
        for(int i = 0; i < scrollViewContent.childCount; i++) {
            Destroy(scrollViewContent.GetChild(i).gameObject);
        }
    }

    public void TogglePanel()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Show();
        }
    }
}
