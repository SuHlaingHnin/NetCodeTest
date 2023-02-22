using System.Collections.Generic;
using UnityEngine;

public class LobbyTabGroup : MonoBehaviour
{
    private List<LobbyTabItem> lobbyTabItems;

    public LobbyTabItem selectedTabItem;

    public string lobbyId;

    public void Subscribe(LobbyTabItem lobbyTabItem)
    {
        if(lobbyTabItems == null)
        {
            lobbyTabItems = new List<LobbyTabItem>();
        } else
        {
            lobbyTabItems.Add(lobbyTabItem);
        }
    }

    public void OnSelectItem(LobbyTabItem lobbyTabItem)
    {
        if(selectedTabItem != null)
        {
            selectedTabItem.OnItemDeselected();
        }

        selectedTabItem = lobbyTabItem;
        selectedTabItem.OnItemSelected();
    }
}
