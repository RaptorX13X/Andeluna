using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] PlayerAudio playerAudio;
    
    [Header("Stats")] 
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float jumpMultiplier;

    public bool inAir;

    private float walkCooldown;

    private void Awake()
    {
        inputReader.JumpEvent += OnJump;
        walkCooldown = 1f;
    }

    private void Update() //jezeli movement na platformie bedzie wonky - dac parent na null jezeli postac sie rusza
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
            if (inAir)
            {
               playerAudio.PlayLanding();
            }
            inAir = false;
            
            
        }

        if (inputReader.MovementValue.x != 0)
        {
            if(walkCooldown > 0.01f)
            {
                walkCooldown -= Time.deltaTime;
            }
            else
            {
                playerAudio.PlayFootsteps();
                walkCooldown = 1f;
            }
        }
    }

    private void OnJump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, 1f * jump);
        inAir = true;
        playerAudio.PlayJump();
    }

    public void JumpPad(float jumpPower)
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower * jump);
        inAir = true;
    }

    public void Lift(float liftPower)
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, liftPower);
        inAir = true;
    }
}
