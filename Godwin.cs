using UnityEngine;

public class Godwin : MonoBehaviour
{

    string[] Level1Text;
    string[] Level2Text;
    string[] Level3Text;
    int Level1TextIndex = 0;
    int Level2TextIndex = 0;
    int Level3TextIndex = 0;

    public GameObject target;
    int gameState = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Level1Text = new string[] {
            "You are immortal as long as you wear your watch. It is set to restart you here if you fail your mission"
        };

        Level2Text = new string[]
        {
            "I can heal you and replace your identity if you come talk to me",
            "I have saved your codex.  If I notice your beacon fade I will transport you back to the last time that you talked to me",
            "Eventually your time Slip will be authorized and you can move around the time stream"
        };
        Level3Text = new string[]
            {
                "Thanks for reporting in.  Hello again Mark and Vanessa.  Vanessa I think you should let me and Mark handle this.",
                "Mark and I can head over to take care of our \"Important Business\" and we'll report to you when we are done"

            };

    }
    public string getLevel3Text()
    {
        if (Level3TextIndex >= Level3Text.Length)
            Level3TextIndex = 0;

        if(Level3TextIndex == 1)
        { GameEngine.gameState = 38;
            gameState = 1;
        }

        return Level3Text[Level3TextIndex++];

    }
    public string getLevel1Text()
    {
        if (Level1TextIndex >= Level1Text.Length)
            Level1TextIndex = 0;

        return Level1Text[Level1TextIndex++];

    }
    public string getLevel2Text()
    {
        if (Level2TextIndex >= Level2Text.Length)
            Level2TextIndex = 0;
        if (Level2TextIndex == 2 && GameEngine.gameState == 18)
            GameEngine.gameState = 19;
        return Level2Text[Level2TextIndex++];

    }
    // Update is called once per frame
    void Update()
    {
        if(gameState == 1)
        {
            Vector3 direction = target.transform.position - transform.position;
            if (Vector3.Distance(target.transform.position, transform.position) > .3)
                transform.position += direction * 5 * Time.deltaTime;
        }
    }
}
