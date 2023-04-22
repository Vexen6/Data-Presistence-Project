using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public TMP_Text highScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        highScoreTxt = gameObject.GetComponent<TMP_Text>();
        highScoreTxt.text= $"1. {ScoreManager.Instance.highScoreName1} {ScoreManager.Instance.highScore1} " +
            $"\n2. { ScoreManager.Instance.highScoreName2} { ScoreManager.Instance.highScore2} " +
            $"\n3. {ScoreManager.Instance.highScoreName3} {ScoreManager.Instance.highScore3}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
