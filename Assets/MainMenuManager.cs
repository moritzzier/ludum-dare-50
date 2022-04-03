using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameEvent onPlay;
    [SerializeField] GameEvent onQuit;
    [SerializeField] GameEvent onVolumeToggle;

    public void OnPlay()
    {
        onPlay.Invoke();
    }

    public void OnVolumeToggle()
    {
        onVolumeToggle.Invoke();
    }

    public void OnQuit()
    {
        onQuit.Invoke();
    }
}
