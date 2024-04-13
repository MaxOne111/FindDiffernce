using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private GameObject _Tap_Panel;
    
    [SerializeField] private AddressableLevelLoader _Addressable_Level_Loader;

    private void OnEnable() => _Addressable_Level_Loader._On_Level_Loaded += ShowTapPanel;

    private void ShowTapPanel() => _Tap_Panel.SetActive(true);
    
    private void OnDisable() => _Addressable_Level_Loader._On_Level_Loaded -= ShowTapPanel;
}