using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using TMPro;
using Unity.Services.Economy.Model;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    [SerializeField]
    private bool isRewardAvailable;

    private DateTime date;
    [SerializeField]
    private int currentDay = 1;

    [SerializeField]
    private Image rewardSlider;

    [SerializeField]
    private UIWindow rewardWindow;

    [SerializeField]
    private DayReward dayPrefab;

    [SerializeField]
    private Transform daysContainer;

    [SerializeField]
    private List<DayReward> daysPlaced = new List<DayReward>();

    [SerializeField]
    private List<int> rewards = new List<int>(7);

    [SerializeField]
    private TextMeshProUGUI rewardDayText;

    [SerializeField]
    private TextMeshProUGUI rewardAmountText;

    //TODO: ≈жедневные награды
    private void OnEnable()
    {
        currentDay = PlayerPrefs.GetInt("LastDay");
        var datePref = PlayerPrefs.GetString("LastRewardDate");

        if (DateTime.TryParse(datePref, out date) && date.Date < DateTime.Now.Date)
        {
            isRewardAvailable = true;
        }

        rewardSlider.fillAmount = currentDay / 7;

        for (int i = 0; i < 6; i++)
        {
            int dayIndex = i;

            if (daysPlaced.Count < 6)
            {
                var day = Instantiate(dayPrefab, daysContainer);
                day.SetDay(i + 1, rewards[i]);
                daysPlaced.Add(day);
            }
            else
            {
                daysPlaced[i].SetDay(i + 1, rewards[i]);
            }

            var button = daysPlaced[i].GetComponent<Button>();

            button.onClick.RemoveAllListeners();

            button.interactable = currentDay == i & isRewardAvailable;

            if (currentDay == i)
            {
                button.onClick.AddListener(() =>
                {
                    GetReward(dayIndex, rewards[dayIndex]);
                });
            }
        }
    }

    public void GetReward(int day, int amount)
    {
        if (isRewardAvailable & currentDay == day)
        {
            currentDay++;

            EconomyManager.Instance.AddCurrency("TICKETS", amount);

            PlayerPrefs.SetString("LastRewardDate", DateTime.Now.ToString());
            PlayerPrefs.SetInt("LastDay", currentDay);

            UIManager.Instance.SwitchWindow(rewardWindow);

            rewardDayText.text = $"DAY {day}";
            rewardAmountText.text = $"X{amount}";
        }
        else
            Debug.Log("Bruh");
    }

    public void FinalDayReward()
    {
        if (currentDay == 7)
        {
            GetReward(7, 15);
        }
    }
}
