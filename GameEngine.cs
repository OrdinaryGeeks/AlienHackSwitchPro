using Ilumisoft.RadarSystem;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public GameObject VanessaStreet;
    public GameObject Finch;
    public GameObject Robot;
    public GameObject GodwinSave;
    public GameObject jailLoc;
    public GameObject RadarGO;
    public GameObject Mark;
    public GameObject VanessaBM;
    public GameObject VanessaApt;
    public Image ControlsImage;
    public int steveTalk = 0;
    public int jasonTalk = 0;
    public int susanTalk = 0;
    public static int gameState;
    public TMP_Text overviewText;
    public TMP_Text timeText;
    public InputAction Enter, Map;
    public GameObject Grip;
    public GameObject Light;
    public GameObject WorldCam, MapCam;

    public GameObject Godwin, Faldor;
    public GameObject Steve;
    public GameObject Jason;
    public GameObject Susan;
    public GameObject OfficerSmith;

    public GameObject Alpha, Beta, Epsilon;

    public static int mapIndex;
    public static int camFacingIndex;
    public static bool needProcessSwapX;
    public static bool needProcessSwapY;
    public static bool zToX;
    public float gameStateTime;
    public GameObject env1, env2, env3, env4, env5;

    public GameObject susanBMILoc, steveBMILoc, jasonBMILoc;
    public GameObject bmiInteriorLoc, vanessaAptInteriorLoc, JasonAptInteriorLoc, brainNetInteriorLoc;
    public InputAction Go, Controls;
    public bool inBigMobileInt, inVanessaApt, inJasonApt, inBrainNet;
    int hour;
    float minute;
    bool isPM;
    public static bool jasonAptLocGiven;
    public static bool vanessaAptLocGiven;
    public static bool bigMobileLocGiven;
    public static bool brainNetLocGiven;
    int alienState = 0;
    bool isControlScreen;
    public static bool vanessaOurFriend;
    public static bool beenArrested;

    public static bool beenArrestedx2;
    public static bool vanessaOurFriendx2;
    public static bool godwinOurFriend;
    LayerMask boundaryLayerMask;
    public GameObject highRiseLoc, bigMobileLoc, sandysApartmentsLoc, jasonAptLoc, brainNetLoc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beenArrested = false;
        vanessaOurFriend = false;
        jasonAptLoc.SetActive(false);
        sandysApartmentsLoc.SetActive(false);
        bigMobileLoc.SetActive(false);
        bigMobileLocGiven = false;
        jasonAptLocGiven = false;
        vanessaAptLocGiven = false;
        Mark.SetActive(false);
        isControlScreen = false;
        ControlsImage.GetComponent<Image>().enabled = false;
        Alpha.SetActive(false);
        Beta.SetActive(false);
        Epsilon.SetActive(false);
        inVanessaApt = false;
        zToX = false;
        inBigMobileInt = false;
        boundaryLayerMask = LayerMask.GetMask("boundaries");
        hour = 6;
        minute = 0;
        isPM = false;
        timeText.text = "Time-Skip";
        needProcessSwapX = false;
        needProcessSwapY = false;
        camFacingIndex = 0;
        mapIndex = 0;
        gameState = 1;
        Enter = InputSystem.actions.FindAction("Submit");
        Map = InputSystem.actions.FindAction("Map");
        Go = InputSystem.actions.FindAction("Go");
        Controls = InputSystem.actions.FindAction("Controls");
        WorldCam.SetActive(true);
        MapCam.SetActive(false);
    }

    public static void switchToCamIndexZero()
    {
  
            camFacingIndex = 0;
            needProcessSwapX = true;
            needProcessSwapY = true;
        zToX = false;
      
    }

    public static void switchToCamIndexOne()
    {

      
            camFacingIndex = 1;
            needProcessSwapX = true;
            needProcessSwapY = true;

        zToX = false;
    }

    public static void switchToCamIndexTwo()
    {


        camFacingIndex = 2;
        needProcessSwapX = true;
        needProcessSwapY = true;
        zToX = true;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameState);
        if(jasonAptLocGiven)
            jasonAptLoc.SetActive(true);
        else
        jasonAptLoc.SetActive(false);
        if(vanessaAptLocGiven)
            sandysApartmentsLoc.SetActive(true);
        else 
            sandysApartmentsLoc.SetActive(false);
        if ((bigMobileLocGiven))
            bigMobileLoc.SetActive(true);
        else
        bigMobileLoc.SetActive(false);
        if ((brainNetLocGiven))
            brainNetLoc.SetActive(true);
        else
        {
            
            brainNetLoc.SetActive(false);
        }

        if (Controls.triggered)
        {

            if (isControlScreen)
            {
                isControlScreen = false;
                ControlsImage.GetComponent<Image>().enabled = false;
            }
            else
            {
                isControlScreen = true;
                ControlsImage.GetComponent<Image>().enabled = true;
            }
        }
       
        if (gameState >= 12)
        {
            minute += Time.deltaTime;
            if (minute >= 60)
            {
                hour++;
                minute -= 60;
            }
            if (hour >= 12)
                isPM = true;
            if (hour >= 24)
            {
                hour = 0;
                isPM = false;
            }
        }

        if (Grip.GetComponent<Grip>().health <= 0)
            overviewText.text = "Game Over";

        if (mapIndex == 0)
        {
            Ray ray = WorldCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit, 100, ~boundaryLayerMask );

            Vector3 TurnToFace = Grip.transform.position - hit.point;

            float angle = Mathf.Atan2(TurnToFace.x, TurnToFace.z) * Mathf.Rad2Deg;
       
            if(alienState == 0)
            Grip.transform.LookAt(new Vector3(hit.point.x, Grip.transform.position.y, hit.point.z), Vector3.up);

            else
            {
                 if(alienState == 1)
                    Mark.transform.LookAt(new Vector3(hit.point.x, Mark.transform.position.y, hit.point.z), Vector3.up);
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (hit.collider != null)
                {
                    if (alienState == 1)
                    {
                        if (hit.collider.name == "VanessaApt")
                        {
                            if (gameState == 34)
                            {

                                {
                                    overviewText.text = VanessaApt.GetComponent<VanessaApt>().getLevel4Text();
                                }


                            }
                            else if (gameState >= 20)
                            {
                                if (hit.collider.name == "VanessaApt")
                                {
                                    overviewText.text = VanessaApt.GetComponent<VanessaApt>().getLevel3Text();
                                }
                            }
                        }
                        if (gameState < 20)
                        {
                            if (hit.collider.name == "Steve")
                            {
                                overviewText.text = Steve.GetComponent<Steve>().getLevel1Text();
                                steveTalk++;
                            }
                            if (hit.collider.name == "Susan")
                            {

                                susanTalk++;

                                {
                                    overviewText.text = Susan.GetComponent<Susan>().getSusanText();
                                }
                            }
                            if (hit.collider.name == "Jason")
                            {
                                overviewText.text = Jason.GetComponent<Jason>().getLevel1Text();
                                jasonTalk++;
                            }
                        }
                        if(gameState == 20)
                        {
                            if(hit.collider.name == "Vanessa")
                            {
                                overviewText.text = VanessaBM.GetComponent<Vanessa>().getLevel2Text();
                            }
                            if (hit.collider.name == "Steve")
                            {
                                overviewText.text = Steve.GetComponent<Steve>().getLevel2Text();
                                steveTalk++;
                            }
                            if (hit.collider.name == "Susan")
                            {

                                susanTalk++;

                                {
                                  //  overviewText.text = Susan.GetComponent<Susan>().getLevel2();
                                }
                            }
                            if (hit.collider.name == "Jason")
                            {
                                overviewText.text = Jason.GetComponent<Jason>().getLevel2Text();
                                jasonTalk++;
                            }
                        }
                 
                    }
                    if(alienState == 0 || alienState == 1)
                    {
                        if (hit.collider.name == "Godwin")
                        {  if(gameState == 11)
                            {

                                RadarGO.GetComponent<Radar>().Player = Mark;
                                WorldCam.GetComponent<CameraFollow>().player = Mark;
                                overviewText.text = "Hi there Grip.  I have already scanned your credentials. Unfortunately it is not zoned for unlimited TimeSkip.  Please take this identity and camobelt to finish your investigation.  Since you are looking for a hacker I suggest you talk to Susan and Jason.";
                                gameState = 12;
                                alienState = 1;
                                Mark.transform.position = Grip.transform.position;
                                Mark.transform.rotation = Grip.transform.rotation;
                                Mark.SetActive(true);
                                Grip.SetActive(false);

                                susanTalk = 0;
                                jasonTalk = 0;
                            }
                            else if(gameState == 19)
                            {
                                RadarGO.GetComponent<Radar>().Player = Mark;
                                WorldCam.GetComponent<CameraFollow>().player = Mark;
                                overviewText.text = "You show up and now I am registering all this activity.  I hope that is waht you are investigating.  Here is your identity back";
                                gameState = 20;
                                alienState = 1;
                                Mark.transform.position = Grip.transform.position;
                                Mark.transform.rotation = Grip.transform.rotation;
                                Mark.SetActive(true);
                                Grip.GetComponent<Grip>().health = 100;
                                Grip.SetActive(false);

                            }
                            else if ((gameState == 18))
                            {
                                overviewText.text = Godwin.GetComponent<Godwin>().getLevel2Text();
                            }
                            else if(gameState == 37)
                            {
                                overviewText.text = Godwin.GetComponent<Godwin>().getLevel3Text();
                            }
                        }
                    }
                }
            }
        }
        if (Map.triggered)
        {
            if (mapIndex == 0)
            {
                WorldCam.SetActive(false);
                MapCam.SetActive(true);
                mapIndex = 1;
            }
            else if (mapIndex == 1)
            {
                WorldCam.SetActive(true);
                MapCam.SetActive(false);
                mapIndex = 0;
            }
        }

        if (gameState > 34)
        {
            if (!inBigMobileInt & !inBrainNet & !inJasonApt & !inVanessaApt)
            {
                VanessaStreet.GetComponent<VanessaStreet>().gameState = 1;
                if (alienState == 1)
                    VanessaStreet.GetComponent<VanessaStreet>().target = Mark;
                else if (alienState == 2)
                    VanessaStreet.GetComponent<VanessaStreet>().target = Grip;
            }
            else
                VanessaStreet.GetComponent<VanessaStreet>().gameState = 0;
        }

            if (Enter.triggered && gameState == 1)
        {
            overviewText.text = "To save the world, I have to go back in time 100 years to 2025 and stop the singularity on Earth.  That is as far as I have been able to track his movements. Press Enter";
            gameState = 2;
            gameState = 33;

           // gameState = 11;
            bigMobileLocGiven = true;
            brainNetLocGiven = true;
            jasonAptLocGiven = true;
            vanessaAptLocGiven = true;
            //gameState = 20;
          // bigMobileLocGiven = true;
            //jasonAptLocGiven = true;

            RadarGO.GetComponent<Radar>().Player = Mark;
            WorldCam.GetComponent<CameraFollow>().player = Mark;
            overviewText.text = "You show up and now I am registering all this activity.  I hope that is waht you are investigating.  Here is your identity back";
           // gameState = 20;
            alienState = 1;
            Mark.transform.position = Grip.transform.position;
            Mark.transform.rotation = Grip.transform.rotation;
            Mark.SetActive(true);
            Grip.GetComponent<Grip>().health = 100;
            Grip.SetActive(false);

            


            //  Grip.GetComponent<Grip>().isGhost = true;
            env1.SetActive(true);
            env2.SetActive(true);
            env3.SetActive(true);
            env4.SetActive(true);
            env5.SetActive(true);
            WorldCam.GetComponent<CameraFollow>().camState = 1;
            Light.SetActive(true);
        }
        else if (Enter.triggered && gameState == 2)
        {
            overviewText.text = "I sent my gear in the jump before me but Finch tried to intercept it.  It is no telling where my gear is.";
            gameState = 3;
        }
        else if (Enter.triggered && gameState == 3)
        {
            WorldCam.GetComponent<CameraFollow>().camState = 1;
            overviewText.text = "Ah I have arrived.  Memphis, Tn in the year 2025.  Let me go over my gear now";

            //  Grip.GetComponent<Grip>().isGhost = true;
            env1.SetActive(true);
            env2.SetActive(true);
            env3.SetActive(true);
            env4.SetActive(true);
            env5.SetActive(true);
            gameState = 4;
        }
        else if (Enter.triggered && gameState == 4)
        {
            Light.SetActive(true);
            overviewText.text = "First, the most important thing.  I have entered Flow State. Right now time is slowed down significantly.  This is where timewalkers dwell.  You can be pulled into this dimension by other timewalkers.  I have my credentials but the local timeCops are probably already headed here. Let me get a scouting advantage";


        }
        else if (gameState == 4)
        {

            gameStateTime += Time.deltaTime;
            if (gameStateTime > 5)
            {
                gameState = 5;
                overviewText.text = "Did you hear that";
            }
        }
        else if (gameState == 5)
        {

            overviewText.text = "Hey I just got a ping on my watch.  My gear may have just come.  <Press M for map view now>";

            gameState = 6;

        }
        else if (gameState == 6 && Map.triggered)
        {

            overviewText.text = "You are the yellow square. Red squares are places of interest. <Press M for world view now>";
            gameState = 7;
        }
        else if (gameState == 7)
        {
            overviewText.text = "";
            gameState = 8;
        }
        else if (gameState == 8)
        {
            if (Vector3.Distance(Grip.transform.position, Faldor.transform.position) < 5)
            {
                overviewText.text = "Oh its not gear its a timeCop.  Sir I can explain here are my credentials. <I wont tell him why I'm really here yet. He may be the problem>";
                gameState = 9;
            }
        }
        else if (gameState == 9)
        {

            overviewText.text = "Screw your credentials. Prepare to die!";
            gameState = 10;
            Faldor.GetComponent<alienCop>().gameState = 1;

        }
        else if (gameState == 10 && Faldor.GetComponent<alienCop>().health <= 0)
        {
            overviewText.text = "My watch is registering another ping.  A registered timeCop. I should check in. Press M and look for blue";
            gameState = 11;
        }
        else if (gameState == 11)
        {
            //if (Vector3.Distance(Grip.transform.position, Godwin.transform.position) < 5)
            {

            }

        }
        else if (gameState == 12)
        {
            if ((susanTalk >= 7 && jasonTalk >= 3) || steveTalk >= 4)
            {

                Susan.GetComponent<Susan>().setLevel1b(bigMobileLoc.transform.position);
                Jason.GetComponent<Jason>().setLevel1b(bigMobileLoc.transform.position);
                Steve.GetComponent<Steve>().setLevel1b(bigMobileLoc.transform.position);
                overviewText.text = "Follow Jason or Susan or Steve to bigMobile";
                gameState = 13;
            }



        }

        else if (gameState == 13)
        {
            if (Vector3.Distance(Mark.transform.position, bigMobileLoc.transform.position) < 1)
            {
                overviewText.text = "Press g to go inside";

            }

            if (inBigMobileInt)
            {
                gameState = 14;
            }
        }

        else if ((gameState == 14))
        {
            if (!inBigMobileInt)
            {
                gameState = 15;
                overviewText.text = "Deactivate that disguise Time Skiffer.";
            }

        }
        else if (gameState == 15)
        {

            Alpha.SetActive(true);
            Epsilon.SetActive(true);
            Beta.SetActive(true);


            gameState = 16;
        }
        else if (gameState == 16)
        {
            Alpha.GetComponent<alienCop>().gameState = 1;
            Epsilon.GetComponent<alienCop>().gameState = 1;
            Beta.GetComponent<alienCop>().gameState = 1;
            Grip.SetActive(true);
            Grip.transform.position = Mark.transform.position;
            Grip.transform.rotation = Mark.transform.rotation;
            RadarGO.GetComponent<Radar>().Player = Grip;
            WorldCam.GetComponent<CameraFollow>().player = Grip;
            Mark.SetActive(false);
            alienState = 0;
            gameState = 17;


        }
        else if (gameState == 17)
        {
            if ((Alpha.GetComponent<alienCop>().health <= 0 && Epsilon.GetComponent<alienCop>().health <= 0
                && Beta.GetComponent<alienCop>().health <= 0))
            {
                overviewText.text = "I must be getting close.  These guys must work for Finch";
                VanessaBM.SetActive(true);
                gameState = 18;
            }
        }
        else if (gameState == 18)
        {




        }
        else if (gameState == 19)
        {

        }
        else if (gameState == 20 || gameState == 23 || gameState == 24)
        {

            if (inJasonApt && gameState == 20)
            {
                overviewText.text = "Freeze in the name of the law.  We knew someone was up to no good. Prepare to go to jail";
                gameState = 21;
                gameStateTime = 0;
            }
            else if (inJasonApt && gameState == 24)
            {
                overviewText.text = "Freeze cop.  Halt your investigation.  This guy works for me. Oh My God Jason!!!";
                gameState = 25;
                gameStateTime = 0;
            }
            if (inVanessaApt && gameState != 24)
            {
                if (!beenArrested)
                {
                    overviewText.text = "I knew it.  Im in the FBI.  What are you doing here";
                    gameState = 24;
                    gameStateTime = 0;
                }
                else
                {
                    overviewText.text = "CRIMINAL.  POLICE!!!!!";
                    gameState = 30;
                    gameStateTime = 0;
                }


            }
        }
        else if (gameState == 25)
        {

            gameStateTime += Time.deltaTime;
            if (gameStateTime > 3)
            {
                overviewText.text = "What! Where did that X500 come from. ";
                gameState = 26;
            }

        }
        else if (gameState == 26)
        {

            gameStateTime += Time.deltaTime;
            if (gameStateTime > 3)
            {
                overviewText.text = "Wow that was close.  Let me check something.  I knew it. It came from brain-net. Lets check in with Godwin and head over there";
                gameState = 27;
            }
        }
        else if (gameState == 27)
        {
            if (!inBigMobileInt & !inBrainNet & !inJasonApt & !inVanessaApt)
            {
                VanessaStreet.GetComponent<VanessaStreet>().gameState = 1;
                if (alienState == 1)
                    VanessaStreet.GetComponent<VanessaStreet>().target = Mark;
                else if (alienState == 2)
                    VanessaStreet.GetComponent<VanessaStreet>().target = Grip;
            }
            else
                VanessaStreet.GetComponent<VanessaStreet>().gameState = 0;

        }

        else if (gameState == 21)
        {
            gameStateTime += Time.deltaTime;

            if (gameStateTime >= 10)
            {

                gameState = 22;
                inJasonApt = false;

                Mark.transform.position = jailLoc.transform.position;
            }

        }
        else if (gameState == 22)
        {
            gameStateTime = 0;

            beenArrested = true;
            overviewText.text = "I have replaced that body with an AI and brought you back to this timeline.  You will need to be careful with that identity now.  I wonder how they knew who to look for?";
            Mark.transform.position = GodwinSave.transform.position;
            gameState = 23;
        }
        else if (gameState == 24)
        {
            gameStateTime += Time.deltaTime;
            if (gameStateTime > 5)
            {
                overviewText.text = "So you know Godwin!  Why didn't you say so. Thats a great guy.  Lets work together";
                gameState = 24;
                vanessaOurFriend = true;
                VanessaStreet.GetComponent<VanessaStreet>().gameState = 1;

            }

        }
        else if (gameState == 30)
        {
            gameStateTime += Time.deltaTime;

            if (gameStateTime >= 10)
            {

                gameState = 22;
                inJasonApt = false;

                Mark.transform.position = jailLoc.transform.position;
                gameStateTime = 0;
                gameState = 31;
            }
        }
        else if (gameState == 31)
        {
            gameStateTime += Time.deltaTime;
            if (gameStateTime > 5)
            {

                gameState = 32;
            }

        }
        else if (gameState == 32)
        {
            overviewText.text = "This seems like a conundrum.  Lets Time Skip your reality to back before you visited Jason and Vanessa.  Perhaps you should proceed in a different manner";
            Mark.transform.position = GodwinSave.transform.position;
            gameState = 33;
        }
        else if (gameState == 33)
        {
            if (inVanessaApt)
            {
                gameState = 34;
            }
        }
        else if (gameState == 35)
        {
            if (inJasonApt)
            {
                overviewText.text = "Freeze cop.  Halt your investigation.  This guy works for me. Oh My God Jason!!!";
                gameState = 36;
                gameStateTime = 0;
            }
        }
        else if (gameState == 36)

        {
            overviewText.text = "Avoid the x500 while Vanessa hacks into its mainframe.";
            gameStateTime += Time.deltaTime;
            if (gameStateTime >= 5)
            {

                overviewText.text = "Where did that X500 come from!! Good thing I was here. This is covered with brain-net code. Lets report to Godwin then head to brainNet";
                gameState = 37;
            }


        }
            else if (gameState == 38)
        {
            if (alienState == 1)
                Godwin.GetComponent<Godwin>().target = Mark;
            else if ((alienState == 0))
                Godwin.GetComponent<Godwin>().target = Grip;

            gameState = 39;
        }
            else if(gameState == 39)
        {
            if ((inBrainNet))
            {
                overviewText.text = "Grip old friend. Nice of you to come here.  Prepare to die.";
                    gameState = 40;
                gameStateTime = 0;
            }
            
        }
            else if(gameState == 40)
        {

            gameStateTime += Time.deltaTime;
            if (gameStateTime > 4)
            {
                overviewText.text = "You're ALIENS!! I am so freaked out right now";
                Grip.SetActive(true);
                Grip.transform.position = Mark.transform.position;
                Grip.transform.rotation = Mark.transform.rotation;
                RadarGO.GetComponent<Radar>().Player = Grip;
                WorldCam.GetComponent<CameraFollow>().player = Grip;
                Mark.SetActive(false);
                alienState = 0;
            }

        }
        else if (gameState == 41 )
        {
            gameStateTime += Time.deltaTime;
            if (gameStateTime > 4)
            {
                overviewText.text = "Darn he time slipped away.  Lets look for clues to find his accomplice";

            }
        }
            else if(gameState == 42)
        {
            overviewText.text = "Thanks for playing our game. We hope you had fun";
        }

        
            #region goToLocations

            if (alienState == 0)
            {
                if (Vector3.Distance(Grip.transform.position, bigMobileLoc.transform.position) < 3 && Go.triggered)
                {
                    Grip.transform.position = bmiInteriorLoc.transform.position;
                    inBigMobileInt = true;
                }


                else if (inBigMobileInt && Go.triggered)
                {

                    Grip.transform.position = bigMobileLoc.transform.position;
                    inBigMobileInt = false;
                }
            }
        

        if (alienState == 0)
        {
            //Debug.Log(Vector3.Distance(Grip.transform.position, sandysApartmentsLoc.transform.position));
            if (Vector3.Distance(Grip.transform.position, sandysApartmentsLoc.transform.position) < 3 && Go.triggered)
            {
                Grip.transform.position = vanessaAptInteriorLoc.transform.position;
                inVanessaApt = true;
            }
            else if (inVanessaApt && Go.triggered)
            {

                Grip.transform.position = sandysApartmentsLoc.transform.position;
                inVanessaApt = false;
            }
        }
        if (alienState == 0)
        {
            if (Vector3.Distance(Grip.transform.position, jasonAptLoc.transform.position) < 3 && Go.triggered)
            {
                Grip.transform.position = JasonAptInteriorLoc.transform.position;
                inJasonApt = true;
            }
            else if (inJasonApt && Go.triggered)
            {

                Grip.transform.position = jasonAptLoc.transform.position;
                inJasonApt = false;
            }
        }
        if (alienState == 1)
        {
            if (Vector3.Distance(Mark.transform.position, bigMobileLoc.transform.position) < 3 && Go.triggered)
            {
                Mark.transform.position = bmiInteriorLoc.transform.position;
                inBigMobileInt = true;
            }


            else if (inBigMobileInt && Go.triggered)
            {

                Mark.transform.position = bigMobileLoc.transform.position;
                inBigMobileInt = false;
            }
        }

        if (alienState == 1)
        {
            //Debug.Log(Vector3.Distance(Grip.transform.position, sandysApartmentsLoc.transform.position));
            if (Vector3.Distance(Mark.transform.position, sandysApartmentsLoc.transform.position) < 3 && Go.triggered)
            {
                Mark.transform.position = vanessaAptInteriorLoc.transform.position;
                inVanessaApt = true;
            }
            else if (inVanessaApt && Go.triggered)
            {

                Mark.transform.position = sandysApartmentsLoc.transform.position;
                inVanessaApt = false;
            }
        }
        if (alienState == 1)
        {
           
            if (Vector3.Distance(Mark.transform.position, jasonAptLoc.transform.position) < 3 && Go.triggered)
            {
                Mark.transform.position = JasonAptInteriorLoc.transform.position;
                inJasonApt = true;
            }
            else if (inJasonApt && Go.triggered)
            {

                Mark.transform.position = jasonAptLoc.transform.position;
                inJasonApt = false;
            }
        }
        if (alienState == 1)
        {
            if (Vector3.Distance(Mark.transform.position, brainNetLoc.transform.position) < 3 && Go.triggered)
            {
                Mark.transform.position = brainNetInteriorLoc.transform.position;
                inBrainNet = true;
            }


            else if (inBrainNet && Go.triggered)
            {

                Mark.transform.position = brainNetInteriorLoc.transform.position;
                inBrainNet = false;
            }
        }
        #endregion
        if (gameState >= 12 && gameState!= 15 && gameState != 11)
        {
            if (isPM)
                timeText.text = hour.ToString() + ":" + minute.ToString() + "PM";
            else
                timeText.text = hour.ToString() + ":" + minute.ToString() + "AM";
        }
        else if(gameState == 15)
        {
            timeText.text = "Time Skip";
        }

    }
}
