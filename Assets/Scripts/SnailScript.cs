using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

// References: 
// url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=1079s, 
// title: "How to make Dino Game in Unity",
// author: Zigurous, 
// accessed: Aug 9 2024
public class SnailScript : MonoBehaviour
{
    public CharacterController snail;
    private Vector3 direction;
    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    private bool isInAir = false;

    private bool isAlive = true;

    private AnimatedSprite snailSprite;

    [SerializeField]
    private Sprite injured, defaultSprite;

    // Called automatically when script is initialized
    private void Awake()
    {
        //Debug.Log("Awake was called in SnailScript");
        snail = GetComponent<CharacterController>();
        snailSprite = GetComponent<AnimatedSprite>();

    }

    // Called whenever the script is enabled
    private void OnEnable()
    {
        direction = Vector3.zero;
        //Debug.Log("OnEnable in SnailScript has been called");
    }

    // Update is called once per frame

    // MODIFIES: this 
    // EFFECTS: If the snail is alive, updates direction, calls MoveKeyEvent to make the snail sprite jumping or run if space is pressed, updates the sprite property isInAir
    private void Update()
    {   
       // Debug.Log($"Snail is alive: {isAlive}");
        if (isAlive)
        {
            direction += Vector3.down * gravity * Time.deltaTime;
            MoveKeyEvent();
            snailSprite.SetIsInAir(this.isInAir); //updates the sprite property
            //Debug.Log($"sprite frame : {snailSprite.GetFrame()}");
            snail.Move(direction * Time.deltaTime); //makes the snail fall after jumping
        }

    }

    // EFFECTS: If the snail is on the ground, isInAir is set to false and the direction is down. 
    //          If user presses the spacebar the snail will jump and isInAir is set to true
    private void MoveKeyEvent()
    {
        if (snail.isGrounded)
        {
            direction = Vector3.down;
            isInAir = false;
            if (Input.GetButton("Jump"))
            { //why does this work and not Input.GetKeyDown(KeyCode.Space)?
                isInAir = true;
                SnailJump();
            }
        }
    }

    // REQUIRES: Must be called when the user presses the spacebar
    // MODIFIES: this
    // EFFECTS: Updates the direction
    private void SnailJump()
    {
        direction = Vector3.up * jumpForce;
    }

    // REQUIRES: The snail must collide with an obstacle
    // MODIFIES: GameManager.Instance, this 
    // EFFECTS: When the snail collides with an obstacle, GameOver() is called, an animation plays, the snail sprite is updated, isAlive is set to false.
    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.CompareTag("Obstacle"))
        {
            isAlive = false;
            GameManager.Instance.GameOver();
            snailSprite.SetSpriteImg(injured);
            snailSprite.enabled = false;
        }
    }

    // public AnimatedSprite GetSnailSprite()
    // {
    //     return this.snailSprite;
    // }

    // REQUIRES: Must be called in NewGame() in GameManager 
    // MODIFIES: this 
    // EFFECTS: Resets the sprite to its default image, sets its object to enabled
    public void ResetSnailObject(){
        snailSprite.SetSpriteImg(defaultSprite);
        snailSprite.enabled = true;
    }

    public bool GetIsAlive()
    {
        return this.isAlive;
    }

    public void SetIsAlive(bool b){
        this.isAlive = b;
    }

    public bool IsInAir()
    {
        return this.isInAir;
    }
}
