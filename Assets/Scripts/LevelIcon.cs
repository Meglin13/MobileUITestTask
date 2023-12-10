using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelIcon : MonoBehaviour
{
    private int level;

    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private GameObject lockImage;

    private bool isLocked;

    public void SetLevel(int level, bool isLocked = false)
    {
        this.level = level;
        this.isLocked = isLocked;

        levelText.text = level.ToString();

        lockImage.SetActive(isLocked);
        levelText.gameObject.SetActive(!isLocked);
    }

    public void OnClicked()
    {
        if (!isLocked)
        {
            LevelManager.Instance.SetLevel(level); 
        }
        else
        {
            Debug.Log("Bruh");
        }
    }
}