using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSelector : MonoBehaviour
{
    public int currentCharaIndex;
    public GameObject[] characters;

    void Start()
    {
        currentCharaIndex = PlayerPrefs.GetInt("SelectedChara", 0);
        foreach(GameObject chara in characters)
        {
            chara.SetActive(false);
        }
        
        characters[currentCharaIndex].SetActive(true);
    }
}
