using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScore_Flappy;
    [SerializeField] private TextMeshProUGUI highScore_Stack;
    [SerializeField] private TextMeshProUGUI highScore_TopDown;

    public int bestScore_Flappy;
    public int bestScore_Stack;
    public int bestScore_TopDown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlappyScore();
        StackScore();
        TopDownScore();

    }

    public void FlappyScore()
    {
        bestScore_Flappy = ScoreManager.GetScore(MinigameType.Flappy);
        highScore_Flappy.text = ScoreManager.GetScore(MinigameType.Flappy).ToString();

        if(bestScore_Flappy > 20)
        {
            // 첫번째 감옥 문 열림
        }
    }

    public void StackScore()
    {
        bestScore_Stack = ScoreManager.GetScore(MinigameType.Stack);
        highScore_Stack.text = ScoreManager.GetScore(MinigameType.Stack).ToString();

        if(bestScore_Stack > 40)
        {
            // 두번째 감옥 문 열림
        }
    }

    public void TopDownScore()
    {
        bestScore_TopDown = ScoreManager.GetScore(MinigameType.TopDown);
        highScore_TopDown.text = ScoreManager.GetScore(MinigameType.TopDown).ToString();

        if(bestScore_Stack > 20)
        {
            // 세번째 감옥 문 열림
        }
    }
}
