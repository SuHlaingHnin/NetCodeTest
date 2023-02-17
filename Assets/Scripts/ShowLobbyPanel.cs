using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class ShowLobbyPanel : MonoBehaviour
{
    [SerializeField] private GameObject lobbyInformation;
    [SerializeField] private Transform scrollViewContent;

    private void Start()
    {
        //ShowLobbies();
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
            GameObject lobbyItem = Instantiate(lobbyInformation, scrollViewContent);
            lobbyItem.GetComponent<LobbyInformation>().AssignData(lobbies[i]);
        }
    }

    public void DeleteExistingLobbyDatas()
    {
        for(int i = 0; i < scrollViewContent.childCount; i++) { 
            Destroy(scrollViewContent.GetChild(i));
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
