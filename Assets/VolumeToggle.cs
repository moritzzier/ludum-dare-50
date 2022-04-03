using Pixelplacement;
using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeToggle : MonoBehaviour
{
    StateMachine _stateMachine;
    [SerializeField] AudioMixerGroup _audioMixerGroup;

    enum VolumeState
    {
        VolumeLow,
        VolumeMid,
        VolumeMax,
        VolumeMute
    }

    enum Volume
    {
        [Description("-22")]
        Low,
        [Description("-12")]
        Mid,
        [Description("0")]
        Max,
        [Description("-80")]
        Mute
    }

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
    }

    private void Start()
    {
        _stateMachine.ChangeState(VolumeState.VolumeMax);
        _audioMixerGroup.audioMixer.SetFloat("MasterVolume", 0);
    }

    public void OnToggle()
    {
        var @string = _stateMachine.NextLoop().name;
        var currentStateIndex = (VolumeState)Enum.Parse(typeof(VolumeState), @string);
        var values = Enum.GetValues(typeof(Volume));
        Volume value = (Volume)values.GetValue((int)currentStateIndex);
        if (float.TryParse(value.GetDescription(), out float result))
        {
            _audioMixerGroup.audioMixer.SetFloat("MasterVolume", result);
        }
    }
}
