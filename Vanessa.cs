using UnityEngine;

public class Vanessa : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    string[] Level2Text;
    int Level2Index = 0;
    void Start()
    {

        Level2Text = new string[] {
            "So you are interested in my cyber defense skills",
            "Are you a programmer?  Im surprised Steve let you in here",
            "I have just moved into the city.  I stay over at Sandy's Apartments Complex",
            "Sorry if I am not forthright.  I feel that what we are doing maybe dangerous.  Are you dangerous?",
            "Anywho, I need to get back to work. Nice speaking with you" };
    }

    public string getLevel2Text()
    {
        if (Level2Index >= Level2Text.Length)
            Level2Index = 0;
        if (Level2Index == 2)
            GameEngine.vanessaAptLocGiven = true;
        return Level2Text[Level2Index++];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
