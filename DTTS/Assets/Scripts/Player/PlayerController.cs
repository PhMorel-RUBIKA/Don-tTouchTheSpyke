using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //jump
   bool inputJump;
    bool inJump;
   [SerializeField]
   private float jumpTime;
   private float jumpTimer;
   [SerializeField]
   private float speedJumpTime;
   private float speedJumpTimer;
   [SerializeField]
   private float jumpMaxSpeed;
   private Vector2 currentVelocity;
   [SerializeField]
   private AnimationCurve jumpSpeedCurve;
   [SerializeField]
   private float speedJump;
   //move
   [SerializeField]
   private float speedMove;
   public bool goLeft;
   Vector2 moveVelocity;
   //moveDown
   [SerializeField]
   private float speedMoveDown;
   private Vector2 moveDownVelocity;
   //Other
   [SerializeField]
   Rigidbody2D rb;

   private void Update()
   {
       if (inputJump && CheckJumpTime())
           inJump = true;
       if(inJump) CheckSpeedJumpTime();
   }

   private void FixedUpdate()
   {
       if (inJump)
       {
           moveDownVelocity = Vector2.zero;
          Jump(); 
       }
       else
           MoveDown();
       
        Move();
        UpdateVelocity();
    }

    void Move()
    {
        if(goLeft)
        moveVelocity = Vector2.left*speedMove;
        else
        moveVelocity = Vector2.right*speedMove;
        currentVelocity += moveVelocity;
    }

    void MoveDown()
    {
        float finalSpeedDown;
        finalSpeedDown = moveDownVelocity.y+speedMoveDown;
        moveDownVelocity += Vector2.down * finalSpeedDown;
        currentVelocity += moveDownVelocity;
    }
    void UpdateVelocity()
    {
        rb.velocity = currentVelocity;
        currentVelocity = Vector2.zero;
    }
    
    bool CheckJumpTime()
   {
       if (jumpTime >= jumpTimer)
       {
           jumpTimer += Time.deltaTime;
           return false;
       }
       jumpTimer = 0;
       return true;
   }

    void CheckSpeedJumpTime()
    {
         if (speedJumpTime >= speedJumpTimer)
               {
                   speedJumpTimer += Time.deltaTime;
                   inJump = true;
               }
               else
               {
                     speedJumpTimer = 0;
                            inJump = false;
               }
    }
   void Jump()
   {
       float finalSpeedJump = rb.velocity.y;
       finalSpeedJump += jumpSpeedCurve.Evaluate(speedJumpTimer/speedJumpTime)*speedJump; 
       finalSpeedJump = Mathf.Min(finalSpeedJump, jumpMaxSpeed);
       Vector2 velocityJump = Vector2.up*finalSpeedJump;
       currentVelocity += velocityJump;
   }
   
    public void DetectInput(InputAction.CallbackContext callbackContext)
    {
        inputJump = callbackContext.ReadValueAsButton();
        
    }
}
