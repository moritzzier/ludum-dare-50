using Assets.Scripts.Utilities;
using Pixelplacement;
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
        
        Tween.Value(0, args.score, (int value) =>
        {
            scoreCount.text = value.ToString();
        }, 2f, 1f, Tween.EaseOutStrong);
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
