using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using UnityEngine;

public class AppodealBanner : MonoBehaviour
{
    private void Start()
    {
        if (SceneMediator.IsRestart)
        {
            Show();
            SceneMediator.ChangeRestartStatus(false);
        }
    }

    private void Show() => Appodeal.Show(AppodealShowStyle.BannerBottom);

    private void Hide()
    {
        if (Appodeal.IsLoaded(AppodealShowStyle.BannerBottom))
            Appodeal.Hide(AppodealShowStyle.BannerBottom);
    }

    private void OnDestroy() => Hide();
}