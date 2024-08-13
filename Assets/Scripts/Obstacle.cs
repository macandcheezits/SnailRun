using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;
    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed;

        if(transform.position.x < leftEdge){
            Destroy(gameObject);
        }
    }
}
