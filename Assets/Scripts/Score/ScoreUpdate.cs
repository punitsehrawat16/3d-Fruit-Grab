using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public static ScoreUpdate Instance;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] private GameObject uiPrefab;
    public RectTransform uiRectTransform;
    public int score = 0;

    public void Awake()
    {
        Instance = this;
        uiRectTransform=GetComponent<RectTransform>();
    }

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }


    private void UpdateScoreInUi()
    {
        scoreText.text = "Score: " + score;
    }
    public void PlayScoreAnimation(ItemData data, Vector3 pos)
    {
        var gO=Instantiate(uiPrefab, uiRectTransform);
        var Img = gO.GetComponent<Image>();
       
        Img.rectTransform.position = pos;
        Img.sprite = data.sprite;
        Img.SetNativeSize();
        var leanTween = Img.rectTransform.LeanMove(Vector3.zero, 1f).setEaseInOutCubic();
        var Scaleanimation  = Img.rectTransform.LeanScale(Vector3.zero, 1f).setEaseInOutCubic().setOnComplete(() => { Destroy(gO); });
        score += 10;
        UpdateScoreInUi();
    }
}
