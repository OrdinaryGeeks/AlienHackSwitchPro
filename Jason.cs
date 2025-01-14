using UnityEngine;
using UnityEngine.AI;

public class Jason : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string[] Level1Text;
    int Level1TextIndex = 0;

    string[] Level2Text;
    int Level2TextIndex = 0;

    int gameState = 0;
    NavMeshAgent nav;
    public Vector3 destination;
    Animator anim;

    public GameObject JasonBMILoc;
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        Level1Text = new string[] {"Hey I'm Jason.  You are new around here.  Whats your name?",
            "Are you visiting for a long time or have you come to stay.  The apartments at Glad and 2nd have good rent.",
            "Me? I'm a programmer. I work for the big guy right here."
        };

        Level2Text = new string[] {"Oh me. I stay on 1st and Front st.  It is actually close to where we met",
        "Yeah man. I like Vanessa.  But lately I have noticed that the code is doing things its not supposed to do, possibly",
        "I try to tell people but they just think I am jealous.  She is a prodigy, sure, but something about this timing is not adding up."};
    }

    public string getLevel1Text()
    {
        if(Level1TextIndex >= Level1Text.Length)
        Level1TextIndex = 0;

        return Level1Text[Level1TextIndex++];

    }


    public string getLevel2Text()
    {
        GameEngine.jasonAptLocGiven = true;
        if (Level2TextIndex >= Level2Text.Length)
            Level2TextIndex = 0;

        return Level2Text[Level2TextIndex++];

    }
    // Update is called once per frame

    public void setLevel1b(Vector3 destination)
    {

        nav.SetDestination(destination);
        gameState = 1;
    }
    // Update is called once per frame
    void Update()
    {

        if (gameState == 1)
        {
            
            if (nav.remainingDistance < .3f)
            {
                anim.SetBool("isRun", false);
                //nav.isStopped = true;
                //transform.position = JasonBMILoc.transform.position;
                this.gameObject.SetActive(false);
                gameState = 2;
            }
            else
            { 
                anim.SetBool("isRun", true);
               
            }
        }

    }
}
