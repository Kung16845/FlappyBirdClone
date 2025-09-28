using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public BirdController bird; 
    public ColumnPooling columnPooling;
    public int score;
    public int highScore;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textCurrentScore;
    public TextMeshProUGUI textHighScore;
    public TextMeshProUGUI textHighMainMenuScore;
    public bool isGameOver;
    public float scrollSpeed = -1.5f;
    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
    public GameObject showHighScorePanel;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {   
        bird.gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);  
        showHighScorePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void NewGame()
    {   
        bird.gameObject.SetActive(true);    
        mainMenuPanel.SetActive(false);  
        gameOverPanel.SetActive(false);
        bird.ResetAnim();
        bird.isDead = false;
        isGameOver = false;
        score = 0;
        textScore.text = "Score : " + score.ToString();
        bird.transform.position = new Vector3(0, 0, 0);
        columnPooling.ResetColumns();
    }
    public void BirdScored()
    {
        if (isGameOver) return;
        AudioManager.instance.PlaySoundEffect(Sound.Score);
        score++;
        textScore.text = "Score : " + score.ToString();
        Debug.Log("Score: " + score);
    }
    public void BirdDied()
    {   
        AudioManager.instance.PlaySoundEffect(Sound.Die);
        isGameOver = true;
        gameOverPanel.SetActive(true);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        textCurrentScore.text = score.ToString();
        textHighScore.text = highScore.ToString();
    }
    public void ShowHighScore()
    {   
        showHighScorePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        textHighMainMenuScore.text = highScore.ToString();
    }
    public void BackToMainMenu()
    {
        showHighScorePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
   
}
