using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Ehealth : MonoBehaviour
{
    public int Health;

    public Attack atk;
    public NavMeshAgent agent;
    public GameObject Enm;
    public Collider GCollider;
    public EnemyNav Env;
    public AudioSource hit;
    public AudioSource groan;


    // Start is called before the first frame update
    public void Awake()
    {

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
    }

    // Update is called once per frame
    void Update()
    {

        //if (Health <= 0)
        //{
           // GCollider.isTrigger = true;
            //gameObject.GetComponent<Animator>().SetFloat("locomotion", 0);
            //gameObject.GetComponent<Animator>().SetBool("isDead", true);
            //Destroy(gameObject, 2);
        //}
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Bullet(Clone)"){
            Destroy(collision.gameObject);
            Health -= 10;
            hit.Play();
            if (Health <= 0)
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
