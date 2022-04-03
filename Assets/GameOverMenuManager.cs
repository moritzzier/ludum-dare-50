using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuManager : MonoBehaviour
{
    [SerializeField] GameEvent onRestart;
    [SerializeField] GameEvent onMainMenu;

    public void OnGameOver(GameEventArgs gameEventArgs)
    {
        OnGameOverArgs args = (OnGameOverArgs)gameEventArgs;
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
