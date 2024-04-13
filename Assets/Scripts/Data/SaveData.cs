using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private PlayerData _Player_Data;
    
    private string _File_Name = "playerData.json";
    private string _File_Path;

    private void Awake()
    {
        _File_Path = Application.persistentDataPath + _File_Name;

        _Player_Data = PlayerDataMediator.PlayerData;
    }

    private void OnEnable() => GameEvents._Saving_Player_Data += Save;

    private void Start() => Save();
    
    private void Save()
    {
        string _player_Data = JsonUtility.ToJson(_Player_Data);
        
        File.WriteAllText(_File_Path, _player_Data);
    }

    private void OnDisable() => GameEvents._Saving_Player_Data -= Save;
}