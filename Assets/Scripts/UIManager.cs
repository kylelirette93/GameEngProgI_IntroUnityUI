using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    int score;
    int addedScore;
    public TextMeshProUGUI scoreOutputText;
    public RectTransform shakeTransform, catTransform;

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore(int value)
    {
        addedScore += value;
        score += addedScore;
        if (addedScore > 0)
        {
            if (shakeTransform != null)
            {
                var newSequence = DOTween.Sequence();
                newSequence.Append(catTransform.DOMoveX(200f, 0.4f).SetRelative(true));
                newSequence.AppendInterval(0.5f);
                newSequence.Append(shakeTransform.DOShakeScale(1.0f));
            }
        }
        else
        {
            var newSequence = DOTween.Sequence();
            newSequence.Append(catTransform.DOMoveX(-200f, 0.4f).SetRelative(true));
        }
        
    }

    public void ResetScore()
    {
        score = 0;
        scoreOutputText.text = score.ToString();
    }
}
