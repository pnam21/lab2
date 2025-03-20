using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float normalSpeed;
    [SerializeField] bool canPlay;
    private Rigidbody2D _rb2D;
    private SurfaceEffector2D _surfaceEffector2D;

    private void Start()
    {
        canPlay = true;
        _rb2D = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = GameObject.FindWithTag("Ground").GetComponent<SurfaceEffector2D>();

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
            _surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _surfaceEffector2D.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2D.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2D.AddTorque(-torqueAmount);
        }
    }
}
