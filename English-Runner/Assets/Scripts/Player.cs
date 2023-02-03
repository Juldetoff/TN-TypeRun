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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDist = Mathf.Abs(pos.y - groundHeight);
        if (isOnGround || groundDist<=jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isOnGround = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate()
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
}
