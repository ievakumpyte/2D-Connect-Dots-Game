using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InstantiationManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject obj;
    public List<Vector2> pos = new List<Vector2>();
    public GameObject[] pointObjects = new GameObject[8];
    public GameObject LastObj;

    [SerializeField] public TextAsset jsonFile;
    [SerializeField] public JsonObjects objects;

    void Start()
    {
      
        Scene scene = SceneManager.GetActiveScene();

        objects = JsonUtility.FromJson<JsonObjects>(jsonFile.text);
        List<Levels> levels = objects.levels;
        List<string> levelData1 = levels[0].level_data;
        List<string> levelData2 = levels[1].level_data;
        List<string> levelData3 = levels[2].level_data;
        List<string> levelData4 = levels[3].level_data;


        if (scene.name == "Level1")
        {
            for (int i = 0; i < levelData1.Count; i += 2)
            {
                Vector2 newPos = new Vector2(int.Parse(levelData1[i]), int.Parse(levelData1[i + 1]));
                pos.Add(newPos);

            }
        }

        else if (scene.name == "Level2")
        {
            for (int i = 0; i < levelData2.Count; i += 2)
            {
                Vector2 newPos = new Vector2(int.Parse(levelData2[i]), int.Parse(levelData2[i + 1]));
                pos.Add(newPos);

            }
        }

        else if(scene.name == "Level3")
        {
            for (int i = 0; i < levelData3.Count; i += 2)
            {
                Vector2 newPos = new Vector2(int.Parse(levelData3[i]), int.Parse(levelData3[i + 1]));
                pos.Add(newPos);

            }
        }

        else if(scene.name == "Level4")
        {
            for (int i = 0; i < levelData4.Count; i += 2)
            {
                Vector2 newPos = new Vector2(int.Parse(levelData4[i]), int.Parse(levelData4[i + 1]));
                pos.Add(newPos);

            }
        }
        
        Rect viewportRect = Camera.main.pixelRect;
        float aspectRatio = Screen.width / Screen.height;

        for (int i = 0; i < pos.Count; i++)
        {
            int id = i + 1;
            Vector3 newPos = new Vector3(viewportRect.xMin  + pos[i].x*2- viewportRect.xMax, Camera.main.pixelHeight - pos[i].y, 10);
            this.transform.position = Camera.main.ScreenToViewportPoint(newPos);
            GameObject ob_text = obj.transform.GetChild(0).gameObject;
            ob_text.GetComponent<TextMeshPro>().text = id.ToString();
            GameObject newObj = Instantiate(obj, this.transform.position*3* aspectRatio, Quaternion.identity);
            newObj.name = id.ToString();
            newObj.transform.parent = parent.transform;
        }
        pointObjects = GameObject.FindGameObjectsWithTag("Point");       
    }


    void Update()
    {
        

    }
}
