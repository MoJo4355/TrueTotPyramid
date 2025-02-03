using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ehealth : MonoBehaviour
{
    public int Health;
    public int maxHealth;
    public HealthBar healthBar;

    public Attack atk;
    public NavMeshAgent agent;
    public GameObject Enm;
    public Collider GCollider;
    public EnemyNav Env;
    public AudioSource hit;
    public AudioSource groan;
    public string SceneName;
    public Scene scene;


    // Start is called before the first frame update
    public void Awake()
    {
        scene = SceneManager.GetActiveScene();
        SceneName = scene.name;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GCollider = GetComponent<Collider>();
        Env = GetComponent<EnemyNav>();
        hit = GetComponent<AudioSource>();
        AudioSource[] Sources = GetComponents<AudioSource>();
        groan = Sources[0];
        hit = Sources[1];

        Health = maxHealth;

        if (SceneName == "Prototype")
        {
            print("have fun");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
        if (SceneName == "Prototype")
        {
            Destroy(gameObject);
        }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Bullet(Clone)"){
            Destroy(collision.gameObject);
            takeDamage(10);
            hit.Play();
            if (Health <= 0)
            {
                if(SceneName == "Prototype")
                {
                    Destroy(gameObject);
                }
                else
                {
                    GCollider.isTrigger = true;
                    //agent.enabled = false;
                    gameObject.GetComponent<Animator>().SetFloat("locomotion", 0);
                    gameObject.GetComponent<Animator>().SetBool("isDead", true);
                    Destroy(gameObject, 2.3f);
                }

               
            }
        }
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateHealth((float)Health / (float)maxHealth);
    }
}
