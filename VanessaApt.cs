using UnityEngine;

public class VanessaApt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    string[] Level3Text;
    int Level3TextIndex = 0;

    string[] Level4Text;
    int Level4TextIndex = 0;
    void Start()
    {
        Level3Text = new string[] {"Freeze in the name of the law. I work for an international agency that has been investigating the neural link",
            "Come completely clean and I may work with you. Its obvious you aren't the brains" };

        Level4Text = new string[] {"Thanks for visiting.  So you say you are a International Agent and investigating Jason.",
        "I have looked into Jason high and low and he is clean. You see I'm a FBI agent.  But since Godwin already vouched for you",
        "I say we go check it out"};
    }

    public string getLevel3Text()
    {
        if (Level3TextIndex >= Level3Text.Length)
            Level3TextIndex = 0;
        return Level3Text[Level3TextIndex++];
    }

    public string getLevel4Text()
    {
        if (Level4TextIndex == 2)
            GameEngine.gameState = 35;
        if (Level4TextIndex >= Level4Text.Length)
            Level4TextIndex = 0;
       
        return Level4Text[Level4TextIndex++];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
