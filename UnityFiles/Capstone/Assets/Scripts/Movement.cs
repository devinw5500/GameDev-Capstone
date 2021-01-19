using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    bool is2D = true;
    bool isgrounded;
    public Camera Cam2d;
    public Camera Cam3d;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cam2d.enabled = true;
        Cam3d.enabled = false;
        if (SceneManager.GetActiveScene().name.Equals("Four"))
        {
            Cam2d.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
            //Cam2d.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        }

    }
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name.Contains("Floor"))
        {
            isgrounded = true;
        }
    }
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name.Contains("Floor"))
        {
            isgrounded = false;
        }
    }
    void Update()
    {
        
        //hold down shift to go 3d
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Cam2d.enabled = !Cam2d.enabled;
            //Cam3d.enabled = !Cam3d.enabled;
            Cam2d.enabled = false;
            Cam3d.enabled = true;
            is2D = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Cam2d.enabled = true;
            Cam3d.enabled = false;
            is2D = true;
        }
        /*
        if (Cam2d.enabled)
        {
            is2D = true;
        }
        else
        {
            is2D = false;
        }
        */
        if (is2D)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3();
            movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

            //Debug.Log(isgrounded);
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * speed * 4;
            }
            if (isgrounded)
            {
                rb.AddForce(movement * speed);
            }
            else
            {
                rb.AddForce(movement * (speed * .5f));
            }
            
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3();
            movement = new Vector3(moveVertical, 0.0f, -moveHorizontal);

            //Debug.Log(isgrounded);
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * speed * 4;
            }

            rb.AddForce(movement * speed);
        }

        if (SceneManager.GetActiveScene().name.Equals("Three"))
        {
            if (Time.realtimeSinceStartup > 45)
            {
                Debug.Log("Zoom time");
                speed = 15;
            }
        }
    }


}
