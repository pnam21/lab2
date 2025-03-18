using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            particleSystem.Play();
        }
        else { particleSystem.Stop(); }
    }
}

