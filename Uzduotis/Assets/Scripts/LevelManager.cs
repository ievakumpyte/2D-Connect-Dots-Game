using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level;
    public GameObject completeMenuUI;
    [SerializeField] public Button button;
    

    void Start()
    {
       
        int scene = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        if (scene == sceneCount - 1)
        {
            button.interactable = false;
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }

    public void Retry()
    {
       
        int scene = SceneManager.GetActiveScene().buildIndex;
        completeMenuUI.SetActive(false);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
        
    }
    public void NextScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;        
        completeMenuUI.SetActive(false);
        SceneManager.LoadScene(scene+1, LoadSceneMode.Single);        
        Time.timeScale = 1;



    }

}
