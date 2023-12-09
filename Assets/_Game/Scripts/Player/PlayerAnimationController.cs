using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private int horizontal = Animator.StringToHash("Horizontal");
    private int vertical = Animator.StringToHash("Vertical");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerController.OnCharacterFailed += TriggerStopAnimation;
        PlayerController.OnCharacterWin += TriggerStopAnimation;
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        float snappedHorizontal;
        float snappedVertical;
        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < .55f)
        {
            snappedHorizontal = .5f;
        }
        else if (horizontalMovement > .55f)
        {
            snappedHorizontal = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -.55f)
        {
            snappedHorizontal = -.5f;
        }
        else if (horizontalMovement < -.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion
        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < .55f)
        {
            snappedVertical = .5f;
        }
        else if (verticalMovement > .55f)
        {
            snappedVertical = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -.55f)
        {
            snappedVertical = -.5f;
        }
        else if (verticalMovement < -.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }
        #endregion

        _animator.SetFloat(horizontal, snappedHorizontal, .1f, Time.deltaTime);
        _animator.SetFloat(vertical, snappedVertical, .1f, Time.deltaTime);
    }
    private void TriggerStopAnimation()
    {
        horizontal = 0;
        vertical = 0;
    }

    private void OnDisable()
    {
        PlayerController.OnCharacterFailed -= TriggerStopAnimation;
        PlayerController.OnCharacterWin -= TriggerStopAnimation;
    }
}
