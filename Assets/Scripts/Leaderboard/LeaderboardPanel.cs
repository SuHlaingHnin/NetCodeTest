using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel : UIBase
{
    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(Close);
    }

    public override void OnShow(object[] objects)
    {
        
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
