using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerObserver : MonoBehaviour
{
    public delegate void PlayerDamaged(int amount);

    public PlayerDamaged _playerDamaged;

    public TankController _tankController;
    public PlayerHealthBarScript _playerHealthBar;

    private void Start()
    {
        _playerDamaged = _tankController.DecreaseHealth;
        //_playerDamaged = _playerHealthBar.SetHealth;
        //
        
    }
}
