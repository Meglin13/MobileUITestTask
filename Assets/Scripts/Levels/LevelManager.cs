using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    private int currentLevel = 0;
    public int CurrentLevel 
    {
        get => currentLevel;
        private set
        {
            currentLevel = value;
            OnLevelUpdated?.Invoke();
        }
    }

    [SerializeField]
    private int levelsAmount = 20;

    [SerializeField]
    private LevelIcon prefab;

    [SerializeField]
    private Transform Container;

    [SerializeField]
    private List<LevelIcon> placedLevelIcons = new List<LevelIcon>();

    public event Action OnLevelUpdated = delegate { };

    private void Start()
    {
        instance = this;

        currentLevel = PlayerPrefs.GetInt("Level");
        SpawnButtons();
        SetLevels();

        OnLevelUpdated += SetLevels;
    }

    private void OnDestroy()
    {
        OnLevelUpdated = null;
    }

    public void SetLevel(int level)
    {
        if (level >= currentLevel)
        {
            CurrentLevel = level + 1;

            PlayerPrefs.SetInt("Level", currentLevel);
        }
    }

    private void SpawnButtons()
    {
        if (placedLevelIcons.Count < levelsAmount)
        {
            for (int i = 0; i < levelsAmount; i++)
            {
                var level = Instantiate(prefab, Container);
                placedLevelIcons.Add(level);
            } 
        }
    }

    private void SetLevels()
    {
        int index = 1;
        foreach (var item in placedLevelIcons)
        {
            var isLocked = currentLevel < index;

            item.SetLevel(index, isLocked);

            index++;
        }
    }
}