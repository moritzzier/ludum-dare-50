using UnityEngine;

public class SoundPlayerManager : MonoBehaviour
{
    [SerializeField] SoundListSO DamageSoundList;
    [SerializeField] SoundListSO DeathSoundList;
    [SerializeField] SoundListSO HealSoundList;

    AudioSource _sfxSource;

    private void Awake()
    {
        _sfxSource = GetComponent<AudioSource>();
    }

    public void PlayDamageSound()
    {
        _sfxSource.clip = DamageSoundList.GetRandomSound();
        _sfxSource.PlayOneShot();

    }

    public void PlayDeathSound()
    {
        _sfxSource.clip = DeathSoundList.GetRandomSound();
        _sfxSource.PlayOneShot();
    }

    public void PlayHealSound()
    {
        _sfxSource.clip = HealSoundList.GetRandomSound();
        _sfxSource.PlayOneShot();
    }
}
