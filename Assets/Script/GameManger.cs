using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 15f;
    [SerializeField] private float boostSpeed = 45f;
    [SerializeField] private float normalSpeed = 25f;
    [SerializeField] bool canPlay;
    private Rigidbody2D RB2D;
    private SurfaceEffector2D surfaceEffector2D;

    private void Start()
    {
        canPlay = true;
        RB2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = GameObject.FindWithTag("Ground").GetComponent<SurfaceEffector2D>();

    }

    private void Update()
    {
        if (canPlay)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableInput()
    {
        canPlay = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RB2D.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RB2D.AddTorque(-torqueAmount);
        }
    }
}
