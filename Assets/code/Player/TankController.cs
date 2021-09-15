using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{
    [SerializeField] public float _moveSpeed = .25f;
    [SerializeField] float _turnSpeed = 2f;

    Rigidbody _rb = null;

    public GameObject simpleBullet;
    public Transform firepoint;
    //
    [SerializeField] int _maxHealth = 3;
    [SerializeField] int _currentHealth;
    public bool canTakeDamage = true;
    //
    public Text playerHealth;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(simpleBullet, firepoint.position, this.transform.rotation);
        //
        playerHealth.text = _currentHealth.ToString();
    }

    public void MoveTank()
    {
        // calculate the move amount
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _moveSpeed;
        // create a vector from amount and direction
        Vector3 moveOffset = transform.right * moveAmountThisFrame;
        // apply vector to the rigidbody
        _rb.MovePosition(_rb.position + moveOffset);
        // technically adjusting vector is more accurate! (but more complex)
    }

    public void TurnTank()
    {
        // calculate the turn amount
        float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
        // create a Quaternion from amount and direction (x,y,z)
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // apply quaternion to the rigidbody
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }
    //
    public void IncreasHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's Health: " + _currentHealth);
    }
    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
        gameObject.SetActive(false);
        //play particles
        //play sounds
    }
}
