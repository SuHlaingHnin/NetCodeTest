using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel : UIBase
{
    [SerializeField] private Button backButton;
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject leaderbordItemPrefab;

    private void Awake()
    {
        backButton.onClick.AddListener(Close);
    }

    public override async void OnShowAsync(params object[] objects)
    {
        base.OnShowAsync(objects);

        await ShowPlayerScore();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public async Task ShowPlayerScore()
    {
        List<Lobby> lobbies = await LobbyManager.Instance.GetLobbies();

        if (scrollViewContent.childCount > 0)
        {
            DeleteExistingLobbyDatas();
        }

        for (int i = 0; i < lobbies.Count; i++)
        {
            GameObject leaderboardItem = Instantiate(leaderbordItemPrefab, scrollViewContent);
            leaderboardItem.GetComponent<LeaderboardItem>().AssignData(lobbies[i]);
        }
    }

    public void DeleteExistingLobbyDatas()
    {
        for (int i = 0; i < scrollViewContent.childCount; i++)
        {
            Destroy(scrollViewContent.GetChild(i).gameObject);
        }
    }
}
