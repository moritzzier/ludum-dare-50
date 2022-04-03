using Assets.Scripts.Scriptable_Objects;
using Assets.Scripts.Utilities;
using Pixelplacement;
using Pixelplacement.TweenSystem;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayerManager : MonoBehaviour
{
    [SerializeField] GameAudioSettings audioSettings;
    [SerializeField] GameSettings gameSettings;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioMixerGroup audioMixerGroup;

    TweenBase _musicCutoffTween;

    private void Awake()
    {
        SetCutoffFrequency(audioSettings.musicMinCutoffFreq);
    }

    public void OnHealthUpdate(GameEventArgs gameEventArgs)
    {
        OnHealthUpdateArgs args = (OnHealthUpdateArgs)gameEventArgs;

        float evaluatedValue = (gameSettings.HeartbeatMap.Evaluate(args.value)
            * (audioSettings.musicMaxCutoffFreq - audioSettings.musicMinCutoffFreq))
            + audioSettings.musicMinCutoffFreq;

        float currentCutoff = 0f;
        audioMixerGroup.audioMixer.GetFloat("MusicLowpassFreq", out currentCutoff);

        _musicCutoffTween = Tween.Value(currentCutoff, evaluatedValue, SetCutoffFrequency, 0.5f, 0f);

    }

    void SetCutoffFrequency(float cutoffFrequency)
    {
        audioMixerGroup.audioMixer.SetFloat("MusicLowpassFreq", cutoffFrequency);
    }



}
