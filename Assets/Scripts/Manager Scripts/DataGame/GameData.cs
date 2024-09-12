
[System.Serializable]
public class GameData 
{
    public int totalCoins;
    

    public bool[] charUnlocked;

    
    public GameData()
    {
        totalCoins = 0;

        charUnlocked = new bool[5];
        charUnlocked[0] = true;
    }
}
