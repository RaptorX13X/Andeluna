using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Rigidbody2D body;
    
    [Header("Stats")] 
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float jumpMultiplier;

    public bool inAir;

    private void Awake()
    {
        inputReader.JumpEvent += OnJump;
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(inputReader.MovementValue.x * speed, body.linearVelocityY);
        if (inputReader.MovementValue.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (inputReader.MovementValue.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (body.linearVelocityY < 0)
        {
            body.linearVelocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }
        else if (body.linearVelocityY > 0)
        {
            body.linearVelocity += new Vector2 (body.linearVelocityX, (Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime));
        }

        if (body.linearVelocityY == 0)
        {
            inAir = false;
        }
    }

    private void OnJump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, 1f * jump);
        inAir = true;
    }
}
