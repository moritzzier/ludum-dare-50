using Assets.Scripts.Utilities;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] GameEvent onPause;
    
    [Header("Health")]
    [SerializeField] float maxBPM;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] AnimationCurve healthToBPM;
    public void OnPause()
    {
        onPause.Invoke();
    }

    public void OnHealthUpdate(OnHealthUpdateArgs onHealthUpdateArgs)
    {
        float bpm = Mathf.RoundToInt(healthToBPM.Evaluate(onHealthUpdateArgs.value) * maxBPM);
        healthText.text = $"{bpm} BPM";
    }
}
