using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private NetworkManager networkManager;

    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        serverButton.onClick.AddListener(() => {
            networkManager.StartServer();
        });

        hostButton.onClick.AddListener(() => {
            networkManager.StartHost();
        });

        clientButton.onClick.AddListener(() => {
            networkManager.StartClient();
        });
    }
}
