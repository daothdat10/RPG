using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyCharacter : MonoBehaviour
{
    public GameData gameData;
    public int[] charPrices;
    public GameObject[] characters;
    private MainMenuManager mainMenuManager;
    private void Awake()
    {
        
        gameData = SystemSave.Load();
    }
    private void Update()
    {
        
        SystemSave.Save(gameData);
    }

    public void BuyCharacter(int charIndex)
    {
        /*if (gameData.charUnlocked[charIndex])
        {
            Debug.Log("Nhan Vat Nay Da Duoc Mo Khoa");
            return;
        }*/
        if(gameData.totalCoins >= charPrices[charIndex])
        {
            gameData.totalCoins -= charPrices[charIndex];
            gameData.charUnlocked[charIndex] = true;

            SystemSave.Save(gameData);

            Debug.Log("Mua Nhan Vat Thanh Cong " + charIndex);
        }
        else
        {
            Debug.Log("Khong Du Tien.");
        }
    }

}
