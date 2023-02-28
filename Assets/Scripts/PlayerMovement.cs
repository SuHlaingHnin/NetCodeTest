using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour   
{
    [SerializeField] private float speed;

    private Rigidbody rb;

    //int score;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pickup"))
        {
            NetworkObject pickup = collision.gameObject.GetComponent<NetworkObject>();

            if (NetworkManager.Singleton.IsServer)
            {
                DespawnPickup(pickup);
            } else
            {
                DespawnPickupServerRpc(pickup);
            }

            GameManager.Instance.UpdateScore();
        }
        else
        {
            Debug.Log("No Collison Enter");
        }
    }

    [ServerRpc]
    void DespawnPickupServerRpc(NetworkObjectReference networkObjectReference)
    {
        if(networkObjectReference.TryGet(out NetworkObject pickup)) {
            DespawnPickup(pickup);
        }
        else
        {
            Debug.LogWarning("Pickup not found to despawn!");
        }
    }

    void DespawnPickup(NetworkObject pickup)
    {
        pickup.Despawn(false);

        PickupManager.Instance.RemovePickupFromList(pickup.transform);
    }
}
