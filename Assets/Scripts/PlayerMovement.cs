using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour   
{
    [SerializeField] private float speed;

    private GameUI gameUI;
    private Rigidbody rb;

    int score;

    private void Start()
    {
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
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
            collision.gameObject.SetActive(false);
            UpdateScore();
        }
        else
        {
            Debug.Log("No Collison Enter");
        }
    }

    private void UpdateScore()
    {
        score++;
        gameUI.UpdateScoreUI(score);
    }
}
