using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EscapeManger escapeManger;
    public EnemyPlayerKill enemyPlayerKill;
    public GameObject[] Characters;
    public GameObject endGamePanel;
    public Text gameOverText;
    public Camera deathCamera;

    public enum GameState { Start, Playing, GameOver };
    private GameState gameState;
    public GameState State { get { return gameState; } }
    // Start is called before the first frame update
    void Awake()
    {
        deathCamera.gameObject.SetActive(false);
        endGamePanel.SetActive(false);
        gameState = GameState.Playing;
        gameOverText.text = "";
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                bool isGameOver = false;
                if (escapeManger.playerHasEscaped)
                {
                    isGameOver = true;
                }
                if (isPlayerDead())
                {
                    isGameOver = true;
                }
                if (isGameOver)
                {
                    deathCamera.gameObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                    gameState = GameState.GameOver;
                    endGamePanel.SetActive(true);

                    if(escapeManger.playerHasEscaped)
                    {
                        gameOverText.text = "You Escaped";
                    } else
                    {
                        gameOverText.text = "You Died";
                    }
                }
                break;
        }
    }
    
    private bool isPlayerDead()
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Characters[i].activeSelf == false)
            {
                if (Characters[i].tag == "Player") return true;
            }
        }
        return false;
    }
}
