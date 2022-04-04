using Assets.Scripts.Scriptable_Objects;
using Assets.Scripts.Utilities;
using Pixelplacement;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] GameEvent onPause;
    [SerializeField] GameSettings gameSettings;
    
    [Header("Health")]
    [SerializeField] float maxBPM;
    [SerializeField] TextMeshProUGUI healthText;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

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

    public void OnScoreUpdate(GameEventArgs onScoreUpdateArgs)
    {
        OnScoreUpdateArgs args = (OnScoreUpdateArgs)onScoreUpdateArgs;
        scoreText.text = $"Score: {args.newScore}";
        Tween.Value(48, 56, (v) => scoreText.fontSize = (int)v, 0.25f, 0f, null);
        Tween.Value(56, 48, (v) => scoreText.fontSize = (int)v, 0.25f, 0.25f, null);
    }

    public void OnScoreReset()
    {
        scoreText.text = "Score: 0";
    }
}
