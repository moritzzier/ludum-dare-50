using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameEvent onResume;
    [SerializeField] GameEvent onRestart;
    [SerializeField] GameEvent onMainMenu;

    public void OnResume()
    {
        onResume.Invoke();
    }

    public void OnRestart()
    {
        onRestart.Invoke();
    }

    public void OnHome()
    {
        onMainMenu.Invoke();
    }
}
