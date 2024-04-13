using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private GameUI _Game_UI;
    [SerializeField] private Timer _Timer;

    private void OnEnable() => _Timer._On_Time_Changed += Display;

    private void Display(int _sec, int _min)
    {
        if (!_Game_UI)
            return;
    
        _Game_UI.CurrentTimer(_sec, _min);
    }

    public void OnDisable() => _Timer._On_Time_Changed -= Display;
}