using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float TorqueAmount = 1f;
    [SerializeField] ParticleSystem SnowEffect;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 10f;


    Rigidbody2D rb2d;
    SurfaceEffector2D SurfaceEffector2D;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SurfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Rotation();
            RespondToBoost();
        }


    }

    public void DisableControls()
    {
        canMove = false;

    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SurfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            SurfaceEffector2D.speed = normalSpeed;
        }
        
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(TorqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-TorqueAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            SnowEffect.Play();
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            SnowEffect.Stop();
        }
    }
}
