using UnityEngine;
using UnityEngine.InputSystem;

public class AlienMark : MonoBehaviour
{

    InputAction moveAction;
    InputAction turboAction; //Yes it is marked as teleport but im getting tired
    Animator anim;
    Rigidbody rb;
    public int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        turboAction = InputSystem.actions.FindAction("Teleport");
        anim = GetComponent<Animator>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < .2))
            transform.position = new Vector3(transform.position.x, .2f, transform.position.z);
        {
            
        }
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (turboAction.triggered)
        {
            if (speed == 60)
                speed = 10;
            else if (speed == 10)
                speed = 60;
        }
        if (Mathf.Abs(moveValue.x) > 0 || Mathf.Abs(moveValue.y) > 0)
        {
            anim.SetBool("isRun", true);
            //float   angle = Mathf.Atan2(moveValue.x, moveValue.y) * Mathf.Rad2Deg;


            //if (GameEngine.camIndex == 0)

            float timeDilation = Time.deltaTime * 100;

            if (timeDilation > .4f)
                timeDilation = .4f;
            if (GameEngine.camFacingIndex == 0)
            {

                rb.linearVelocity = new Vector3(-moveValue.x * speed * timeDilation, 0, -moveValue.y * speed * timeDilation);
            }
            else if (GameEngine.camFacingIndex == 1)
                rb.linearVelocity = new Vector3(moveValue.x * speed * timeDilation, 0, moveValue.y * speed * timeDilation);
            else if (GameEngine.camFacingIndex == 2)
            {
                rb.linearVelocity = new Vector3(moveValue.y * speed * timeDilation, 0, -moveValue.x * speed * timeDilation);
            }

        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }
}
