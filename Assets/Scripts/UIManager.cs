using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    StateMachine stateMachine;

    private void Awake()
    {
        stateMachine.ChangeState("MainMenu");
    }

    public void OnPlay()
    {
        stateMachine.ChangeState("Hud");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnPause()
    {
        stateMachine.ChangeState("PauseMenu");
    }

    public void OnResume()
    {
        stateMachine.ChangeState("Hud");
    }

    public void OnRestart()
    {
        stateMachine.ChangeState("Hud");
    }

    public void OnGameOver()
    {
        stateMachine.ChangeState("GameOverMenu");
    }

    public void OnCreditsShow()
    {
        stateMachine.ChangeState("CreditsMenu");
    }
}
