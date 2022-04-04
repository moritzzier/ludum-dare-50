using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/SoundListSO")]
[Serializable]
public class SoundListSO : ScriptableObject
{
    static System.Random random = new System.Random();

    public string Name;

    public AudioClip[] Sounds;

    public AudioClip GetRandomSound()
    {
        return Sounds[random.Next(0, Sounds.Length)];
    }

}
