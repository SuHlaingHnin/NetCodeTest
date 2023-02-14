using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    float movementSpeed = 3f;

    private void Update()
    {
        if (!IsOwner) return;

        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDirection.z += 1f;
        if (Input.GetKey(KeyCode.A)) moveDirection.x -= 1f;
        if (Input.GetKey(KeyCode.S)) moveDirection.z -= 1f;
        if (Input.GetKey(KeyCode.D)) moveDirection.x += 1f;

        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }
}
