
using UnityEngine;
using System;

public class ScoreTracker : MonoBehaviour
{
    public event Action OnScoreUpdated;
    [SerializeField] private int ScorePerFireball = 10; 

    public int Score { get; private set; }

    public void IncreaseScore() {
        Score += ScorePerFireball;
        OnScoreUpdated?.Invoke();
    }

    internal void DecreaseScore(int amount)
    {
        Score -= amount;
        if (Score < 0) {
            Score = 0;
        }
        OnScoreUpdated?.Invoke();
    }
}
