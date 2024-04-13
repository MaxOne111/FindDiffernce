public static class PlayerDataMediator
{
    private static PlayerData _Player_Data;

    public static PlayerData PlayerData => _Player_Data;

    public static void LoadPlayerData(PlayerData _data) => _Player_Data = _data;
}