using System.Collections.Generic;
using UnityEngine;

//TODO: Заменить это недоразумение
public class PlayerPrefsSetup : MonoBehaviour
{
    public void Awake()
    {
        if (PlayerPrefs.GetInt("IsInited") == 0)
        {
            PlayerPrefs.SetInt("IsInited", 1);
            PlayerPrefs.SetInt("MusicVol", 0);
            PlayerPrefs.SetInt("SFXVol", 0);

            PlayerPrefs.SetString("LastRewardDate", "2001-01-01");
            PlayerPrefs.SetInt("LastDay", 0);

            PlayerPrefs.SetInt("Level", 1);
        }
    }
}
