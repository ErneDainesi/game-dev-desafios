using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    void Update()
    {
        bool forward = Input.GetKeyDown(KeyCode.W);
        bool right = Input.GetKeyDown(KeyCode.D);
        bool back = Input.GetKeyDown(KeyCode.S);
        bool left = Input.GetKeyDown(KeyCode.A);
        if (forward) playerAnimator.SetTrigger("Run");
        if (right) playerAnimator.SetTrigger("Right");
        if (back) playerAnimator.SetTrigger("Backwards");
        if (left) playerAnimator.SetTrigger("Left");
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (!IsAnimation("Idle")) playerAnimator.SetTrigger("Idle");
        }   
    }
    
    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }
}
