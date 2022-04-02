using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/GameEvent")]
public class GameEvent : ScriptableObject
{
    HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke(GameEventArgs args = null)
    {
        foreach (GameEventListener listener in _listeners)
            listener.RaiseEvent(args);
    }

    public void Register(GameEventListener gameEventListener)
    {
        _listeners.Add(gameEventListener);
    }
    public void Deregister(GameEventListener gameEventListener)
    {
        _listeners.Remove(gameEventListener);
    }
}
