using UnityEngine;

public class AudioEngine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioSource laserBeam;
    public AudioSource laserBeam2;
    public AudioSource laserBeam3;
    public AudioSource footsteps;
    public AudioSource footsteps2;
    public AudioSource footsteps3;

    public static bool playFootSteps1;
    public static bool playFootSteps2;
    public static bool playFootSteps3;
    public static bool playLaserBeam1;
    public static bool playLaserBeam2;
    public static bool playLaserBeam3;

    public static void PlayALaserBeamSound()
    {
        Debug.Log("Play a laser beam sound");
       if (!playLaserBeam1)
            playLaserBeam1 = true;
        else if (!playLaserBeam2)
            playLaserBeam2 = true;
        else if (!playLaserBeam3)
            playLaserBeam3 = true;
    }
    void Start()
    {
        playLaserBeam1 = false;
        playLaserBeam2 = false;
        playLaserBeam3 = false;
        
    }

   

    // Update is called once per frame
    void Update()
    {
        if(playLaserBeam1)
        {
            laserBeam.Play();
            playLaserBeam1 = false;
        }
     
        if(playLaserBeam2)
        {
            laserBeam2.Play();
            playLaserBeam2 = false;
        }
       
        if (playLaserBeam3)
        {
            laserBeam3.Play();
            playLaserBeam3 = false;
        }
      
        if (playFootSteps1)
        {
            footsteps.Play();
            playFootSteps1 = false;
        }
        if (playFootSteps2)
        {
            footsteps2.Play();
            playFootSteps2 = false;
        }
        if (playFootSteps3)
        {
            footsteps3.Play();
            playFootSteps3 = false;
        }
    }
}
