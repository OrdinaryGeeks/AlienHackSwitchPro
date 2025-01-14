using UnityEngine;

public class CameraFrontFaceTrigger : MonoBehaviour
{
   // public GameObject WorldCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEngine.switchToCamIndexZero();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
         
            GameEngine.switchToCamIndexZero();//.GetComponent<CameraFollow>().camState = 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            GameEngine.switchToCamIndexOne();//.GetComponent<CameraFollow>().camState = 2;
        }
    }
    // Update is called once per frame
    void Update()
    {


        
    }
}
