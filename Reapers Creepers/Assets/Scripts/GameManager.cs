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
    public Button exitGame;
    public Button winGame;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public GameObject player;
    private int nextSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<PlayerMovement>()._dead == true)
        {
            GameOver();
        }
        if(player.GetComponent<PlayerMovement>()._dead == true && player.GetComponent<PlayerMovement>()._soulCaptured == true)
        {
            winGame.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
        }
        if(player.GetComponent<PlayerMovement>()._dead == false && player.GetComponent<PlayerMovement>()._soulCaptured == true)
        {
            winGame.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
        }
        
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        exitGame.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        _gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {      
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
