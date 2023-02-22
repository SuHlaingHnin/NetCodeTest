using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class ShowLobbyPanel : MonoBehaviour
{
    [SerializeField] private GameObject lobbyInformationPrefab;
    [SerializeField] private Transform scrollViewContent;

    [SerializeField] private Button joinButton;

    private LobbyTabGroup lobbyTabGroup;

    private void Awake()
    {
        joinButton.onClick.AddListener(OnJoinLobby);
    }

    private void Start()
    {
        lobbyTabGroup = scrollViewContent.GetComponent<LobbyTabGroup>();
    }

    private async void OnJoinLobby()
    {
        joinButton.interactable = false;

        LobbyInformation lobbyInformation = lobbyTabGroup.selectedTabItem.GetComponent<LobbyInformation>();

        await LobbyManager.Instance.JoinLobbyById(lobbyInformation.myLobby.Id, OnJoinLobbySuccess, OnJoinLobbyFail);
    }

    private void OnJoinLobbySuccess()
    {
        joinButton.interactable = true;
        HidePanel();
    }

    private void OnJoinLobbyFail()
    {
        joinButton.interactable = true;
    }

    public void ShowLobbies()
    {
        LobbyManager.Instance.GetLobbies(ShowLobbyDatas);
    }

    public void ShowLobbyDatas(List<Lobby> lobbies)
    {
        Debug.Log(lobbies.Count);

        if(scrollViewContent.childCount > 0)
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
            gameObject.SetActive(true);
        }
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
        ShowLobbies();
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
