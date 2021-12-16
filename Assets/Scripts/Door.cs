using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("merdes");
        if (other.CompareTag("Player") && other.gameObject.GetComponent<Player>().hasKey)
        {
            _animator.SetTrigger("Open");
            other.gameObject.GetComponent<Player>().hasKey = false;
            Destroy(this);  
        }
    }
}
