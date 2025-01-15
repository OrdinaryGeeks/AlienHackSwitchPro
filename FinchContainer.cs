using UnityEngine;

public class FinchContainer : MonoBehaviour
{

    public GameObject plane1, plane2, plane3, plane4, plane5, plane6, plane7, plane8, plane9;
    public Material offMaterial;
    public Material onMaterial;

    public  bool[] isPlanes;
    public  bool[] isPlanesChange;
    // Start is called
    //
    // once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerStay(Collider other)
    {



        if (other.TryGetComponent<Grip>(out Grip grip))
        {


            grip.health -= 1;
        }
    }

    public   void AllFalse()
    {
        {
            plane1.GetComponent<BoxCollider>().enabled = false;
            plane1.GetComponent<MeshRenderer>().material = offMaterial;

        }
        //if (i == 1)
        {
            plane2.GetComponent<BoxCollider>().enabled = false;
            plane2.GetComponent<MeshRenderer>().material = offMaterial;
        }
        // if (i == 2)
        {
            plane3.GetComponent<BoxCollider>().enabled = false;
            plane3.GetComponent<MeshRenderer>().material = offMaterial;
        }
        //if (i == 3)
        {
            plane4.GetComponent<BoxCollider>().enabled = false;
            plane4.GetComponent<MeshRenderer>().material = offMaterial;
        }
        //if (i == 4)
        {
            plane5.GetComponent<BoxCollider>().enabled = false;
            plane5.GetComponent<MeshRenderer>().material = offMaterial;
        }
        //if (i == 5)
        {
            plane6.GetComponent<BoxCollider>().enabled = false;
            plane6.GetComponent<MeshRenderer>().material = offMaterial;
        }
        //  if (i == 6)
        {
            plane7.GetComponent<BoxCollider>().enabled = false;
            plane7.GetComponent<MeshRenderer>().material = offMaterial;
        }
        //    if (i == 7)
        {
            plane8.GetComponent<BoxCollider>().enabled = false;
            plane8.GetComponent<MeshRenderer>().material = offMaterial;
        }

        {
            plane9.GetComponent<BoxCollider>().enabled = false;
            plane9.GetComponent<MeshRenderer>().material = offMaterial;
        }
    }

    void Start()
    {
        plane1.GetComponent<MeshRenderer>().material = offMaterial;
        plane2.GetComponent<MeshRenderer>().material = offMaterial;
        plane3.GetComponent<MeshRenderer>().material = offMaterial;
        plane4.GetComponent<MeshRenderer>().material = offMaterial;
        plane5.GetComponent<MeshRenderer>().material = offMaterial;
        plane6.GetComponent<MeshRenderer>().material = offMaterial;
        plane7.GetComponent<MeshRenderer>().material = offMaterial;
        plane8.GetComponent<MeshRenderer>().material = offMaterial;
        plane9.GetComponent<MeshRenderer>().material = offMaterial;

        plane1.GetComponent<BoxCollider>().enabled = false;
        plane2.GetComponent<BoxCollider>().enabled = false;
        plane3.GetComponent<BoxCollider>().enabled = false;
        plane4.GetComponent<BoxCollider>().enabled = false;
        plane5.GetComponent<BoxCollider>().enabled = false;
        plane6.GetComponent<BoxCollider>().enabled = false;
        plane7.GetComponent<BoxCollider>().enabled = false;
        plane8.GetComponent<BoxCollider>().enabled = false;
        plane9.GetComponent<BoxCollider>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
