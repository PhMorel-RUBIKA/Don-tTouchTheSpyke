using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator menuAnimator;

    public bool launchGame;
    private InputMaster mapping;
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

   private void Awake() {
       mapping = new InputMaster();
       mapping.MainPlayer.Enable();
       mapping.MainPlayer.Jump.started += DetectInput;
       mapping.MainPlayer.Jump.canceled += DetectInput;
   }

   private void Update()
   {
       if (launchGame)
       {
           rb.gravityScale = 0.5f;
                  jumpTimer += Time.deltaTime;
                  if (CheckJumpTime() && inputJump) {
                      inJump = true;
                      SoundCaller.instance.JumpSound();
                      jumpTimer = 0;
                  }
                  if(inJump) CheckSpeedJumpTime();
       }
       else
       {
           rb.gravityScale = 0;
           rb.velocity = Vector2.zero;
           if (inputJump)
           {
               menuAnimator.Play("MainMenuAnim");
           }
       }

   }

   private void FixedUpdate()
   {
       if (launchGame)
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
        moveDownVelocity += Vector2.down * speedMoveDown;
        currentVelocity += moveDownVelocity;
    }
    void UpdateVelocity()
    {
        rb.velocity = currentVelocity;
        currentVelocity = Vector2.zero;
    }
    
    bool CheckJumpTime() => jumpTimer >= jumpTime;

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

   private void DetectInput(InputAction.CallbackContext callbackContext) {
       Debug.Log("ok");
       inputJump = callbackContext.ReadValueAsButton();
   }
}
