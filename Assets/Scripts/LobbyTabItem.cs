using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbyTabItem : MonoBehaviour, IPointerClickHandler
{
    public LobbyTabGroup lobbyTabGroup;

    [SerializeField] private Button bgButton;
    [SerializeField] private Image bgImage;

    private void Awake()
    {
        //bgButton.onClick.AddListener(OnSelectItem);
    }

    private void Start()
    {
        lobbyTabGroup = transform.parent.GetComponent<LobbyTabGroup>();
        lobbyTabGroup.Subscribe(this);

        bgButton.onClick.AddListener(() =>
        {
            lobbyTabGroup.OnSelectItem(this);
        });
    }

    public void OnItemSelected()
    {
        bgImage.color = Color.grey;
    }

    public void OnItemDeselected()
    {
        bgImage.color = Color.black;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");

        //if (eventData.selectedObject != null)
        //{
        //    Debug.Log(eventData.selectedObject.name);
        //}
    }
}
