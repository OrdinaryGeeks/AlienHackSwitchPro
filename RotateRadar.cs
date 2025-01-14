using UnityEngine;

public class RotateRadar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameEngine.camFacingIndex == 0)
            transform.rotation = Quaternion.Euler(0f, 180.0f, 0.0f);
    }
}
