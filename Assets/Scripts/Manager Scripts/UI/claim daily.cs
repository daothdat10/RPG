using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class claimdaily : MonoBehaviour
{
    [SerializeField] private Image focus;
    [SerializeField] private Image giftSpot;
    [SerializeField] private Sprite collectedSprite;
    [SerializeField] private GameObject checkMark;
    [SerializeField] private TextMeshProUGUI titletext;
    [SerializeField] private Button claimButton;
    [SerializeField] private TextMeshProUGUI timeLeft;

    private int nextDay;
    void Start()
    {
        nextDay = PlayerPrefs.GetInt("nextdays", 1);
        //Get last claim time
        string lastTime = PlayerPrefs.GetString("LastClaimTime", "");
        DateTime lastClaimTime;

        if(!string.IsNullOrEmpty(lastTime))
        {
            lastClaimTime = DateTime.Parse(lastTime);
        }
        else
        {
            lastClaimTime = DateTime.MinValue;
        }

        //enable/ disable claim button
        if(DateTime.Today > lastClaimTime)
        {
            claimButton.interactable = true;
        }
        else
        {
            claimButton.interactable = false;
            timeLeft.text = GetTimeToNextClaim();
        }
    }

    private string GetTimeToNextClaim()
    {
        int hour = Mathf.FloorToInt((float)(DateTime.Today.AddDays(1)-DateTime.Now).TotalHours);
        int minutes = Mathf.FloorToInt((float)(DateTime.Today.AddDays(1)-DateTime.Now).TotalMinutes)%60;

        return (hour +" : "+ minutes);

    }

    // Update is called once per frame
    public void OnClaimButtonPressed()
    {
        DateTime claimTime = DateTime.Parse(PlayerPrefs.GetString("LastClaimTime", DateTime.MinValue.ToString()));
        if(DateTime.Today> claimTime)
        {
            nextDay++;
        }
        else
        {
            nextDay = 1;
        }

        PlayerPrefs.SetString("LastClaimTime",DateTime.Now.ToString());
        PlayerPrefs.SetInt("nextdays", nextDay);
        ClaimGift();
    }
    public void ClaimGift()
    {
        claimButton.interactable = false;
        checkMark.SetActive(true);
        giftSpot.sprite = collectedSprite;
        focus.enabled = false;
        titletext.text = "Daily Login Rewards<color=#f6e19c> 1 </color>/ 5";
        timeLeft.text = GetTimeToNextClaim();
    }
}
