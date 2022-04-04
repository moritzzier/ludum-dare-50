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
    [SerializeField] GameEvent onRestart;
    [SerializeField] GameEvent onMainMenu;

    [SerializeField] TextMeshProUGUI scoreCount;
    [SerializeField] TextMeshProUGUI highscoreCount;
    [SerializeField] TextMeshProUGUI highscoreMessage;

    public void OnGameOver(GameEventArgs gameEventArgs)
    {
        OnGameOverArgs args = (OnGameOverArgs)gameEventArgs;
        bool isNewHighscore = false;

        //Highscore Checks
        int highscore = PlayerPrefs.GetInt("Highscore");

        highscoreMessage.fontSize = 0;
        highscoreCount.text = $"{highscore}";

        if (args.score > highscore)
        {
            isNewHighscore = true;
            PlayerPrefs.SetInt("Highscore", args.score);
        }


        //Animations
        float startSize = scoreCount.fontSize;
        float endSize = startSize * 1.1f;

        //ScorePump
        TweenBase bumperBase = Tween.Value(startSize, endSize, (float val) => { scoreCount.fontSize = (int)val; }, 0.2f, 0, null, Tween.LoopType.PingPong);

        //ScoreCountUP
        Tween.Value(0, args.score, (int value) =>
        {
            scoreCount.text = value.ToString();
        }, 2f, 1f, Tween.EaseOut, Tween.LoopType.None, null, () =>
        {
            bumperBase.Cancel();
            if (isNewHighscore)
            {
                ShowHighscoreMessage(highscore, args.score);
            }
        });
    }

    void ShowHighscoreMessage(int oldHighscore, int newHighscore)
    {
        Tween.Value(oldHighscore, newHighscore, (int val) => { highscoreCount.text = $"{val}"; }, 0.25f, 0, Tween.EaseInOutBack);
        //Highscore Message
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
