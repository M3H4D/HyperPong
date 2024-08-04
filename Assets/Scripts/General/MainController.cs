using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    private int P1Score;
    private int P2Score;
    public static int difficulty;

    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;

    public GameObject PlayScene;
    public GameObject textGO;
    public GameObject Ball;
    public GameObject Paddle1;
    public GameObject Paddle2;
    public TMP_Text text;

    public GameObject ad;
    // Start is called before the first frame update
    void Start()
    {
        P1Score = 0;
        P2Score = 0;
        StartCoroutine(playState());
    }

    void Update()
    {
        Score1.text = P1Score.ToString();
        Score2.text = P2Score.ToString();
        StartCoroutine(GameOverState());
    }


    public void incrementP1Score()
    {
        P1Score++;
    }
    public void incrementP2Score()
    {
        P2Score++;
    }


    public void quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator GameOverState()
    {
        if (P1Score == 5)
        {
            Ball.SetActive(false);
            Paddle1.SetActive(false);
            Paddle2.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            PlayScene.SetActive(false);
            textGO.SetActive(true);
            text.text = "P1 WINS!";
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("MainMenu");
        }
        else if(P2Score == 5)
        {
            Ball.SetActive(false);
            Paddle1.SetActive(false);
            Paddle2.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            PlayScene.SetActive(false);
            textGO.SetActive(true);
            text.text = "P2 WINS!";
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator playState()
    {
        Ball.SetActive(false);
        Paddle1.SetActive(false);
        Paddle2.SetActive(false);
        PlayScene.SetActive(false);
        textGO.SetActive(true);
        text.text = "SCORE 5 POINTS TO WIN";

        yield return new WaitForSeconds(2);
        Ball.SetActive(true);
        Paddle1.SetActive(true);
        Paddle2.SetActive(true);
        PlayScene.SetActive(true);
        textGO.SetActive(false);
    }
}
