using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Vang2 : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
   // [SerializeField] private Animator anim;
    [SerializeField] private int scoreValue = 1;

    void Start()
    {
        int savedScore = PlayerPrefs.GetInt("Player2");
        UpdateScoreText(savedScore);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            int currentScore = PlayerPrefs.GetInt("Player2");
            currentScore += scoreValue;
            PlayerPrefs.SetInt("Player2", currentScore);
            PlayerPrefs.Save();
            UpdateScoreText(currentScore);
            Destroy(this.gameObject);
        }
    }

 private void UpdateScoreText(int score)
    {
        if (scoreText != null)
      {
           scoreText.text = "Score: " + score;
       }
    }
}