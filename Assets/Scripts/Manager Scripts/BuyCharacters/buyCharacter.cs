using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class buyCharacter : MonoBehaviour
{
    public GameData gameData;
    public int[] charPrices;
    public GameObject[] characters;
    public GameObject choice;
    public GameObject Buy;
    
    private TextMeshProUGUI coinstext;

    private void Awake()
    {
        
        gameData = SystemSave.Load();
        

    }
    private void Start()
    {
        coinstext = GameObject.Find("coinsHierarchy").GetComponent<TextMeshProUGUI>();

        
        
    }
    private void Update()
    {
        
        SystemSave.Save(gameData);
        
    }

  
    public void BuyCharacter(int charIndex)
    {
        
        if(gameData.totalCoins >= charPrices[charIndex])
        {
            gameData.totalCoins -= charPrices[charIndex];
            gameData.charUnlocked[charIndex] = true;
            coinstext.text = gameData.totalCoins.ToString() ;
            SystemSave.Save(gameData);
            choice.SetActive(true);
            Debug.Log("Mua Nhan Vat Thanh Cong " + charIndex);
        }
        else
        {
            Debug.Log("Khong Du Tien.");
            choice.SetActive(false);
            Buy.SetActive(true);
        }
       
    }

    
}
