using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public interface GameEventArgs
    { }

    public class StaminaEventArgs : GameEventArgs
    {
        public float value;
    }
}