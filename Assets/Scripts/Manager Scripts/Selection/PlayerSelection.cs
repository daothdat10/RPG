using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    public GameObject[] cars;

    public Button next;
    public Button prev;
    int index;
    void Start()
    {
        index = PlayerPrefs.GetInt("carIndex");
        for(int i=0; i<cars.Length; i++)
        {
            cars[i].SetActive(false);
            cars[index].SetActive(true);
        }
    }

    private void Update()
    {
        if(index >= 1)
        {
            next.interactable = false;
        }
        else
        {
            next.interactable= true;
        }
        if(index<=0)
        {
            prev.interactable = false;
        }
        else
        {
            prev.interactable=(true);
        }
    }

    public void Next()
    {
        index++;
        for(int i=0;i<cars.Length;i++)
        {
            cars[i].SetActive(false) ;
            cars[index].SetActive(true) ;
        }
        PlayerPrefs.SetInt("carIndex",index);
        PlayerPrefs.Save();
    }

    public void Prev() {
        index--;

        for(int i = 0; i < cars.Length; i++)
        {
            cars[i].SetActive(false) ;
            cars[index].SetActive(true) ;
        }
        PlayerPrefs.SetInt("carIndex", index);

        PlayerPrefs.Save();
        
    }

    
    

}
