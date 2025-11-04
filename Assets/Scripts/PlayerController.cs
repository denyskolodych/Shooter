using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.0f;
    public Animator anim;
    private Rigidbody playerRg;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRg = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forvard = Input.GetKey(KeyCode.W);
        bool run = Input.GetKey(KeyCode.LeftShift);
        if (forvard && run)
        {

            speed = 4.0f;
            // transform.Translate(Vector3.forward * speed * Time.deltaTime);
            playerRg.MovePosition(transform.position + transform.forward * speed*2 * Time.deltaTime);

            
        }
        else if (forvard)
        {

            speed = 2.0f;
            playerRg.MovePosition(transform.position + transform.forward * speed*2 * Time.deltaTime);

        }

        else if (Input.GetKey(KeyCode.S) && run)
        {
            speed = -4.0f;
            playerRg.MovePosition(transform.position + transform.forward * speed*2 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            speed = -2.0f;
            playerRg.MovePosition(transform.position + transform.forward * speed*2 * Time.deltaTime);
        }
        else
        {
            speed = 0.0f;
        }

         anim.SetBool("IsAim", Input.GetMouseButton(1)); // утримуєш ПКМ → true
        anim.SetFloat("Speed", speed);
    }
}
