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
    TweenBase _musicSpeedTween;

    private void Awake()
    {
        SetDefaults();
    }

    public void SetDefaults()
    {
        SetCutoffFrequency(audioSettings.musicMaxCutoffFreq);
        SetMusicPitch(audioSettings.musicSpeedMax);
    }

    public void OnHealthUpdate(GameEventArgs gameEventArgs)
    {
        OnHealthUpdateArgs args = (OnHealthUpdateArgs)gameEventArgs;

        float curveValue = gameSettings.HeartbeatMap.Evaluate(args.value);

        //Cutoff
        float evaluatedCutoffValue = (curveValue
            * (audioSettings.musicMaxCutoffFreq - audioSettings.musicMinCutoffFreq))
            + audioSettings.musicMinCutoffFreq;
        SetCutoffFrequency(evaluatedCutoffValue);

        //Speed
        float evaluatedPitchValue = (curveValue
            * (audioSettings.musicSpeedMax - audioSettings.musicSpeedMin))
            + audioSettings.musicSpeedMin;
        SetMusicPitch(evaluatedPitchValue);
    }

    void SetCutoffFrequency(float cutoffFrequency)
    {
        float currentCutoff = 0f;
        audioMixerGroup.audioMixer.GetFloat("MusicLowpassFreq", out currentCutoff);

        _musicCutoffTween = Tween.Value(currentCutoff, cutoffFrequency, (val) =>
        {
            audioMixerGroup.audioMixer.SetFloat("MusicLowpassFreq", val);
        }, 0.5f, 0f);
    }

    void SetMusicPitch(float pitch)
    {
        float currentPitch = musicSource.pitch;
     
        _musicSpeedTween = Tween.Value(currentPitch, pitch, (val) =>
        {
            musicSource.pitch = val;
        }, 0.5f, 0f);
    }



}
