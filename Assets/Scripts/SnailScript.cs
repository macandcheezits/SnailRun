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

    public bool isInAir = false;

    private AnimatedSprite sprite;

    // Called automatically when script is initialized
    private void Awake(){
        Debug.Log("Awake was called in SnailScript");
        snail = GetComponent<CharacterController>();
        sprite = GetComponent<AnimatedSprite>();
    }

    // Called whenever the script is enabled
    private void OnEnable(){
        direction = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime; 
        CheckIfSnailGrounded();
        sprite.IsInAir = isInAir; //updates the sprite property
        snail.Move(direction * Time.deltaTime);
    }

    private void CheckIfSnailGrounded(){
        if(snail.isGrounded){
            direction = Vector3.down;
            isInAir = false;
            if(Input.GetButton("Jump")){ //why does this work and not Input.GetKeyDown(KeyCode.Space)?
                isInAir = true;                 
                SnailJump();
            }
        }
    }

    private void SnailJump(){
        direction = Vector3.up * jumpForce;
    }

    private void OnTriggerEnter(Collider obstacle){
        if(obstacle.CompareTag("Obstacle")){
            GameManager.Instance.GameOver();
        }
    }

}
