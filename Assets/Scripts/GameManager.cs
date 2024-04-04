using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager menuManager;

    private static int points;
    private static int lives = 3;

    public TMP_Text lifeText;
    public TMP_Text pointText;

    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        if (!menuManager)
        {
            menuManager = this;
            DontDestroyOnLoad(menuManager);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int point = 1)
    {
        points += point;
        pointText.text = $"Score:{points}";
        
    }

    public void DestroyCheck()
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length <= 1)
        {
            winScreen.SetActive(true);
            //add await
            FullReset();
        }
    }

    public void RemoveLife()
    {
        lives--;
        lifeText.text = $"Lives:{lives}";

        if(lives <= 0)
        {
            loseScreen.SetActive(true);
            //add await

            FullReset();
        }
    }

    public void FullReset()
    {
        SceneManager.LoadScene("SampleScene");
        lives = 3;
        points = 0;
        pointText.text = $"Score:{points}";
        lifeText.text = $"Lives:{lives}";
    }
}
