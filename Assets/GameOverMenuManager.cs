using Assets.Scripts.Utilities;
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
        scoreCount.text = args.score.ToString();
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
