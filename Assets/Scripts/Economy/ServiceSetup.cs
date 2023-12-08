using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class ServiceSetup : MonoBehaviour
{
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        Debug.Log($"UID:{AuthenticationService.Instance.PlayerId}");

        EconomyManager.Instance.Refresh();
    }
}
