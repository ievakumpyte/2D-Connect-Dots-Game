using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockedLevelNumber;
    int isCompletedLevelNumber;


    // Start is called before the first frame update
    private void Start()
    {
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
            
        }

        if (!PlayerPrefs.HasKey("completed"))
        {

        }

        unlockedLevelNumber = PlayerPrefs.GetInt("levelsUnlocked");

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        isCompletedLevelNumber = PlayerPrefs.GetInt("completed");
    }

    // Update is called once per frame
    private void Update()
    {
        unlockedLevelNumber = PlayerPrefs.GetInt("levelsUnlocked");

        for( int i=0; i<unlockedLevelNumber; i++)
        {
            buttons[i].interactable = true;
            
        }

        isCompletedLevelNumber = PlayerPrefs.GetInt("completed");

        for (int i = 0; i < isCompletedLevelNumber; i++)
        {
            
            buttons[i].GetComponent<Image>().color = Color.green;
        }
    }
}
