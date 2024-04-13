using System.IO;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] private PlayerData _Player_Data;
    
    private string _File_Name = "playerData.json";
    private string _File_Path;
    
    private void Awake() => _File_Path = Application.persistentDataPath + _File_Name;
    private void Start()
    {
        Load();
        
        PlayerDataMediator.LoadPlayerData(_Player_Data);
    }
    
    private void Load()
    {
        if (!File.Exists(_File_Path))
        {
            DefaultPlayerData();
            return;
        }

        _Player_Data = JsonUtility.FromJson<PlayerData>(File.ReadAllText(_File_Path));
    }
    
    private void DefaultPlayerData() => _Player_Data = new PlayerData(1);
}
