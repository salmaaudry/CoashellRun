using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaManager : MonoBehaviour
{
    public int currentCharaIndex;
    public GameObject[] characterModels;

    void Start()
    {
        currentCharaIndex = PlayerPrefs.GetInt("SelectedChara", 0);
        foreach(GameObject chara in characterModels)
        {
            chara.SetActive(false);
        }
        
        characterModels[currentCharaIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNext()
    {
        characterModels[currentCharaIndex].SetActive(false);

        currentCharaIndex++;
        if (currentCharaIndex == characterModels.Length)
        {
            currentCharaIndex = 0;
        }

        characterModels[currentCharaIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChara", currentCharaIndex);
    }

    public void ChangePrev()
    {
        characterModels[currentCharaIndex].SetActive(false);

        currentCharaIndex--;
        if(currentCharaIndex == -1)
        {
            currentCharaIndex = characterModels.Length - 1;
        }

        characterModels[currentCharaIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChara", currentCharaIndex);
    }
}
