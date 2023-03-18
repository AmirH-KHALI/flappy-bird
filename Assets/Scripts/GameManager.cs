using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Bird bird;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject playBottom;

    public AudioSource audioSource;
    public AudioClip hit;
    public AudioClip point;



    private int score = 0;

    private void Awake() {
        Pause();
    }

    private void Pause() {
        Time.timeScale = 0f;
        bird.enabled = false;

    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        playBottom.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        bird.enabled = true;

        Pipe[] pipes = FindObjectsOfType<Pipe>();
        foreach (Pipe pipe in pipes) {
            Destroy(pipe.gameObject);
        }
    }

    public void GameOver() {
        audioSource.PlayOneShot(hit);

        Debug.Log("Game Over!");
        playBottom.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void IncreaseScore() {
        audioSource.PlayOneShot(point);

        score++;
        scoreText.text = score.ToString();
        Debug.Log("Score: " + score);
    }
}
