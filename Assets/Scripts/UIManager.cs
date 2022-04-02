using Pixelplacement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        stateMachine.ChangeState("MainMenu");
    }

    public void OnPlay()
    {
        stateMachine.ChangeState("Hud");
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

    public void OnMainMenu()
    {
        stateMachine.ChangeState("MainMenu");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
