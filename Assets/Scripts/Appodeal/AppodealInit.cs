using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using UnityEngine;

public class AppodealInit : MonoBehaviour
{
  
    private void Awake() => Init();

    private void Init()
    {
        int _ad_Types = AppodealAdType.Banner;
        string appKey = "YOUR_APPODEAL_APP_KEY";
        AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
        Appodeal.Initialize(appKey, _ad_Types);
    }

    private void OnInitializationFinished(object sender, SdkInitializedEventArgs e)
    {
        Debug.Log(" Initialization was successful");
    }
}