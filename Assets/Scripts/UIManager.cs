using Assets.Scripts.Utilities;
using Pixelplacement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameOverMenuManager gameOverMenu;

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

    public void OnGameOver(GameEventArgs gameEventArgs)
    {
        stateMachine.ChangeState("GameOverMenu");
        
        OnGameOverArgs args = (OnGameOverArgs)gameEventArgs;
        gameOverMenu.OnGameOver(args);
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
