using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score += newScore;
        score = Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
