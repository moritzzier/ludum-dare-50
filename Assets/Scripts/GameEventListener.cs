using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Utilities
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] GameEvent _gameEvent;
        [SerializeField] UnityEvent<GameEventArgs> _unityEvent;

        private void Awake()
        {
            _gameEvent.Register(this);
        }

        private void OnDestroy()
        {
            _gameEvent.Deregister(this);
        }

        public void RaiseEvent(GameEventArgs arg = null)
        {
            _unityEvent.Invoke(arg);
        }
    }
}