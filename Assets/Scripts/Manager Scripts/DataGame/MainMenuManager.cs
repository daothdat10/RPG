using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private GameData gameData;
    public TextMeshProUGUI coinstxt;

    private void Awake()
    {
        gameData = SystemSave.Load();
        RefreshUI();
    }

    void RefreshUI()
    {
        coinstxt.text = gameData.totalCoins.ToString() + " x";
    }
}
