using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static int currentLevel = 0;

    public static int CurrentLevel { get => currentLevel; private set => currentLevel = value; }

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
    }
}
