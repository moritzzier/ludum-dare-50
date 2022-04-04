using Assets.Scripts.Utilities;
using Pixelplacement;
using Pixelplacement.TweenSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenuManager : MonoBehaviour
{
    [SerializeField] GameEvent onRestart;
    [SerializeField] GameEvent onMainMenu;

    [SerializeField] TextMeshProUGUI scoreCount;

    public void OnGameOver(GameEventArgs gameEventArgs)
    {
        OnGameOverArgs args = (OnGameOverArgs)gameEventArgs;

        float startSize = scoreCount.fontSize;
        float endSize = startSize * 1.1f;

        TweenBase bumperBase = Tween.Value(startSize, endSize, (float val) => { scoreCount.fontSize = (int)val; }, 0.2f, 0, null, Tween.LoopType.PingPong);

        Tween.Value(0, args.score, (int value) =>
        {
            scoreCount.text = value.ToString();
        }, 2f, 1f, Tween.EaseOut, Tween.LoopType.None, null, () => bumperBase.Cancel());
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
