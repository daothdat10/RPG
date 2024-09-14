
[System.Serializable]
public class GameData 
{
    public int totalCoins;
    public int player;

    public bool[] charUnlocked;

    
    public GameData()
    {
        totalCoins = 0;

        charUnlocked = new bool[5] { true, false, false, false, false };
        charUnlocked[0] = true;
    }
}
