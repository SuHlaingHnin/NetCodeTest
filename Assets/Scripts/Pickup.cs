using Unity.Netcode;
using UnityEngine;

public class Pickup : NetworkBehaviour
{
    private NetworkObject m_SpawnedNetworkObject;

    //public override void OnNetworkSpawn()
    //{
    //    enabled = IsServer;

    //    if (!enabled) return;

    //    m_SpawnedNetworkObject = transform.GetComponent<NetworkObject>();
    //    m_SpawnedNetworkObject.Spawn();
    //}

    public override void OnNetworkDespawn()
    {
        gameObject.SetActive(false);
        base.OnNetworkDespawn();
    }

    void Start()
    {
        //GameObject go = Instantiate(pickUpPrefab, Vector3.zero, Quaternion.identity);
        //if(NetworkManager.Singleton.IsServer)
        //    transform.GetComponent<NetworkObject>().Spawn();
    }

    public void Spawn(bool destroyWithScene)
    {
        if (IsServer && !IsSpawned)
        {
            gameObject.SetActive(true);
            NetworkObject.Spawn(destroyWithScene);
        }
    }
}
