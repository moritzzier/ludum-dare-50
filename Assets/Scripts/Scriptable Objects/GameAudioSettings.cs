using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Audio Settings", menuName = "Game/Audio Settings")]
    public class GameAudioSettings : ScriptableObject
    {
        [Header("Master Audio")]
        [SerializeField] public float masterVolumeMax = 1f;
        [SerializeField] public float masterVolumeMed = 0.5f;
        [SerializeField] public float masterVolumeMin = 0f;

        [Header("Music Audio")]
        [SerializeField] public float musicSpeedMin = 0.5f;
        [SerializeField] public float musicSpeedMax = 1.0f;
        [SerializeField] public float musicMinCutoffFreq = 0f;
        [SerializeField] public float musicMaxCutoffFreq = 0f;
        
    }
}