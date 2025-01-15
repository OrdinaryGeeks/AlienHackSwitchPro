using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public int camState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camState = 0;
        transform.position = Vector3.zero + Vector3.up * 3.0f;
        transform.LookAt(Vector3.zero);
    
    }

    // Update is called once per frame
    void Update()
    {

        if ((camState == 1))
        {
            if (GameEngine.gameState != 40)
            {
                if (GameEngine.camFacingIndex == 1)
                {
                    transform.position = player.transform.position + (player.transform.up * 5.2f) + (Vector3.forward * -3.0f);
                    transform.LookAt(player.transform.position);


                }
                else if (GameEngine.camFacingIndex == 0)
                {
                    transform.position = player.transform.position + (player.transform.up * 5.2f) - (Vector3.forward * -3.0f);
                    transform.LookAt(player.transform.position);
                }
                else if ((GameEngine.camFacingIndex == 2))
                {
                    transform.position = player.transform.position + (player.transform.up * 5.2f) + (Vector3.right * -3.0f);
                    transform.LookAt(player.transform.position);

                }
            }
            else
            {

                transform.position = player.transform.position + (player.transform.up * 10.2f) + (Vector3.forward * -3.0f);
                transform.LookAt(player.transform.position);
            }

        }
    }
}
