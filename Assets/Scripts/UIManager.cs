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
    bool sequenceStarted = false;

    private void Start()
    {
        score = 0;
        ResetScore();
    }

    public void UpdateScore(int value)
    {
        addedScore = value;
        score += addedScore;
        scoreOutputText.text = score.ToString();
        if (addedScore > 0 && shakeTransform != null)
        {
            if (!sequenceStarted)
            {
                sequenceStarted = true;
                var newSequence = DOTween.Sequence();
                newSequence.Append(catTransform.DOMoveX(425f, 0.1f).SetRelative(true));
                newSequence.Append(catTransform.DORotate(catTransform.rotation.eulerAngles + new Vector3(0, 0, -10), 0.1f).SetLoops(10, LoopType.Yoyo));
                newSequence.Append(shakeTransform.DOShakeScale(1.0f));
                newSequence.Append(catTransform.DOMoveX(-425f, 0.1f).SetRelative(true));
                newSequence.OnComplete(() => sequenceStarted = false);
            }
        }        
    }

    public void ResetScore()
    {
        score = 0;
        scoreOutputText.text = score.ToString();
    }
}
