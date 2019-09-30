using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int lives = 3;
    private int points = 0;
    private int level = 1;
    private int totalEnemies = 24;
    private int enemyRows = 4;
    [SerializeField] Text scoreboardText;
    [SerializeField] Text gameoverText;
    [SerializeField] GameObject enemyPrefab;


    private void Start()
    {
        gameoverText.enabled = false;
        DisplayStatus();
        GenerateEnemies();
    }


    public void PlayerHit()
    {
        lives--;
        DisplayStatus();
        if (lives <= 0)
            StartCoroutine(FinishGame());
    }

    public void EnemyHit()
    {
        points += 10;
        totalEnemies--;
        DisplayStatus();
        Debug.Log(totalEnemies);
        
    }

    void DisplayStatus()
    {
        scoreboardText.text = "Level " + level+"   Points " + points +
            "   Lives " + lives;
    }

    void GenerateEnemies()
    {
        float x = enemyPrefab.transform.position.x; 
        float y = enemyPrefab.transform.position.y;
        Vector3 position;
        for (int j = 0; j < enemyRows; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                position = new Vector3(x, y);
                Instantiate(enemyPrefab, position, Quaternion.identity);
                x += 1;
            }
            y -= 1;
            x = enemyPrefab.transform.position.x;
        }
    }
    IEnumerator FinishGame()
    {
        gameoverText.enabled = true;
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(4);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
