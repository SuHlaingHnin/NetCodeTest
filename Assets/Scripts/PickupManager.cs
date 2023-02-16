using Unity.Netcode;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private GameObject pickUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //if(NetworkManager.Singleton.IsServer)
        //{
        //    GameObject go = Instantiate(pickUpPrefab, Vector3.zero, Quaternion.identity);
        //    go.GetComponent<NetworkObject>().Spawn();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
