using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false) //Runs game status is not gameover
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);//Obstacles and background moving left
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))//If object moves to out of screen, remove object
        {
            Destroy(gameObject);
        }
        
        
    }
}
