using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public CharacterController controller;
    FMOD.Studio.EventInstance PlayFootSteps;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float floatSpeed = -3f;
    public float jumpHeight = 3f;
    public bool playerLocked;
    public float footStepSpeed = 1f;
  

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    bool isGrounded;
    string horizontal = "Horizontal";
    string vertical = "Vertical";
    float timer;

    Vector3 velocity;

    private void Awake()
    {
        instance = this;
       // PlayFootSteps = FMODUnity.RuntimeManager.CreateInstance("event:/Player/Footsteps");
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Debug.Log(isGrounded);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(isGrounded)
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                timer += Time.deltaTime;
                if (timer > footStepSpeed)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Footsteps", GetComponent<Transform>().position);
                    timer = 0f;
                    footStepSpeed = Random.Range(0.45f, 0.65f);

                }

            }  
        }


        float x = Input.GetAxis(horizontal);
        float z = Input.GetAxis(vertical);
       

        Vector3 move = transform.right * x + transform.forward * z;

        if (!playerLocked)
        {
            controller.Move(move * speed * Time.deltaTime);

        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    public void Float()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * floatSpeed);
        gravity = 0;
    }

    public void Fall()
    {
        gravity = -9.81f;
    }

    public void Reverse()
    {
        horizontal = "Vertical";
        vertical = "Horizontal";
        //
    }

    public void Normal()
    {
        horizontal = "Horizontal";
        vertical = "Vertical";
    }

    private IEnumerator Walking()
    {
        // FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Footsteps", GetComponent<Transform>().position);
        yield return new WaitForSeconds(3);
        Debug.Log("Walking");

    }

}
