using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    public List<Transform> points = new List<Transform>();
    public Transform lastPoints;   
    public Sprite button_blue;
    private TextMeshProUGUI txt;
    public bool isComplete = false;
    public GameObject completeMenuUI;
    public InstantiationManager instantiationManager;
    public GameObject LastObj ;
    public int levelToUnlock;
    int numberOfUnlockedLevels;
    int isCompletedLevelNumber;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Start()
    {
        GameObject LastObj = new GameObject();
        LastObj = instantiationManager.LastObj;
        isCompletedLevelNumber = SceneManager.GetActiveScene().buildIndex;
    }


    private void makeLine(Transform finalPoint)
    {
        if(lastPoints == null)
        {
            lastPoints = finalPoint;
            points.Add(lastPoints);
        }
        else
        {
            points.Add(finalPoint);
            lr.enabled = true;
            SetupLine();
        }
    }


    private void SetupLine()
    {

        int pointLength = points.Count;
        lr.positionCount = pointLength;

        for (int i = 0; i < pointLength; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }



    void Update()
    {
        GameObject[] pointsArray = instantiationManager.pointObjects;
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            GameObject first = pointsArray[0];


            if (hit.collider != null)
            {


                if (hit.collider.gameObject.name == pointsArray[0].name)
                {
                    makeLine(hit.collider.transform);
                    hit.transform.GetComponent<Collider2D>().enabled = false;
                    hit.transform.GetComponent<SpriteRenderer>().sprite = button_blue;
                    Destroy(hit.transform.GetComponentInChildren(typeof(TextMeshPro)));
                    LastObj = hit.collider.gameObject;
                }

                else if ((hit.collider.gameObject.name == pointsArray[pointsArray.Length - 1].name) && (int.Parse(LastObj.name) == pointsArray.Length - 1))
                {
                    makeLine(hit.collider.transform);
                    hit.transform.GetComponent<Collider2D>().enabled = false;
                    hit.transform.GetComponent<SpriteRenderer>().sprite = button_blue;
                    Destroy(hit.transform.GetComponentInChildren(typeof(TextMeshPro)));
                    lr.loop = true;
                    isComplete = true;

                    numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");

                    if(numberOfUnlockedLevels < levelToUnlock)
                    {
                        PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);
                    }

                    PlayerPrefs.SetInt("completed", isCompletedLevelNumber);

                    completeMenuUI.SetActive(true);
                }

                else
                {
                    Debug.Log(LastObj.name);
                    if ((int.Parse(hit.collider.gameObject.name) - int.Parse(LastObj.name)) == 1)
                    {
                        makeLine(hit.collider.transform);
                        hit.transform.GetComponent<Collider2D>().enabled = false;
                        hit.transform.GetComponent<SpriteRenderer>().sprite = button_blue;
                        Destroy(hit.transform.GetComponentInChildren(typeof(TextMeshPro)));
                        LastObj = hit.collider.gameObject;
                    }
                }

            }

        }

    }

}
