using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerBullet : BulletsBaseClass
{
    [SerializeField]
    float _trackerSpeed = 1200f;

    float deathTimer;

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

    }
    protected override void Move(Rigidbody _rb)
    {
        _rb.velocity = transform.forward * _trackerSpeed * Time.deltaTime;
        
        //
        Vector3 targetDirection = player.transform.position - this.transform.position;
        Vector3 newdirection = Vector3.RotateTowards(transform.right, targetDirection, 100f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newdirection);
    }
    protected override void Death(float _timer)
    {
        deathTimer += Time.deltaTime;
        if (deathTimer > _timer * 10f)
            Destroy(gameObject);
    }
}
