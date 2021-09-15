using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : BulletsBaseClass
{
    public float _bulletSpeed = 500f;

    float deathTime;

    protected override void HitPlayer(GameObject player) 
    {
        
    }
    protected override void HitBoss(BossBaseClass boss)
    {
        boss.DecreaseHealth(1);
        //
        Destroy(gameObject);
    }

    protected override void HitWall()
    {
        Destroy(gameObject);
    }
    protected override void HitBullet()
    {
        Destroy(gameObject);
    }
    protected override void Move(Rigidbody _rb) 
    {
        _rb.velocity = transform.right * _bulletSpeed * Time.deltaTime;
        _bulletSpeed -= (1800f * Time.deltaTime);
    }
    protected override void Death(float _timer) 
    {
        deathTime += Time.deltaTime;
        if (deathTime >= _timer)
            Destroy(gameObject);
    }
}
