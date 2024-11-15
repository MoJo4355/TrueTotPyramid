using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEGroups : MonoBehaviour
{
    public GameObject G1;
    public GameObject G2;
    public GameObject G3;
    public GameObject Side;
    public GameObject Stair;
    public GameObject Maindoor;
    public LevelOneTriggers LT;
    public BoolCheck BC;
    public Scene scene;
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        SceneName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("yes");
        if(other.gameObject.tag == "Player")
        {
            print("ok");
            if(SceneName == "Level 1")
            {
                if (BC.შვედურიმეტროსსისტემა == 0)
                {
                    G1.SetActive(true);
                    Stair.SetActive(false);
                    Side.SetActive(false);
                    Maindoor.SetActive(true);
                    BC.შვედურიმეტროსსისტემა += 1;
                    Destroy(gameObject);
                }
                else if (BC.შვედურიმეტროსსისტემა == 1)
                {
                    G2.SetActive(true);
                    BC.შვედურიმეტროსსისტემა += 1;
                    Destroy(gameObject);

                }
                else if (BC.შვედურიმეტროსსისტემა == 2)
                {
                    G3.SetActive(true);
                    BC.lastHall = true;
                    Destroy(gameObject);
                }
            }
          
        }
    }
}
