using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DayReward : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dayText;

    [SerializeField]
    private TextMeshProUGUI amount;

    public void SetDay(int dayNumber, int reward)
    {
        dayText.text = $"DAY {dayNumber}";
        amount.text = $"X{reward}";
    }
}
