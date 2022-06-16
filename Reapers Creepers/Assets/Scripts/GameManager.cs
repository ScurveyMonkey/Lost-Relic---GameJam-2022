using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool _gameOver;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerMovement>()._dead == true)
        {
            GameOver();
        }
        
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        _gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
