using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public GameObject rightPaddleP2;
    public GameObject ball;

    // UI

    public int leftScore;
    public TMP_Text leftScoreText;

    public int rightScore;
    public TMP_Text rightScoreText;

    public float timeLeft;
    public TMP_Text countdownText;

    public GameObject middleOfNet;

    public Button restartButton;
    public TMP_Text gameOverText;

    void Update()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();

        if (leftScore == 3 || rightScore == 3)
        {
            EndGame();
        }
        else
        {
            RunCountdown();
        }
    }

    public void ResetBoard()
    {
        leftPaddle.transform.position = new Vector3(-14, 0);
        rightPaddle.transform.position = new Vector3(14, 0);
        rightPaddleP2.transform.position = new Vector3(14, 0);
        ball.transform.position = new Vector3(0, 0);

        timeLeft = 2.0f;
    }

    public void RunCountdown()
    {
        if (timeLeft > 0)
        {
            HideBackground();
            TogglePause(GameState.Paused);

            timeLeft -= Time.unscaledDeltaTime;
            countdownText.text = timeLeft.ToString("0.0");
        }
        else
        {
            ShowBackground();
            TogglePause(GameState.Unpaused);
        }
    }

    private void TogglePause(GameState gameState)
    {
        if (gameState == GameState.Paused) Time.timeScale = 0;
        if (gameState == GameState.Unpaused) Time.timeScale = 1;
    }

    private void ShowBackground()
    {
        countdownText.gameObject.SetActive(false);
        middleOfNet.SetActive(true);
        ball.GetComponent<Renderer>().enabled = true;
    }

    private void HideBackground()
    {
        countdownText.gameObject.SetActive(true);
        middleOfNet.SetActive(false);
        ball.GetComponent<Renderer>().enabled = false;
    }

    private void EndGame()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        middleOfNet.SetActive(false);
        ball.GetComponent<Renderer>().enabled = false;
        TogglePause(GameState.Paused);
    }

    private enum GameState { Paused, Unpaused }
}
