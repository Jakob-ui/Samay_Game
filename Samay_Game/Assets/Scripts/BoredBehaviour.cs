using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredBehaviour : StateMachineBehaviour
{
    [Header("Timing")]
    [SerializeField]
    private float _timeUntilBored;

    [SerializeField]
    private int _numberOfBoredAnimations;

    [Header("Animation")]
    private bool _isBored;
    private float _idleTime;
    private int _boredAnimation;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_isBored == false)
        {
            _idleTime += Time.deltaTime;

            if (_idleTime >= _timeUntilBored && stateInfo.normalizedTime % 1 < 0.02f)
            {
                _isBored = true;
                _boredAnimation = Random.Range(1, _numberOfBoredAnimations + 1);
                _boredAnimation = _boredAnimation * 2 - 1;

                animator.SetFloat("BoredAnimation", _boredAnimation - 1);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle();
        }

        animator.SetFloat("BoredAnimation", _boredAnimation, 0.2f, Time.deltaTime);

    }

    private void ResetIdle()
    {
        if (_isBored)
        {
            _boredAnimation--;
        }
        _isBored = false;
        _idleTime = 0;

    }
}
