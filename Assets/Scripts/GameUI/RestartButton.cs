using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button _Button;

    private void Awake() => _Button = GetComponent<Button>();

    private void OnEnable() => _Button.onClick.AddListener(Restart);

    private void Restart()
    {
        PlayerDataMediator.PlayerData.IncreaseLevel();
        
        GameEvents.SavePlayerData();
        
        SceneMediator.ChangeRestartStatus(true);
        
        SceneManager.LoadScene("Loading");
    }

    private void OnDisable() => _Button.onClick.RemoveListener(Restart);
}