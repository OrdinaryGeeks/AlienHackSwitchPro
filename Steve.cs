using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Apple;
using UnityEngine.InputSystem.Utilities;

public class Steve : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string[] Level1Text;
    int Level1TextIndex = 0;
    int gameState = 0;
    NavMeshAgent nav;
    public Vector3 destination;
    Animator anim;
    public GameObject SteveBMILoc;


    string[] Level2Text;
    int Level2TextIndex = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        Level1Text = new string[] {"Hey there.  You look like a bright young person.  My name's Steve.",
            "I run a tech firm that programs the digital link between wellness implants.  My big rollout is three days from now",
            "We aren't hiring now but one of our sister companies, brain-net is.  They are on Glad and 3rd. Tell them I sent you.",
            "Oh I'm tired of talking. Break's over guys. Back to work.  You can follow us to our job"
        };

        Level2Text = new string[] {"Did you check out Brain-Net yet.  Listen, I know I didnt give you an exact location.",
            "But friend, you need a job instead of nosing around here all the time.  I tell you what",
            "I am going to personally call them and ask them to hire you.  They are located on ",
        "Here is a map to the location"};
    }

    public string getLevel1Text()
    {
        if (Level1TextIndex >= Level1Text.Length)
            Level1TextIndex = 0;

        if (Level1TextIndex == 3)
            GameEngine.bigMobileLocGiven = true;

        return Level1Text[Level1TextIndex++];

    }
    public string getLevel2Text()
    {
        if (Level2TextIndex == 3)
            GameEngine.brainNetLocGiven = true;
        if (Level2TextIndex >= Level2Text.Length)
            Level2TextIndex = 0;

        return Level2Text[Level2TextIndex++];

    }
    public void setLevel1b(Vector3 destination)
    {

        nav.SetDestination(destination);
        Debug.Log(nav.remainingDistance + " is steves reminaing distance on set");
        gameState = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameState == 1)
        {
            Debug.Log("Steve in gamestate 1");
            if (!nav.pathPending && nav.remainingDistance < .3f)
            {
                anim.SetBool("isRun", false);
                //  nav.isStopped = true;
                Debug.Log("Steve abot to be deactivated");
                // transform.position = SteveBMILoc.transform.position;
                this.gameObject.SetActive(false);
                gameState = 2;
            }
            else
                anim.SetBool("isRun", true);
        }
    }
}
