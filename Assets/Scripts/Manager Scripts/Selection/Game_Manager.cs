using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int index;
    public GameObject[] player;

    private void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");
        GameObject car = Instantiate(player[index],Vector3.zero,Quaternion.identity);
    }
}
