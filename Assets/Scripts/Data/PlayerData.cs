using System;

[Serializable]
public class PlayerData
{
    public int _Level;

    public PlayerData(int _level)
    {
        _Level = _level;
    }
    
    public void IncreaseLevel() => _Level++;
}