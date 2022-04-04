using Assets.Scripts.Utilities;
using Pixelplacement;
using Pixelplacement.TweenSystem;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class GameOverMenuManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveHighscore(int score);
    [DllImport("__Internal")]
    private static extern int GetHighscore();

    [SerializeField] GameEvent onRestart;
    [SerializeField] GameEvent onMainMenu;

    [SerializeField] TextMeshProUGUI scoreCount;
    [SerializeField] TextMeshProUGUI highscoreCount;
    [SerializeField] TextMeshProUGUI highscoreMessage;

    public void OnGameOver(GameEventArgs gameEventArgs)
    {
        OnGameOverArgs args = (OnGameOverArgs)gameEventArgs;

        float startSize = scoreCount.fontSize;
        float endSize = startSize * 1.1f;

        TweenBase bumperBase = Tween.Value(startSize, endSize, (float val) => { scoreCount.fontSize = (int)val; }, 0.2f, 0, null, Tween.LoopType.PingPong);

        Tween.Value(0, args.score, (int value) =>
        {
            scoreCount.text = value.ToString();
        }, 2f, 1f, Tween.EaseOut, Tween.LoopType.None, null, () =>
        {
            bumperBase.Cancel();
            CompareHighscore(args.score);
        });
    }

    public void CompareHighscore(int score)
    {
        try
        {
            int highscore = GetHighscore();
            highscoreCount.text = $"{highscore}";
            if (score > highscore)
            {
                highscoreCount.text = $"{score}";
                SaveHighscore(score);
                ShowHighscoreMessage();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
            highscoreCount.text = $"{score}";
        }
    }

    void ShowHighscoreMessage()
    {
        Tween.Value(0, 36, (int val) => { highscoreMessage.fontSize = val; }, 0.25f, 0, Tween.EaseInOutBack);
    }

    public void OnRestart()
    {
        onRestart.Invoke();
    }

    public void OnMainMenu()
    {
        onMainMenu.Invoke();
    }
}
