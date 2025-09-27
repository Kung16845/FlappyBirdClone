using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public BirdController bird;
    public static GameManager instance;
    public ColumnPooling columnPooling;
    public int score;
    public int highScore;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textCurrentScore;
    public TextMeshProUGUI textHighScore;
    public bool isGameOver;
    public float scrollSpeed = -1.5f;
    public GameObject gameOverPanel;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {
        Init();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void BirdScored()
    {
        if (isGameOver) return;
        score++;
        textScore.text = "Score : " + score.ToString();
        Debug.Log("Score: " + score);
    }
    public void BirdDied()
    {
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
    public void Restart()
    {
        Init();
    }

    private void Init()
    {
        bird.isDead = false;
        isGameOver = false;
        score = 0;
        textScore.text = "Score : " + score.ToString();
        gameOverPanel.SetActive(false);
        bird.transform.position = new Vector3(0, 0, 0);
        columnPooling.ResetColumns();
    }
}
