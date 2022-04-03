using Assets.Scripts.Scriptable_Objects;
using Assets.Scripts.Utilities;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] GameEvent onPause;
    [SerializeField] GameSettings gameSettings;
    
    [Header("Health")]
    [SerializeField] float maxBPM;
    [SerializeField] TextMeshProUGUI healthText;
    
    AnimationCurve _healthToBPM;

    private void Awake()
    {
        _healthToBPM = gameSettings.HeartbeatMap;
    }
    public void OnPause()
    {
        onPause.Invoke();
    }

    public void OnHealthUpdate(GameEventArgs onHealthUpdateArgs)
    {
        OnHealthUpdateArgs args = (OnHealthUpdateArgs)onHealthUpdateArgs;

        float bpm = Mathf.RoundToInt(_healthToBPM.Evaluate(args.value) * maxBPM);
        healthText.text = $"{bpm} BPM";
    }
}
