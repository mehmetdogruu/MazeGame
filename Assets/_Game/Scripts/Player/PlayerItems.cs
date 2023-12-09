using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private bool _hasChestKey = false;
    [SerializeField] private GameObject _keySprite;
    public bool HasChestKey => _hasChestKey;
    public GameObject KeySprite => _keySprite;

    public void ChestKeyInteractionHandle()
    {
        _hasChestKey = true;
    }
}
