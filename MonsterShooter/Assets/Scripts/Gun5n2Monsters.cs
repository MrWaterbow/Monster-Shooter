using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gun5n2Monsters : MonoBehaviour
{
    public int hP;
    public int points;
    public Text hPText;
    public static Text scoreText;
    public static int score;

    public void Score(int scoreToAdd)
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if(score >= 30)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene("Gun5n2");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            score = 0;
        }
    }

    private void HPMonsters()
    {
        hPText = GameObject.Find("HPText").GetComponent<Text>();
        hPText.text = "Monster HP: " + hP;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
            hP--;
            if (hP <= 0)
            {
                Score(points);
                Destroy(gameObject);
            }
            if (hP == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (hP == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (hP == 3)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }

    void Update()
    {
        HPMonsters();
    }
}
