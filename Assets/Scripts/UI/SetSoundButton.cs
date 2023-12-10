using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSoundButton : MonoBehaviour
{
    [SerializeField]
    private AudioMixerGroup mixer;

    public void OnEnable()
    {
        Toggle toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(SetSound);

        var sound = PlayerPrefs.GetInt($"{mixer.name}Vol");

        toggle.isOn = sound != 0;
    }

    public void SetSound(bool soundStatus)
    {
        var sound = !soundStatus ? 0 : -80;

        mixer.audioMixer.SetFloat($"{mixer.name}Vol", sound);

        PlayerPrefs.SetInt($"{mixer.name}Vol", sound);
    }
}