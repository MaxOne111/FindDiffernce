using UnityEngine;

public static class SceneMediator
{
    private static GameObject _Level;

    private static bool _Is_Restart;
    public static GameObject Level => _Level;
    public static bool IsRestart => _Is_Restart; 
    
    public static void LoadLevel(GameObject _level) => _Level = _level;

    public static void ChangeRestartStatus(bool _status) => _Is_Restart = _status;
}
