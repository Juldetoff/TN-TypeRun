using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float gravity;
    public Vector2 velocity;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float distance = 0;
    public float jumpVelocity = 20;
    public float maxXVelocity = 100;
    public float groundHeight = 10;
    public bool isOnGround = false; 

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f; //remplacable par coroutine
    public float jumpGroundThreshold = 0.1f;

    public int lives = 3; //augmentable via skin ou bonus
    private float accRatio = 1.25f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lives>0){Vector2 pos = transform.position;
        float groundDist = Mathf.Abs(pos.y - groundHeight);
        if (isOnGround || groundDist<=jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space) & false)
            {
                isOnGround = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }}
    }

    private void FixedUpdate()
    {
        if(lives>0)
        {
        Vector2 pos = transform.position;
        if (!isOnGround)
        {
            if (isHoldingJump){
                holdJumpTimer += Time.fixedDeltaTime;
                if(holdJumpTimer > maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }
            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            if(pos.y<= groundHeight)
            {
                pos.y = groundHeight;
                isOnGround = true;
                holdJumpTimer = 0.0f;
            }
        }

        distance += velocity.x * Time.fixedDeltaTime;
        if (velocity.x > maxXVelocity*0.99f){ 
            maxXVelocity = maxXVelocity * accRatio;
            accRatio = (accRatio-1)/1.3f + 1;
        }

        if (true)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            velocity.x += acceleration * Time.fixedDeltaTime;
            if(velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }
        transform.position = pos;
        }
        else{
            Vector2 pos = transform.position;
            velocity.y += gravity * Time.fixedDeltaTime;
            pos.y += velocity.y * Time.fixedDeltaTime;
            transform.position = pos;
        }
    }

    public void GettingHit()
    {
        lives--;
        if(lives<=0)
        {
            //TODO, animation de mort avec écrit game over et retour menu
            gameOver();
        }
        else
        {
            //respawn
        }
    }

    public void GettingHealth()
    {
        lives++;
    }

    public float GetRatio(){
        return accRatio;
    }

    public void gameOver(){
        Vector2 posi = transform.position;
        velocity.y = jumpVelocity;
        posi.y += velocity.y * Time.fixedDeltaTime;
        transform.position = posi; 
        Animator playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("gameOver", true);
    }
}
