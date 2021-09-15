using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBaseClass : MonoBehaviour
{
    public GameObject Player;
    public GameObject leftWallShootPoint;
    public GameObject rightWallShootPoint;
    public GameObject leftMovepos;
    public GameObject rightMovepos;
    int chooseLeftOrRight;
    public GameObject FirePoint;
    //
    float moveCoolDown;
    bool pickNewMove = true;

    public bool losMove;
    public bool NlosShoot;
    public bool NlosMove;
    //
    public Text bossHealth;
    //
    [SerializeField] int _maxHealth = 3;
    [SerializeField]
    int _currentHealth;
    //
    public GameObject lilBullet;
    public GameObject Beam;
    void Awake() 
    {
        _currentHealth = _maxHealth;
        print("herdgfe");
    }
    void Update() 
    {
        bossHealth.text = _currentHealth.ToString();
        //
        if (moveCoolDown <= 0) 
        {
            pickNewMove = true;
        }
        if (moveCoolDown > 0)
            pickNewMove = false;
        if (moveCoolDown > 0)
            moveCoolDown -= Time.deltaTime;

        if (pickNewMove) 
        {
            Decider();
        }
        if (!pickNewMove) 
        {

            if (losMove == true)
                CanSeeMove();
            if (NlosShoot == true)
                ShootLittleShits();
            if (NlosMove == true)
                CantSeeMove();
        }
        //
    }
    void Decider() 
    {
        //
        Vector3 targetDirection = Player.transform.position - this.transform.position;
        Vector3 newdirection = Vector3.RotateTowards(transform.forward, targetDirection, 100f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newdirection);
        //
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);

        if (hit.transform.tag == "Player") 
        {   
                losMove = true;
                moveCoolDown = 3f;
            //Instantiate(simpleBullet, firepoint.position, this.transform.rotation);
            Instantiate(Beam, FirePoint.transform.position, FirePoint.transform.rotation);
        }
        if (hit.transform.tag != "Player") 
        {
            losMove = false;
            moveCoolDown = 0f;
            //print("wall");
            if (Random.Range(0, 2) == 1)
            {
                NlosShoot = true;
                moveCoolDown = 3f;
            }
            else
            {
                chooseLeftOrRight = (Random.Range(0, 2));
                NlosMove = true;
                moveCoolDown = 3f;
            }
        }
    }

    void CanSeeMove() 
    {
        Vector3 targetDirection = Player.transform.position - this.transform.position;
        Vector3 newdirection = Vector3.RotateTowards(transform.forward, targetDirection, 0.003f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newdirection);
        //
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.035f);
        
    }
    void ShootLittleShits() 
    {
        print("here");
        if (Random.Range(0, 2) == 1)
        {
            Vector3 targetDirection = leftWallShootPoint.transform.position - this.transform.position;
            Vector3 newdirection = Vector3.RotateTowards(transform.forward, targetDirection, 100f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newdirection);
            //
            //Instantiate(simpleBullet, firepoint.position, this.transform.rotation);
            Instantiate(lilBullet, FirePoint.transform.position, this.transform.rotation);
            NlosShoot = false;
            pickNewMove = true;
        }
        else 
        {
            Vector3 targetDirection = rightWallShootPoint.transform.position - this.transform.position;
            Vector3 newdirection = Vector3.RotateTowards(transform.forward, targetDirection, 100f, 0.0f);
            transform.rotation = Quaternion.LookRotation(newdirection);
            //
            //Instantiate(simpleBullet, firepoint.position, this.transform.rotation);
            Instantiate(lilBullet, FirePoint.transform.position, this.transform.rotation);
            NlosShoot = false;
            pickNewMove = true;
        }
    }
    void CantSeeMove() 
    {
        if(chooseLeftOrRight == 0)
            transform.position = Vector3.MoveTowards(transform.position, rightMovepos.transform.position, 30f * Time.deltaTime);

        if(chooseLeftOrRight == 1)
            transform.position = Vector3.MoveTowards(transform.position, leftMovepos.transform.position, 30f * Time.deltaTime);
        //
        if (transform.position == leftMovepos.transform.position || transform.position == rightMovepos.transform.position) 
        {
            NlosMove = false;
            pickNewMove = true;
        }
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
