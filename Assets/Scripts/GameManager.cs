using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private static int points;
    private static int lives = 3;

    public GameObject player;
    public GameObject ball;

    public TMP_Text lifeText;
    public TMP_Text pointText;

    public TMP_Text overText;

    public GameObject gameOver;
    public RawImage backgroundScroll;

    public Color winColor;
    public Color loseColor;

    public List<string> loserTexts;
    public List<string> winnerTexts;

    private bool isGameOver = false;

    async void Start()
    {
        Pause();
        pointText.text = $"Score:{points}";
        lifeText.text = $"Lives:{lives}";
        await new WaitForSeconds(1f);
        Continue();
    }

    public void AddPoints(int point = 1)
    {
        points += point;
        pointText.text = $"Score:{points}";
        
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length <= 0)
        {
            if(!isGameOver)GameOver(true);
            isGameOver = true;
        }
    }

    public void RemoveLife()
    {
        lives--;
        lifeText.text = $"Lives:{lives}";
        if (lives <= 0)
        {
            GameOver(false);
            isGameOver = true;
        }
    }

    public void GameOver(bool hasWon = false)
    {
        Pause();
        
        gameOver.SetActive(true);

        gameOver.GetComponent<RectTransform>().position = new Vector2(0, 500);
        gameOver.GetComponent<RectTransform>().DOMoveY(0, 2f);

        Color resultColor = hasWon ? winColor : loseColor;
        string resultOverText = hasWon ? winnerTexts[Random.Range(0, winnerTexts.Count)] : loserTexts[Random.Range(0, loserTexts.Count)];

        gameOver.GetComponent<Image>().color = resultColor;
        overText.text = resultOverText;
        backgroundScroll.color = resultColor;
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void FullReset()
    {
        SceneManager.LoadScene("GameScene");
        ResetVariables();
    }

    public void ResetVariables()
    {
        lives = 3;
        points = 0;
    }

    public void Pause()
    {
        print("AAAAAAAAA");
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        ball.GetComponent<Ball>().PauseSelf();
        ball.GetComponent<Ball>().CantUnpause();
    }

    public void Continue()
    {
        print("Continued");
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        ball.GetComponent<Ball>().CantUnpause();
    }
}
