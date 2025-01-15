using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Susan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public string[] Level1Text;
    public string[] JasonText;
    public string[] 
        
        SteveText;
    public string[] SteveAndJasonText;
    public int JasonTextIndex = 0;
    public int Level1TextIndex = 0;
    public int SteveTextIndex = 0;
    public int SteveAndJasonTextIndex = 0;

    public GameObject susanBMI;
    public int gameState;
    NavMeshAgent nav;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        Level1Text = new string[]
        {
            "Hi I'm Susan.  Im an accountant for Big Mobile",
            "I am new in town but have worked for Big Mobile for 5 years",
            "Are you interested in being a customer. Our office is right down the street at 110 Front St",

            "Oh you talked to Jason.  He is a great guy. Did he mention the new update",
            "Jason is our key programmer.  He has been on edge lately due to the new girl",
            "Steve is our CEO.  He is a great mind.  He likes to take days off without telling anyone though",
              "The new lady is a child prodigy.  Her name is Vanessa.  If you get a chance talk to her!"


        };
        JasonText = new string[]
        {
            "Oh you talked to Jason.  He is a great guy. Did he mention the new update",
            "Jason is our key programmer.  He has been on edge lately due to the new guy"
        };
        SteveText = new string[]
        {
            "Steve is our CEO.  He is a great mind.  He likes to take days off without telling anyone though"
        };
        SteveAndJasonText = new string[]
        {
            "The new lady is a child prodigy.  Her name is Samantha.  If you get a chance talk to her!"
        };

    }

    public string getSteveAndJasonText()
    {

        if (SteveAndJasonTextIndex >= SteveAndJasonText.Length)
            SteveAndJasonTextIndex =   0;
        return SteveAndJasonText[SteveAndJasonTextIndex++];

    }
    public string getSteveText()
    {

        if (SteveTextIndex >= SteveText.Length)
            SteveTextIndex = 0;
        return SteveText[SteveTextIndex++];

    }
    public string getJasonText()
    {

        if (JasonTextIndex >= JasonText.Length)
            JasonTextIndex = 0;
        return JasonText[JasonTextIndex++];

    }
    public string getSusanText()
    {
        if (Level1TextIndex == 2)
            GameEngine.bigMobileLocGiven = true;
        if (Level1TextIndex >= Level1Text.Length)
            Level1TextIndex = 0;
        return Level1Text[Level1TextIndex++];

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
              //  nav.isStopped = true;
              //  transform.position = susanBMI.transform.position;
                gameState = 2;
                this.gameObject.SetActive(false);
                anim.SetBool("isRun", false);
            }
            else
            {
                anim.SetBool("isRun", true);
            }
        }

    }
}
