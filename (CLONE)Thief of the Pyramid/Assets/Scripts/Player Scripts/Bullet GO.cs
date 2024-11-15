using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BulletGO : MonoBehaviour
{
    // IM THIRSTY IM THIRSTY IM THIRSTY IM THIRSTY, IM JUST GETTING A DRINK IM JUST GETTING A DRINK IM JUST GETTING A DRINK
    public GameObject Bullet;
    public GameObject KeyforFinal;
    public Ehealth womp;
    public bool keydropped;
    public EnemyCheck EC;
    public GameObject Enemy;
    public Scene scene;
    public string SceneName;
    public GameObject BulletHole;
    public int randomint;
    public GameObject Player;

    // Start is called before the first frame update
    private void Awake(){

    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        SceneName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name == "Bullet(Clone)" || gameObject.name == "Bullet Cluster(Clone)"){
                transform.Translate(0, 0, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
     if(gameObject.name == "Bullet(Clone)" || gameObject.name == "Bullet Cluster(Clone)"){

    
        if(Enemy == null)
        {
            Enemy = GameObject.FindWithTag("Enemy");
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            Ehealth womp = Enemy.GetComponent<Ehealth>();
           
            var health = collision.gameObject.GetComponent<Ehealth>();
            if(health != null)
            {
                Destroy(gameObject);
                health.Health -= 10;
                Destroy(gameObject);
                }

            }
     }
    }
}
