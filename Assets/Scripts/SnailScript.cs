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
    private CharacterController snail; 
    private Vector3 direction; 
    public float gravity = 9.81f * 2f; 
    public float jumpForce = 8f;

    // Called automatically when script is initialized
    private void Awake(){
        Debug.Log("Awake() was called");
        snail = GetComponent<CharacterController>();
    }

    // Called whenever the script is enabled
    private void OnEnable(){
        direction = Vector3.zero;
    }

    // Start is called before the first frame update
    
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime; 

        if(snail.isGrounded){
            direction = Vector3.down;

            if(Input.GetButton("Jump")){ //why does this work and not Input.GetKeyDown(KeyCode.Space)?
                //Debug.Log("You jumped");                  
                direction = Vector3.up * jumpForce;
            }
        }

        snail.Move(direction * Time.deltaTime);
    }

}
