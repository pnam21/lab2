using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _particleSystem.Play();
        }
        else { _particleSystem.Stop(); }
    }
}

