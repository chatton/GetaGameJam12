using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    ScoreTracker ScoreTracker;
    TextMeshProUGUI Text;

    void Start()
    {
        ScoreTracker = FindObjectOfType<ScoreTracker>();
        Text = GetComponent<TextMeshProUGUI>();
        ScoreTracker.OnScoreUpdated += UpdateText;

    }

    private void UpdateText() {
        Text.text = "Score: " + ScoreTracker.Score;
    }

    public void PlayAnimation() {

    }

}
