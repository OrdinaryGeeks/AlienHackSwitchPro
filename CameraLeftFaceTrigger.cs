using UnityEngine;

public class CameraLeftFaceTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameEngine.switchToCamIndexTwo();//.GetComponent<CameraFollow>().camState = 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            GameEngine.switchToCamIndexZero();//.GetComponent<CameraFollow>().camState = 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
