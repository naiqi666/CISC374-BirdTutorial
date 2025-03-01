using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    private bool isGameOver = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if(!isGameOver)
        {
            audioManager.playSound(audioManager.score);
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
        
    }

    public void restartGame()
    {
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {

        isGameOver = true;
        gameOverScreen.SetActive(true);
        audioManager.playSound(audioManager.gameOver);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > highScore)
        {
            
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + playerScore.ToString();
        }
    }
}
