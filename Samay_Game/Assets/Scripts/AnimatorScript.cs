using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{

    [SerializeField] Animator animator;

    void Update(){
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.SetBool("Sprint", true);
            }
            else animator.SetBool("Sprint", false);
        }
        else animator.SetBool("Walk", false);

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
            }
            else animator.SetBool("Jump", false);
    }
}
