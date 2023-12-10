using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixerGroup musicMixer;
    [SerializeField]
    private AudioMixerGroup soundsMixer;

    void Start()
    {
        var music = PlayerPrefs.GetInt("MusicVol");
        var sounds = PlayerPrefs.GetInt("SFXVol");

        musicMixer.audioMixer.SetFloat("MusicVol", music);
        soundsMixer.audioMixer.SetFloat("SFXVol", sounds);
    }
}
