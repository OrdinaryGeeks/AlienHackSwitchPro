using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class alienCop : MonoBehaviour
{

    public GameObject energy;
    public int health;
    public ParticleSystem laserBurst;
    Animator anim;
    public GameObject target;
    public float aimTime;
    public bool isRifle, isSword;

    public bool isRifleShot;

    bool isRifleEquipped;
    bool isSwordEquipped;
    bool isShieldEquipped;

    private List<ParticleCollisionEvent> collisionEvents;
    public GameObject sword, shield, rifle;

    public int gameState;

   



    void SetupParticleCollision()
    {
        var collisionModule = laserBurst.collision;
        collisionModule.enabled = true;
        collisionModule.type = ParticleSystemCollisionType.World;
        collisionModule.mode = ParticleSystemCollisionMode.Collision3D;
        collisionModule.sendCollisionMessages = true;
        collisionModule.lifetimeLoss = 1.0f; // Particles die on collision
    }

    private void OnTriggerEnter(Collider other)
    {



        if (other.TryGetComponent<Grip>(out Grip grip))
        {
            

            grip.health -= 10;
        }
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupParticleCollision();

        collisionEvents = new List<ParticleCollisionEvent>();
        isRifleShot = false;
        gameState = 0;
       anim = GetComponent<Animator>();
        aimTime = 0;
        health = 30;
        laserBurst.Stop();
        isRifle = false;
        isSword = false;

        isRifleEquipped = true;    
        isSwordEquipped = false;
        isShieldEquipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        float spriteWidth = health / 100.0f;


        energy.transform.localScale = new Vector3(.2f * spriteWidth, .1f, 0);

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        Vector3 look2Face = target.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(look2Face);


        if (gameState == 1)
        {


            aimTime += Time.deltaTime;

            if (aimTime > 3)
            {

                if (isRifleEquipped)
                {
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
                            DecisionTree();
                            isRifleShot = false;
                        }

                    }
                    if (anim.GetCurrentAnimatorClipInfo(0).Length >0)
                    if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "rifleShoot")
                        isRifleShot = false;
                }
                else if ((isSwordEquipped))
                {
                    if (anim.GetCurrentAnimatorClipInfo(0).Length > 0)
                    {
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .3f && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "swordAttack")
                        {
                            sword.GetComponent<CapsuleCollider>().enabled = true;

                        }
                        else if(sword.GetComponent<CapsuleCollider>().enabled == true)
                            sword.GetComponent<CapsuleCollider>().enabled = false;
                    }
                    if (isSword == false)
                    {

                        if (Vector3.Distance(transform.position, target.transform.position) < 1)
                        {
                            anim.SetTrigger("isSwordAtk");

                            isSword = true;
                        }
                        else
                        {
                            transform.position += transform.forward * 1;
                        }
                    }

                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "swordAttack")

                    {
                      
                        //laserBurst.Play();
                        aimTime = 0;
                        aimTime = 0;
                        isSword = false;

                        DecisionTree();

                    }
                }
            }
        }

    }
    public void DecisionTree()
    {
        int nextDecision = Random.Range(0, 7);

        if (nextDecision % 2 == 0)
        {
            isRifleEquipped = true;
            isSwordEquipped = false;
            isShieldEquipped = false;
            rifle.SetActive(true);
            sword.SetActive(false);
            shield.SetActive(false);

        }
        else
        {
            isRifleEquipped = false; isSwordEquipped = true; isShieldEquipped = true;
            rifle.SetActive(false);
            sword.SetActive(true);
            shield.SetActive(true);
        }
    }
}
