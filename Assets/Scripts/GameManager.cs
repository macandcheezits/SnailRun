using Unity.VisualScripting;
using UnityEngine;

// reference: This class is modelled after the GameManager class from a tutorial
// youtube url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=5215s
// github url: https://github.com/zigurous/unity-dino-game-tutorial
// title: "How to make a Dino Game in Unity (Complete Tutorial)"
// accessed: Aug 11 2024
// author: zigurous
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    private SnailScript snail;  
    private Spawner spawner;

    public bool isGameOver = false;
    public float gameSpeed { get; private set;}
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    private void Awake(){
        if (Instance == null){
            Instance = this;
        } else {
            DestroyImmediate(gameObject);
        }
        
    }

    private void OnDestroy(){
        if(Instance == this){
            Instance = null;
        }
    } 

    private void Start(){
        snail = FindObjectOfType<SnailScript>();
        spawner = FindObjectOfType<Spawner>();

        snail.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        NewGame();
    }

    private void NewGame(){
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>(); 

        foreach (var obstacle in  obstacles){
            Destroy(obstacle.gameObject);
        }
        
        gameSpeed = initialGameSpeed;
    }

    private void Update(){
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    public void GameOver(){
        gameSpeed = 0;
        enabled = false;
        isGameOver = true;
        snail.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

    }
}