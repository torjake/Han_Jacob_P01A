using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBullets : BulletsBaseClass
{
    float deathTimer;
    protected override void HitPlayer(GameObject player)
    {
        player.GetComponent<TankController>().DecreaseHealth(2);
        Destroy(gameObject);
    }
    protected override void HitBoss(BossBaseClass boss)
    {

    }
    protected override void HitBullet()
    {
        
    }
    protected override void HitWall()
    {

    }
    protected override void Move(Rigidbody _rb)
    {
        _rb.transform.position = bosss.GetComponent<BossBaseClass>().FirePoint.transform.position;
    }
    protected override void Death(float _timer)
    {
        deathTimer += Time.deltaTime;
        if (deathTimer > _timer / 1.7f)
            Destroy(gameObject);
    }
}
