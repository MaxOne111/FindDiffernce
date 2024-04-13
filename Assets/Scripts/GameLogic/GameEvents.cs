using System;

public static class GameEvents
{
    public static event Action _On_Time_Overed;
    public static event Action _On_Player_Winned;

    public static event Action _Saving_Player_Data;

    public static void TimeOver() => _On_Time_Overed?.Invoke();
    public static void PlayerWin() => _On_Player_Winned?.Invoke();

    public static void SavePlayerData() => _Saving_Player_Data?.Invoke();
    
}