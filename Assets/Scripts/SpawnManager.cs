using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)//If game status not gameover, keep spawning obstacles. Increases score by 5
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            UpdateScore(5);

        }
        
    }

    public void UpdateScore(int scoreToAdd)//Updates score text and score
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()//Set gameover text and shows the restart button
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()//Simply restarts the scene as it was when started.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()//Sets all variables to default and starts the game.
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        score = 0;
        UpdateScore(0);
        playerControllerScript.gameOver = false;
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        playerControllerScript.playerAnim.SetFloat("Speed_f", 1);
    }
}
