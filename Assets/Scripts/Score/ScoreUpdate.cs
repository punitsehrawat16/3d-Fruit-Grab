using System;
using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    public static ScoreUpdate Instance;
    [SerializeField] public TextMeshProUGUI scoreText;
    public int score = 0;

    public void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }


    public void UpdateScoreInUi()
    {
        scoreText.text = "Score: " + score;
    }
}
