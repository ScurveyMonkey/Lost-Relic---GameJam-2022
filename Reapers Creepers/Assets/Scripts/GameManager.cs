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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        _gameOver = true;

    }

    void StartGame()
    {
        _gameOver = false;
        SceneManager.LoadScene(1);
    }
}
