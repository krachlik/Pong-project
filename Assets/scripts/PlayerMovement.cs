using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    private winningsystem winSystem; // Reference to the winningsystem script

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winSystem = FindObjectOfType<winningsystem>(); // Find the winningsystem script in the scene
    }

    void Update()
    {
        if (winSystem != null && !winSystem.IsGameEnded()) // Check if the game is not ended
        {
            if (isAI)
            {
                AIControl();
            }
            else
            {
                PlayerControl();
            }
        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, 1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMove * movementSpeed;
    }
}