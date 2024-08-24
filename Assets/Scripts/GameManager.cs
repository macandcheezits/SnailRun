using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// reference: This class is modelled after the GameManager class from a tutorial
// youtube url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=5215s
// github url: https://github.com/zigurous/unity-dino-game-tutorial
// title: "How to make a Dino Game in Unity (Complete Tutorial)"
// accessed: Aug 11 2024
// author: zigurous
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private SnailScript snail;
    private Spawner spawner;

    public GameObject gameOverCanvas;

    public bool isGameOver;
    public float gameSpeed { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // MODIFIES: this
    // EFFECTS: Activates snail and spawner. Calls NewGame()
    private void Start()
    {
        snail = FindObjectOfType<SnailScript>();
        spawner = FindObjectOfType<Spawner>();

        snail.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        NewGame();
    }

    // MODIFIES: this
    // EFFECTS: Updates the gameSpeed to be initialGameSpeed, destroys all obstacles if there are any
    public void NewGame()
    {   
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        gameSpeed = initialGameSpeed;
        isGameOver = false;
        this.enabled = true;

        snail.ResetSnailObject();
        gameOverCanvas.SetActive(false);
        spawner.gameObject.SetActive(true);
        
        // Debug.Log($"The sprite is active: {snail.GetSnailSprite().gameObject.activeSelf}");
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    public void GameOver()
    {
        gameSpeed = 0;
        this.enabled = false;
        isGameOver = true;
        spawner.gameObject.SetActive(false);
        gameOverCanvas.SetActive(true);
        //Debug.Log($"gameOver canvas is active: {gameOverCanvas.activeSelf}");
    }
}