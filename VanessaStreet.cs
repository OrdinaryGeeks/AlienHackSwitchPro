using UnityEngine;

public class VanessaStreet : MonoBehaviour
{
    public int gameState = 0;
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameState == 1)
        {
            if(Vector3.Distance(target.transform.position, transform.position) > 2)
            {
                Vector3 direction = target.transform.position - new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
                
                transform.position += direction * 7 * Time.deltaTime;
            }
        }
    }
}
