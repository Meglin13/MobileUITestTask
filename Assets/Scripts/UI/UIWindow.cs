using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    [SerializeField]
    private UIManager manager;

    [SerializeField]
    private bool isOverLay = false;
    public bool IsOverLay => IsOverLay;
}
