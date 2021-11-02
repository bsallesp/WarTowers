using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int initScore;
    [SerializeField] public TextMeshProUGUI scoreTMPro;

    private void Start()
    {
        score = initScore;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTMPro.text = score.ToString();
    }
    public void SetScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }
}
