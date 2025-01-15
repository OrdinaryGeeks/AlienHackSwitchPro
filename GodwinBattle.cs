using Unity.VisualScripting;
using UnityEngine;

public class GodwinBattle : MonoBehaviour
{

    public GameObject Alpha1, Alpha2, Alpha3, Finch;
    public GameObject target;
    public float aimTime;
    public bool isRifle = false;
    Animator anim;
    public bool isRifleShot = false;
    public ParticleSystem laserBurst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Alpha1.GetComponent<alienCop>().health > 0)
            target = Alpha1;
        else if (Alpha2.GetComponent<alienCop>().health > 0)
            target = Alpha2;
        else if (Alpha3.GetComponent<alienCop>().health > 0)
            target = Alpha3;
        else if (Finch.GetComponent<Finch>().health > 0)
            target = Finch;
        else
            return;

        Vector3 turnToFace = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;

        transform.rotation = Quaternion.LookRotation(turnToFace, Vector3.up);

        if (Vector3.Distance(target.transform.position, transform.position) > 2)
            transform.position += transform.forward * .003f * Time.deltaTime;

        aimTime += Time.deltaTime;
        if (aimTime > 3)
            if (isRifle == false)
            {
                anim.SetTrigger("isRifle");

                isRifle = true;
            }
        if (anim.GetCurrentAnimatorClipInfo(0).Length > 0)
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .5f && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "rifleShoot")

            {
                if (!isRifleShot)
                {
                    laserBurst.Play();
                    aimTime = 0;
                    aimTime = 0;
                    isRifle = false;
                    AudioEngine.PlayALaserBeamSound();
                   
                    isRifleShot = false;
                }

            }
        if (anim.GetCurrentAnimatorClipInfo(0).Length > 0)
            if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "rifleShoot")
                isRifleShot = false;
    }

}

