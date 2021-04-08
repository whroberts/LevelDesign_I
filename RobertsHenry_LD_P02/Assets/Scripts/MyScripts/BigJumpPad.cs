using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class BigJumpPad : MonoBehaviour
{

    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            _anim.SetBool("Held", true);
            StartCoroutine(BigJump(playerController));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            _anim.SetBool("Held", false);
            StartCoroutine("SetBool");
        }
    }

    IEnumerator BigJump(PlayerController script)
    {
        script.jumpTakeOffSpeed = 12;
        yield return new WaitForSeconds(1f);
        script.jumpTakeOffSpeed = 7;


    }

    IEnumerator SetBool()
    {
        _anim.SetBool("Jumped", true);
        yield return new WaitForSeconds(0.3f);
        _anim.SetBool("Jumped", false);
    }
}
