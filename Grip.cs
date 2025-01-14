using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grip : MonoBehaviour
{

   
    public GameObject energy;
    public int health = 300;
    InputAction moveAction, camoAction, atkAction;
    InputAction blockAction, tabAction;
    public int speed;
    Rigidbody rb;
    Animator anim;

    public bool isBlocking = false;

    public bool isRifleShot = false;
    public bool isGhost;
    Renderer renderer;
    public Material transMat;
    public Material opaqueMat;

    public GameObject sword;
    public GameObject shield;
    public GameObject rifle;

    bool isRifleEquipped;
    bool isSwordEquipped;
    bool isShieldEquipped;

    public ParticleSystem laserBurst;
    private List<ParticleCollisionEvent> collisionEvents;

    void SetupParticleCollision()
    {
        var collisionModule = laserBurst.collision;
        collisionModule.enabled = true;
        collisionModule.type = ParticleSystemCollisionType.World;
        collisionModule.mode = ParticleSystemCollisionMode.Collision3D;
        collisionModule.sendCollisionMessages = true;
        collisionModule.lifetimeLoss = 1.0f; // Particles die on collision
    }

    void OnParticleCollision(GameObject other)
    {
     
        {
            if (other.CompareTag("EnemyWeapon"))
            {
                Debug.Log("Successful hit");
              
                {
                    if(!isBlocking)
                    health -= 10;
                    
                      

           }
            }
      
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupParticleCollision();
        collisionEvents = new List<ParticleCollisionEvent>();
        moveAction = InputSystem.actions.FindAction("Move");
        camoAction = InputSystem.actions.FindAction("Camoflauge");
        atkAction = InputSystem.actions.FindAction("Attack");
        blockAction = InputSystem.actions.FindAction("Block");
        tabAction = InputSystem.actions.FindAction("Tab");
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGhost = false;
        isRifleEquipped = false;
        isSwordEquipped = true;
        isShieldEquipped = true;
        laserBurst.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        
   
        Debug.Log("Register Hit");

        if(other.TryGetComponent<alienCop>(out alienCop cop))
        {
            Debug.Log("Hit a cop");

            cop.health -= 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isBlocking);
        float spriteWidth = health / 100.0f;
        

        energy.transform.localScale = new Vector3(.2f * spriteWidth , .1f, 0);
       
        laserBurst.Stop();
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (GameEngine.needProcessSwapX)
        {
            if (moveValue.x == 0)
            {
                GameEngine.needProcessSwapX = false;
            }
            else
                moveValue.x *= -1;
        }
        if (GameEngine.needProcessSwapY)
        {
            if (moveValue.y == 0)
            {
                GameEngine.needProcessSwapY = false;
            }
            else
                moveValue.y *= -1;
        }

        if (Mathf.Abs(moveValue.x) > 0 || Mathf.Abs(moveValue.y) > 0)
        {
            anim.SetBool("isRun", true);
            //float   angle = Mathf.Atan2(moveValue.x, moveValue.y) * Mathf.Rad2Deg;


            //if (GameEngine.camIndex == 0)

            float timeDilation = Time.deltaTime * 100;
          //  Debug.Log(timeDilation);

            if (timeDilation > .4f)
                timeDilation = .4f;
            if(GameEngine.camFacingIndex == 0)
            { 
                rb.linearVelocity = new Vector3(-moveValue.x * speed * timeDilation, 0, -moveValue.y * speed * timeDilation);
            }
            else if(GameEngine.camFacingIndex == 1)
                rb.linearVelocity = new Vector3(moveValue.x * speed * timeDilation, 0, moveValue.y * speed * timeDilation);
            else if(GameEngine.camFacingIndex == 2)
            {
                rb.linearVelocity = new Vector3(moveValue.y * speed * timeDilation, 0, -moveValue.x * speed * timeDilation);
            }
            //  else if (GameEngine.camIndex == 1)
            // rb.linearVelocity = new Vector3(-moveValue.x * speed * Time.deltaTime * 100, 0, -moveValue.y * speed * Time.deltaTime * 100);

            // transform.rotation = Quaternion.Euler(0, angle, 0);

            //  transform.position += transform.forward * Time.deltaTime * 3.0f;

        }
        else
        {
            anim.SetBool("isRun", false);
        }

        if (camoAction.triggered)
        {
            if (isGhost)
            {
                isGhost = false;
                renderer.material = opaqueMat;
            }
            else
            {
                isGhost = true;
                renderer.material = transMat;
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .6f && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "rifleShoot")

        {
            if (!isRifleShot)
            {
                laserBurst.Play();
                AudioEngine.PlayALaserBeamSound();
                isRifleShot = true;
            }

        }
        if (anim.GetCurrentAnimatorClipInfo(0).Length > 0)
            if ( anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "rifleShoot")
            isRifleShot = false;
            if (atkAction.triggered && isRifleEquipped)
        {

            anim.SetTrigger("isRifle");



        }
        if (isSwordEquipped && atkAction.triggered)
        {
            anim.SetTrigger("isSwordAtk");
        }
        if (anim.GetCurrentAnimatorClipInfo(0).Length > 0)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > .3f && anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "swordAttack")
            {
                sword.GetComponent<CapsuleCollider>().enabled = true;

            }
            else
                sword.GetComponent<CapsuleCollider>().enabled = false;
        }
            if (isShieldEquipped && blockAction.IsPressed())
        {
            anim.speed = 4;
            anim.SetBool("isShieldBlock", true);
            isBlocking = true;
            if (anim.GetCurrentAnimatorClipInfo(0).Length > 0)
                if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "ShieldBlock" && anim.GetCurrentAnimatorStateInfo(0).normalizedTime>.8f)
            {
                Debug.Log("Setting block to true");
                anim.speed = 0; 
            }

        }
        else
        {
            Debug.Log("Setting block to false");
            anim.SetBool("isShieldBlock", false);
            anim.speed = 1;
            isBlocking = false;
        }
        if (tabAction.triggered)
        {

            if (isSwordEquipped && isShieldEquipped)
            {
                isRifleEquipped = true;
                isSwordEquipped = false;
                isShieldEquipped = false;
                rifle.SetActive(true);
                sword.SetActive(false);
                shield.SetActive(false);
            }
            else if(isRifleEquipped)
            {
                isRifleEquipped = false;
                isSwordEquipped = true;
                isShieldEquipped = true;
                rifle.SetActive(false);
                sword.SetActive(true);
                shield.SetActive(true);
            }
        }
        
        
    }
}
