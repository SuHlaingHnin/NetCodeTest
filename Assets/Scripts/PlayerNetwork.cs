using System;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerNetwork : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    float movementSpeed = 3f;

    public override void OnNetworkSpawn()
    {
        if(IsOwner)
        {
            Move();
        }
    }

    private void Update()
    {
        if (!IsOwner) return;

        transform.position = Position.Value;

        //Vector3 moveDirection = new Vector3(0, 0, 0);

        //if (Input.GetKey(KeyCode.W)) moveDirection.z += 1f;
        //if (Input.GetKey(KeyCode.A)) moveDirection.x -= 1f;
        //if (Input.GetKey(KeyCode.S)) moveDirection.z -= 1f;
        //if (Input.GetKey(KeyCode.D)) moveDirection.x += 1f;

        //transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    private void Move()
    {
        if(NetworkManager.Singleton.IsServer)
        {
            Vector3 randomPosition = GetRandomPositionOnPlane();
            transform.position = randomPosition;
            Position.Value = randomPosition;
        } else
        {
            SubmitPositionRequestServerRpc();
        }
    }

    [ServerRpc]
    private void SubmitPositionRequestServerRpc(ServerRpcParams serverRpcParams = default)
    {
        Position.Value = GetRandomPositionOnPlane();
    }

    private Vector3 GetRandomPositionOnPlane()
    {
        return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
    }
}
