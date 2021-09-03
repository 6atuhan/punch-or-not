using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    Animator animator;
    move _move;
    void Start()
    {
        animator = GetComponent<Animator>();
        _move = GameObject.Find("Karakter").GetComponent<move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_move.çarptý==true)
        { animator.SetTrigger("bitiþ");

        }
    }
}
