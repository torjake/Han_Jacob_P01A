using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseSCrit : MonoBehaviour
{
    public class Player : MonoBehaviour
    {
        [SerializeField] int _maxHealth = 3;
        int _currentHealth;
        public bool canTakeDamage = true;
        //
        public int _currentTreasure = 0;
        //public Text TreasureScore;

        TankController _tankController;
        //

        private void Awake()
        {
            _tankController = GetComponent<TankController>();
        }

        private void Start()
        {
            _currentHealth = _maxHealth;
        }
        //
        private void Update()
        {
            // TreasureScore.text = _currentTreasure.ToString(); fix
        }
        //
        public void IncreaseTreasure(int amount)
        {
            _currentTreasure += amount;
            print(_currentTreasure);
        }
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

}
