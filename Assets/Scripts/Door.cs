using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //A changer quand le player récupère la clé
    public bool playerHasKey = false;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerHasKey)
        {
            _animator.SetTrigger("Open");
        }
    }
}
