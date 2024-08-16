using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{   
    private SpriteRenderer movingObstacle; 

    //public float initVelocity = 0f; 
    public float velocity = 1f;

    void Awake(){
        movingObstacle = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // EFFECTS: Moves the position of the snail
    void Update()
    {   
        if(movingObstacle.isVisible && !GameManager.Instance.isGameOver){
            transform.position = transform.position + (Vector3.left * velocity) * Time.deltaTime;
        }
        
    }
}
