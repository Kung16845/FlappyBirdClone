using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public TextMeshProUGUI textScore;
    public bool isGameOver;
    public float scrollSpeed = -1.5f;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
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
        Debug.Log("Game Over!");
    }
}
