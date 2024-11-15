using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnon : MonoBehaviour
{
    public BoolCheck BC;
    public PickUp Picks;

    public GameObject Me;
    public GameObject Torch;
    public GameObject door1;
    public GameObject doorLight;
    public GameObject ES1;
    public GameObject ES2;
    public Animation doorGoUp;
    public Animation DoorGoDown;
    public GameObject Essentials;
    public GameObject Lore;
    public Attack attack;
    public PlayerMovement PM;
    public cameramovement CM;
// Ill try to use this script to act as the manager for the first level(tutorial)
    void Start()
    {
        door1.SetActive(true);
        doorGoUp.Stop();
        Torch.SetActive(false);
        PM.enabled = false;
        CM.enabled = false;
        attack.enabled = false;
        Essentials.SetActive(false);
        Lore.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Essentials.SetActive(true);
            Lore.SetActive(false);
            CM.enabled = true;
            PM.enabled = true;
            attack.enabled = true;
        }

        if(BC.enlightened == true)
        {
            Me.SetActive(true);
        }

        if (BC.TorchHelp == true)
        {
            Destroy(Torch.gameObject);
        }

        if (Picks.TheDoorisOpen == true)
        {
            doorLight.SetActive(true);
            Destroy(door1);
        }

        if(Picks.GuiderOn == true)
        {
            Torch.SetActive(true);
            Picks.GuiderOn = false;
        }

        if(Picks.enemySpawnTut == true)
        {
            ES1.SetActive(true);
            ES2.SetActive(true);
            DoorGoDown.Play();
        }
    }
}
