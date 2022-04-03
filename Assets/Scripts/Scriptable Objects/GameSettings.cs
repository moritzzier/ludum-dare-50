using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Game Settings", menuName = "Game / Game Settings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Game Settings")]
        public float MaxPlayerHealth;
        public float HealthDecreaseOnHit;
        public float HealthIncreaseOnHeal;
        
        public float MinPassiveHealthDecrease;
        public float MaxPassiveHealthDecrease;
        public AnimationCurve PassiveHealthDecreaseOverTime;

        public float MinSpawnRate;
        public float MaxSpawnRate;
        public AnimationCurve SpawnRateOverTime;
        

        [Header("Rythm Settings")]
        public AnimationCurve HeartbeatMap;
    }
}