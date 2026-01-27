using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public float gameDuration = 120f; // 2 minutes

    private float timer;
    private bool gameRunning = false;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (gameRunning)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();

            if (timer <= 0)
            {
                EndGame();
            }
        }
        else
        {
            // Restart when player grabs sword (simulate with spacebar for now)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void StartGame()
    {
        score = 0;
        UpdateScoreUI();
        timer = gameDuration;
        gameRunning = true;
    }

    void EndGame()
    {
        gameRunning = false;
        timerText.text = "Time: 0";
        // Optionally show a final score panel
        scoreText.text = "Final Score: " + score;
    }

    public void AddScore(int value)
    {
        if (!gameRunning) return;
        score += value;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}