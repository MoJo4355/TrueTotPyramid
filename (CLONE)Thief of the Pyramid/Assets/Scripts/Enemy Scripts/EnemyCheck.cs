using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCheck : MonoBehaviour
{
    public BoolCheck BC;
    public GameObject Enemy;
    public GameObject[] Enemies;
    public Animation GoUp;
    public GameObject door;
    public bool ugh;
    public int enemyCount;
    public Scene scene;
    public string SceneName;
    public GameObject FinalDoor;
    public PickUp picks;

    public void Awake(){

    }
    // Start is called before the first frame update
    void Start()
    {
        ugh = false;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        scene = SceneManager.GetActiveScene();
        SceneName = scene.name;

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            if(SceneName == "Tutorial" || SceneName == "Prototype")
            {
                Invoke("DoorGoUp", 2f);
            }
        }
        if(SceneName == "Tutorial" || SceneName == "Prototype")
        {
            if (picks.BroadcastEnemy1 == true)
            {
                //for (int i = 0; i < Enemies.Length; i++)
                // {
                //Enemies[i].SetActive(true);
                //  }
            }
        }



    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {

        }
        else if(other.gameObject.tag == "Player")
        {
            if (BC.GlobalEnemyCount == 0 && BC.Finaler == true)
            {
                if (SceneName == "Level 1")
                {
                    Destroy(FinalDoor.gameObject);
                    Destroy(gameObject);
                }
            }
        }


    }

    void DoorGoUp()
    {
        GoUp.Play();
        Invoke("BEGONE", 7f);
    }

    void BEGONE()
    {
        door.SetActive(false);
    }
}
