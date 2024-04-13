using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Timer;
    [SerializeField] private TextMeshProUGUI _Current_Level;

    [SerializeField] private GameObject _Background;
    
    [SerializeField] private FinishPanel _Defeat_Panel;
    [SerializeField] private FinishPanel _Victory_Panel;

    private void OnEnable()
    {
        GameEvents._On_Player_Winned += ShowVictoryPanel;
        GameEvents._On_Time_Overed += ShowDefeatPanel;
    }

    private void Start() => CurrentLevel();

    private void ShowDefeatPanel()
    {
        _Background.SetActive(true);
        
        _Defeat_Panel.Show();
    }

    private void ShowVictoryPanel()
    {
        _Background.SetActive(true);
    
        _Victory_Panel.Show();
    }

    public void CurrentTimer(int _sec, int _min) => _Timer.text = $"{_min:00}:{_sec:00}";
    private void CurrentLevel() => _Current_Level.text = $"Level {PlayerDataMediator.PlayerData._Level}";

    private void OnDisable()
    {
        GameEvents._On_Player_Winned -= ShowVictoryPanel;
        GameEvents._On_Time_Overed -= ShowDefeatPanel;
    }
    
}