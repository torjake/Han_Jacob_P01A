using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleShitsBullet : BulletsBaseClass
{

    [SerializeField]
    float _lilSpeed = 1000f;

    float deathTimer;

    public GameObject trackers;

    protected override void HitPlayer(GameObject player)
    {
        player.GetComponent<TankController>().DecreaseHealth(1);
        Destroy(gameObject);
    }
    protected override void HitBoss(BossBaseClass boss)
    {
        
    }
    protected override void HitBullet()
    {
        Destroy(gameObject);
    }
    protected override void HitWall()
    {
        //Instantiate(simpleBullet, firepoint.position, this.transform.rotation);
        Instantiate(trackers, this.transform.position, this.transform.rotation);
        Instantiate(trackers, this.transform.position, this.transform.rotation);
        Instantiate(trackers, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
    protected override void Move(Rigidbody _rb)
    {
        _rb.velocity = transform.forward * _lilSpeed * Time.deltaTime;
    }
    protected override void Death(float _timer)
    {
        deathTimer += Time.deltaTime;
        if (deathTimer > _timer)
            Destroy(gameObject);
    }
}
