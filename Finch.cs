using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Finch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 100;
    public GameObject Grip;
    public GameObject FinchContainerB;
    public GameObject plane1, plane2, plane3, plane4, plane5, plane6, plane7, plane8, plane9;
    public bool isPlane1, isPlane2, isPlane3, isPlane4, isPlane5, isPlane6,  isPlane7, isPlane8, isPlane9;

    public bool[] isPlanes;
    public bool[] isPlanesChange;
    public Material offMaterial;
    public Material onMaterial;
    float decisionTimer;
    int count;
    public GameObject energy;
    public Animator anim;

    public Vector3 destination;
    public int gameState = 0;
    void Start()
    {

        anim = GetComponent<Animator>();
        isPlanes = new bool[9];
        isPlanesChange = new bool[9];


    }
    void OnParticleCollision(GameObject other)
    {


        if (other.CompareTag("PlayerWeapon"))
        {
            {
                health -= 10;

            }
        }

    }
    private void OnTriggerStay (Collider other)
    {



        if (other.TryGetComponent<Grip>(out Grip grip))
        {


            grip.health -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float spriteWidth = health / 100.0f;


        energy.transform.localScale = new Vector3(.2f * spriteWidth, .1f, 0);

        // if()
        decisionTimer += Time.deltaTime;
        if (gameState == 1)
        {
            Vector3 turnToFace = destination - transform.position;
            transform.position += turnToFace * Time.deltaTime * 2 ;
            transform.rotation = Quaternion.LookRotation(turnToFace, Vector3.up);

            if (Vector3.Distance(transform.position, destination) < 2)
            {
                gameState = 0;
                decisionTimer = 0;
            }
        }
        else if(gameState == 2)
        {

            Vector3 turnToFace = Grip.transform.position - transform.position;
            //transform.position += turnToFace * Time.deltaTime * 2;
            transform.rotation = Quaternion.LookRotation(turnToFace, Vector3.up);
            if (decisionTimer > 2)
            {
                decisionTimer = 0; gameState = 0; FinchContainerB.GetComponent<FinchContainer>().AllFalse();
            }
           // else if (decisionTimer > 2.5)
            {
               
            }
            
          
        }
        else if(decisionTimer >2 && gameState == 0)
        {
          

            int move = Random.Range(0,6);

            if(move == 0 || move == 1)
            {
               FinchContainerB.GetComponentInParent<FinchContainer>().AllFalse();
            
                {
                    gameState = 1;
                    int squareIndex = Random.Range(0, 9);

                    if (squareIndex == 0)
                        destination = new Vector3(plane1.transform.position.x, transform.position.y, plane1.transform.position.z);

                    if (squareIndex == 1)
                        destination = new Vector3(plane2.transform.position.x, transform.position.y, plane2.transform.position.z);
                    if (squareIndex == 2)
                        destination = new Vector3(plane3.transform.position.x, transform.position.y, plane3.transform.position.z);
                    if (squareIndex == 3)
                        destination = new Vector3(plane4.transform.position.x, transform.position.y, plane4.transform.position.z);
                    if (squareIndex == 4)
                        destination = new Vector3(plane5.transform.position.x, transform.position.y, plane5.transform.position.z);
                    if (squareIndex == 5)
                        destination = new Vector3(plane6.transform.position.x, transform.position.y, plane6.transform.position.z);
                    if (squareIndex == 6)
                        destination = new Vector3(plane7.transform.position.x, transform.position.y, plane7.transform.position.z);
                    if (squareIndex == 7)
                        destination = new Vector3(plane8.transform.position.x, transform.position.y, plane8.transform.position.z);
                    if (squareIndex == 8)
                        destination = new Vector3(plane9.transform.position.x, transform.position.y, plane9.transform.position.z);

                }



            }
            else 
            {
                gameState = 2;
                decisionTimer = 0;
               // decisionTimer = 0;

                for (int i = 0; i < 9; i++)
                    isPlanesChange[i] = isPlanes[i];

                count = Random.Range(0, 7);

                for (int i = 0; i < 9; i++)
                    isPlanes[i] = false;

                for (int i = 0; i < count; i++)
                {
                    int turn = Random.Range(0, 9);
                    isPlanes[turn] = true;

                }

                for (int i = 0; i < 9; i++)
                {
                    if (isPlanesChange[i] == true && isPlanes[i] == false)
                    {
                       
                        if (i == 0)
                        {
                            FinchContainerB.GetComponent<FinchContainer>(). plane1.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane1.GetComponent<MeshRenderer>().material = offMaterial;

                        }
                        if (i == 1)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane2.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane2.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                        if (i == 2)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane3.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane3.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                        if (i == 3)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane4.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane4.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                        if (i == 4)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane5.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane5.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                        if (i == 5)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane6.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane6.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                        if (i == 6)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane7.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane7.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                        if (i == 7)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane8.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane8.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                        if (i == 8)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane9.GetComponent<BoxCollider>().enabled = false;
                             FinchContainerB.GetComponent<FinchContainer>().plane9.GetComponent<MeshRenderer>().material = offMaterial;
                        }
                    }

                    if (isPlanesChange[i] == false && isPlanes[i] == true)
                    {
                        if (i == 0)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane1.GetComponent<BoxCollider>().enabled = true;
                             FinchContainerB.GetComponent<FinchContainer>().plane1.GetComponent<MeshRenderer>().material = onMaterial;

                        }
                        if (i == 1)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane2.GetComponent<BoxCollider>().enabled = true;
                             FinchContainerB.GetComponent<FinchContainer>().plane2.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                        if (i == 2)
                        {
                             FinchContainerB.GetComponent<FinchContainer>().plane3.GetComponent<BoxCollider>().enabled = true;
                             FinchContainerB.GetComponent<FinchContainer>().plane3.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                        if (i == 3)
                        {
                            FinchContainerB.GetComponent<FinchContainer>().plane4.GetComponent<BoxCollider>().enabled = true;
                            FinchContainerB.GetComponent<FinchContainer>().plane4.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                        if (i == 4)
                        {
                            FinchContainerB.GetComponent<FinchContainer>().plane5.GetComponent<BoxCollider>().enabled = true;
                            FinchContainerB.GetComponent<FinchContainer>().plane5.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                        if (i == 5)
                        {
                            FinchContainerB.GetComponent<FinchContainer>().plane6.GetComponent<BoxCollider>().enabled = true;
                            FinchContainerB.GetComponent<FinchContainer>().plane6.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                        if (i == 6)
                        {
                            FinchContainerB.GetComponent<FinchContainer>().plane7.GetComponent<BoxCollider>().enabled = true;
                            FinchContainerB.GetComponent<FinchContainer>().plane7.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                        if (i == 7)
                        {
                            FinchContainerB.GetComponent<FinchContainer>().plane8.GetComponent<BoxCollider>().enabled = true;
                            FinchContainerB.GetComponent<FinchContainer>().plane8.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                        if (i == 8)
                        {
                            FinchContainerB.GetComponent<FinchContainer>().plane9.GetComponent<BoxCollider>().enabled = true;
                            FinchContainerB.GetComponent<FinchContainer>().plane9.GetComponent<MeshRenderer>().material = onMaterial;
                        }
                    }
                }
            }
                

            
        }
        if(health <= 0)
            this.gameObject.SetActive(false);


        
    }
}
