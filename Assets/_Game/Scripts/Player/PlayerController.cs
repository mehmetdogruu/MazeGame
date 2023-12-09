using UnityEngine;
using System;

public class PlayerController : MonoBehaviour,IInteractor
{
    public PlayerCollisionController Collision { get; private set;}
    public MovementController Movement { get; private set; }
    public PlayerItems Items { get; private set; }
    public PlayerAnimationController Animation { get; private set; }

    public static event Action OnCharacterFailed;
    public static event Action OnCharacterWin;

    private void Awake()
    {
        Collision = GetComponentInChildren<PlayerCollisionController>();
        Movement = GetComponent<MovementController>();
        Items = GetComponent<PlayerItems>();
        Animation = GetComponentInChildren<PlayerAnimationController>();
    }
}
