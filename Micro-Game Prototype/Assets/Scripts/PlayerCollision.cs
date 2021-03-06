using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovements movement;
    public GameObject gameOverUI;
    public static bool gameIsPaused;

    public void NewGame()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            gameIsPaused = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Cactus" || collision.collider.tag == "Bird")
        {
            movement.enabled = false;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }

}
