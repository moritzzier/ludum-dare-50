using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameEvent onPlay;
    [SerializeField] GameEvent onQuit;

    public void OnPlay()
    {
        onPlay.Invoke();
    }

    public void OnQuit()
    {
        onQuit.Invoke();
    }
}
