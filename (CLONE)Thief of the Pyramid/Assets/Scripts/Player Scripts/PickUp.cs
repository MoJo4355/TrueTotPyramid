using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class PickUp : MonoBehaviour
{
    //THIS SCRIPT IS USED TO PICK UP OBJECTS IN THE GAME, AS WELL AS ANY OTHER INTERACTION.
    [Header("GAME OBJECTS")]
    public GameObject Dummy;
    public GameObject Treasure; 
    public GameObject Torch;
    public GameObject SecOne;
    public GameObject SecTwo;
    public GameObject Key;
    public GameObject doorInteract; 
    public GameObject Player;   
    public GameObject PAUSEDCAMERA;
    public GameObject CamHolder;
    public GameObject HOLDER;
    public GameObject GM;
    public GameObject Deather;
    public GameObject ScreamHolder;
    public GameObject CurrentScream;
    public GameObject Scream1;
    public GameObject MainDoor;
    public GameObject FinalDoor;
    public GameObject Essentials;
    public GameObject WallBreaker;
    public GameObject Blocker;
    public GameObject LScreen;
    public GameObject StartDoor;
    public GameObject FindTreasure;
    public GameObject FindExit;
    public GameObject ObjectiveParent;
    public GameObject Blockade;
    public GameObject Hall;

    [Header("PAUSE MENU OBJECTS")]
    public GameObject PauseMenu;
    public GameObject Resume;
    public GameObject MainMenu;
    public GameObject Settings;

    [Header("TEXT OBJECTS")]
    public Text Tleft;
    public Text Interact;
    public Text GatePull;
    public Text Gtorch;
    public Text Doortext;
    public Text Keygone;
    public TMP_Text DoorRequirements;
    public Text healcound;

    [Header("INTEGERS AND BOOLIANS")]
    public int CheckpointsReached;
    public int Remaining;
    public int Inorder;
    public int Rnadint;
    public int healsLeft;
    public bool TheDoorisOpen;
    public bool Tester;
    public bool torcher;
    public bool Keyer;
    public bool Dooropener;
    public bool DOORSTUCK;
    public bool BroadCastEnNav;
    public bool Translated;
    public bool TabLETMESEEIT;
    public bool levelflip;
    public bool grablever;
    public bool opensesame;
    public bool CurseTriggered;
    public bool RunTrigger;
    public bool wallturnoff;
    public bool GuiderOn;
    public bool BroadcastEnemy1;
    public bool doorDown;
    public bool enemySpawnTut;
   
    [Header("Respawn at Checkpoint")]
    public GameObject CurrentDummy;
    

    [Header("OTHER SCRIPTS")]
    public cameramovement CM;
    public PlayerMovement PM;
    public PlayerHealth PHScript;
    public Attack ATK;
    public BoolCheck BC;
    public Light lighten;
    public AudioSource AS;
    public AudioSource DoorOpens;
    public AudioSource whammy;
    public AudioSource catWhisper;
    public AudioSource CallofEnemy;
    public AudioSource TreasureSound;
    public AudioSource GetKey;
    public Animation cardSwoop;
    public Animator StartUp;

    [Header("MISCELLANIOUS TERMS")]
    public Transform player;


    [Header("Other Scene Helpers")]
    public string SceneName;
    public bool TreasureTrapActive;
    public bool DoneOnce;
    public bool CatPuzHelp;
    public Scene scene;

    public void Awake()
    {
        HOLDER = GameObject.FindWithTag("PauseHTP");

        if(SceneName == "Level 1")
        {
            Inorder = 0;
        }else if(SceneName == "Tutorial")
        {
            Blocker.SetActive(false);
        }
    }

    public void Start()
    {
        //other
        if(HOLDER == null)
        {
            HOLDER = GameObject.FindWithTag("PauseHTP");

        }

        if(BC == null)
        {
            GM = GameObject.FindWithTag("Controller");
            BoolCheck BC = GM.GetComponent<BoolCheck>();
        }

        scene = SceneManager.GetActiveScene();
        SceneName = scene.name;
        Cursor.lockState = CursorLockMode.Locked;
        Remaining = GameObject.FindGameObjectsWithTag("Treasure").Length;

        
        //bools
        Tester = false;
        torcher = false;
        Keyer = false;
        Dooropener = false;
        BC.deathHelp = false;
        TheDoorisOpen = false;
        Translated = false;
        //text
        Interact.enabled = false;
        GatePull.enabled = false;
        Gtorch.enabled = false;
        Doortext.enabled = false;
        Keygone.enabled = false;
        Tleft.text = Remaining.ToString();
        //game objects
        PauseMenu.SetActive(false);
        HOLDER.SetActive(false);
        Scream1.SetActive(false);
        ScreamHolder.SetActive(false);
        //scripts

    }

    public void Update()
    {
        if (BC == null)
        {
            GM = GameObject.FindWithTag("Controller");
            BoolCheck BC = GM.GetComponent<BoolCheck>();
        }

        if(SceneName == "Level 1" || SceneName == "Level 2")
        {
            DoorRequirements.SetText(Remaining.ToString());
        }
        //maindoor
        if(opensesame == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Interact.enabled = false;
                MainDoor.SetActive(false);
                BC.Finaler = true;
            }
        }

        //THIS IS FOR PICKING UP TREASURE IN GENERAL
        if (Tester == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(Treasure.gameObject);
                Interact.enabled = false;
                Remaining--;
                Tleft.text = Remaining.ToString();
                Tester = false;
                TreasureSound.Play();
                if(SceneName == "Level 1"){
                    if (DoneOnce == true){
                        TreasureTrapActive = true;
                        DoneOnce = false;
                        CallofEnemy.Play();
                    }
                }else if (SceneName == "Level 2")
                {
                    if(Treasure.name == "WallTreasure")
                    {
                        WallBreaker.SetActive(true);
                        wallturnoff = true;
                    }

                }
            }
        }
        if(wallturnoff == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                WallBreaker.SetActive(false);
            }
        }

        //TORCH DONE
        if(torcher == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Gtorch.enabled = false;
                torcher = false;
                // Instantiate(Torch, player.transform, false);
                // Torch.transform.localPosition = new Vector3(0, 0f, 0f);
                lighten.enabled = true;

            }
        }

        //picks up keys
        if(Keyer == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(Key.gameObject);
                Dooropener = true;
                Interact.enabled = false;
                Keyer = false;
                GetKey.Play();
            }
        }
        
        //used to open the door to the enemies... **** might keep
        if (DOORSTUCK == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(doorInteract.gameObject);
                if(SceneName == "Tutorial" || SceneName == "Prototype")
                {
                    CallofEnemy.Play();
                    BroadcastEnemy1 = true;
                    BC.EnemyNavEnable = true;
                    Blocker.SetActive(true);
                    SecTwo.SetActive(false);
                }
                else if(SceneName == "Level 1")
                {
                    DoorOpens.Play();
                }

                Doortext.enabled = false;
                BC.enlightened = true;
                DoorOpens.Play();
                Keyer = false;
                DOORSTUCK = false;
                Dooropener = false;
            }
        }
        // DEFINITELY KEEP THIS IS THE PAUSE MENU
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(BC.DISABLE == true)
            {
                Essentials.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                PauseMenu.SetActive(false);
                PM.enabled = true;
                ATK.enabled = true;
                CM.enabled = true;
                CamHolder.SetActive(true);
                PAUSEDCAMERA.SetActive(false);
                BC.DISABLE = false;
              
            }
            else
            {
                Essentials.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PauseMenu.SetActive(true);
                ATK.enabled = false;
                PM.enabled = false;
                CM.enabled = false;
                CamHolder.SetActive(false);
                PAUSEDCAMERA.SetActive(true);
                BC.DISABLE = true;
                Time.timeScale = 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (healsLeft > 0 && PHScript.phealth < 100)
            {
                PHScript.phealth += 50;
                if(PHScript.phealth > 100)
                {
                    PHScript.phealth = 100;
                }
                healsLeft -= 1;
                healcound.text = healsLeft.ToString();
            }
        }

        // DEFINITELY KEEP this is the respawn command...
        if (BC.deathHelp == true)
        {
            ATK.enabled = false;
            PM.enabled = false;
            if (Input.GetKeyDown(KeyCode.R))
            {
                if(CheckpointsReached < 1){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }else{
                
                //
                }
                
            }
        }



        //enables the end run
        if(CurseTriggered == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RunTrigger = true;
                Interact.enabled = false;
            }
          
        }

        //Level1 stuff for cat puzzle
        if(SceneName == "Level 1")
        {
            if (TabLETMESEEIT == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(Translated == true)
                    {
                        CatPuzHelp = true;
                        Interact.enabled = false;
                        TabLETMESEEIT = false;
                    }
                    else
                    {
                        CatPuzHelp = true;
                        Interact.enabled = false;
                        TabLETMESEEIT = false;
                    }

                }
            }
            
            if(grablever == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GatePull.enabled = false;
                    levelflip = true;
                }
            }
        }

       // if(BC.finaldooropen == true)
        //{
           // if (Input.GetKeyDown(KeyCode.Space))
            //{
             //   Interact.enabled = false;
           //     Destroy(FinalDoor.gameObject);
          //  }
      //  }
        

        // To Do: Put this in the turnon script
        if(Remaining == 0)
        {
            TheDoorisOpen = true;
            FindTreasure.SetActive(false);
            FindExit.SetActive(true);
            if(SceneName == "Tutorial" || SceneName == "Prototype")
            {
                Blockade.SetActive(true);
                Hall.SetActive(false);
            }
        }

    }






    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            if(CurrentDummy != null){
                Destroy(CurrentDummy.gameObject);
                CurrentDummy = Instantiate(Dummy, transform.position, transform.rotation);
            }else{
                CurrentDummy = Instantiate(Dummy, transform.position, transform.rotation);
            }
            Destroy(other.gameObject);
            CheckpointsReached += 1;
        }

        if(other.name == "StartDoor")
        {
           StartUp = StartDoor.GetComponent<Animator>();
            GuiderOn = true;
            StartUp.SetBool("Raise", true);
            Invoke("BetterWay", 4.3f);
        }

        if(other.name == "Lighttrigger")
        {

        }

        if(other.gameObject.tag == "mainDoor")
        {
            if(Remaining != 0)
            {
            }
            else if(Remaining == 0)
            {
                opensesame = true;
                Interact.enabled = true;
            }
        }

        //This script lets you know if you touched the treasure
        if (other.gameObject.tag == "Treasure")
        {
            if (other.name == "TrappedTreasure")
            {
                DoneOnce = true;
                Tester = true;
                Treasure = other.gameObject;
                Interact.enabled = true;
            }
            else if(other.name == "WallTreasure")
            {
                Tester = true;
                Treasure = other.gameObject;
                Interact.enabled = true;
            }
            else
            {
                DoneOnce = false;
                Tester = true;
                Treasure = other.gameObject;
                Interact.enabled = true;
            }
        }

        //This script below lets you know if you have touched the torch object.

        if (other.gameObject.tag == "Torch")
        {
            Destroy(other.gameObject);
            torcher = true;
            Gtorch.enabled = true;
            BC.TorchHelp = true;
        }

        //This script below lets you know if you touched the key stool.

        if (other.gameObject.CompareTag("Key"))
        {
            Keyer = true;
            Key = other.gameObject;
            Interact.enabled = true;
        }


        if (other.gameObject.CompareTag("door"))
        {
            if (Dooropener == true)
            {
                doorInteract = other.gameObject;
                DOORSTUCK = true;
                Doortext.enabled = true;
                Keygone.enabled = false;
            }
            else
            {
                Keygone.enabled = true;
            }
        }

        //I LIED !!!!! hhhhahaHAHHAHA
        if (other.gameObject.CompareTag("yikes"))
        {
            ScreamHolder.SetActive(true);
            AS = Deather.GetComponent<AudioSource>();
            BC.deathHelp = true;
            AS.Play();
            Rnadint = Random.Range(0, 10);
            CurrentScream = null;
            if (true)
            {
                CurrentScream = Scream1;
                Scream1.SetActive(true);
                BC.deathHelp = true;
            }
        }

        if (other.name == "CurseTrigger")
        {
            Interact.enabled = true;
            CurseTriggered = true;
        }


        //Go to Levels
        if (other.gameObject.CompareTag("Exit"))
        {
            LScreen.SetActive(true);
            cardSwoop.Play();
            Invoke("SceneSwitch", 3);

        }

        //Cat puzzle and other Level one stuff
        if (SceneName == "Level 1")
        {
            if (other.gameObject.CompareTag("Hieroglyphics"))
            {
                if (Translated == true)
                {
                    Interact.enabled = true;
                    TabLETMESEEIT = true;
                }
                else
                {
                    Interact.enabled = true;
                    TabLETMESEEIT = true;
                }
            }

            if(other.name == "RoseStone")
            {
                Translated = true;
                Destroy(other.gameObject);
                //turns on the translated tablet 
            }



            if(other.name == "RedCat")
            {
                if(Inorder == 0 || Inorder == 1)
                {
                    Inorder += 1;
                    catWhisper.Play();
                }
                else
                {
                    Inorder = 0;
                    whammy.Play();
                }
            }
            else if(other.name == "BlueCat")
            {
                if(Inorder == 2 || Inorder == 5)
                {
                    Inorder += 1;
                    catWhisper.Play();
                }
                else
                {
                    Inorder = 0;
                    whammy.Play();
                }
            }
            else if(other.name == "YellowCat")
            {
                if(Inorder == 3)
                {
                    Inorder += 1;
                    catWhisper.Play();
                }
                else
                {
                    Inorder = 0;
                    whammy.Play();
                }
            }
            else if(other.name == "GreenCat")
            {
                if(Inorder == 4)
                {
                    Inorder += 1;
                    catWhisper.Play();
                }
                else
                {
                    Inorder = 0;
                    whammy.Play();
                }
            }
            else if(other.name == "BlackCat")
            {
                if(Inorder == 6)
                {
                    Inorder += 1;
                    catWhisper.Play();
                    //The levelOneHelper script then goes and removes the door for the treasure;
                }
                else
                {
                    Inorder = 0;
                    whammy.Play();
                }
            }

            if(other.name == "Gate Lever")
            {
                if (grablever == false)
                {
                    GatePull.enabled = true;
                    grablever = true;
                    //this opens the gate for the rosetta stone
                }
            }

            if(other.gameObject.tag == "eye")
            {

            }

        }
    }

        //****************************************************************************************\\




        //Resets the pause menu
        public void OnResumeClicked()
        {

            HOLDER.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            PauseMenu.SetActive(false);
            PM.enabled = true;
            ATK.enabled = true;
            CM.enabled = true;
            CamHolder.SetActive(true);
            PAUSEDCAMERA.SetActive(false);
            BC.DISABLE = false;
        Essentials.SetActive(true);
        }

        public void OnMenuClicked()
        {
            SceneManager.LoadScene(0);

        }

        public void OnHowToPlayClicked()
        {
            HOLDER.SetActive(true);

        }

        public void OnBackClicked()
        {
            HOLDER.SetActive(false);

        }

    public void SceneSwitch()
    {
        if (SceneName == "Tutorial")
        {
            SceneManager.LoadScene(2);
        }else if (SceneName == "Level 1")
        {
            SceneManager.LoadScene(3);
        }
        else if (SceneName == "Level 2")
        {
            SceneManager.LoadScene(4);
        }
    }

    public void BetterWay()
    {
        StartDoor.SetActive(false);
    }


    

    //𓂋𓅂𓂧 𓂋𓅂𓂧 𓎼𓂋𓅂𓅂𓈖 𓇌𓅂𓃭𓃭𓅱𓅃 𓃀𓃭𓅲𓅂 𓎼𓂋𓅂𓅂𓈖 𓂋𓅂𓂧 𓃀𓃭𓄿𓎢𓈎𓄼 𓏏𓉔𓅂𓈖 𓏏𓉔𓅂 𓃀𓅲𓏏𓏏𓅱𓈖
}
