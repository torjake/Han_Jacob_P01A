using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BulletsBaseClass : MonoBehaviour
{

    protected abstract void HitPlayer(GameObject player);

    protected abstract void HitBoss(BossBaseClass boss);

    protected abstract void HitWall();

    protected abstract void HitBullet();

    protected abstract void Move(Rigidbody _rb);

    protected abstract void Death(float _timer);

    float _timer;

    Rigidbody _rb;

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public GameObject bosss;

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _timer = 5f;

        player = GameObject.FindGameObjectWithTag("Player");

        bosss = GameObject.FindGameObjectWithTag("Boss");
    }
    private void FixedUpdate()
    {
        Move(_rb);
    }
     private void Update()
    {
        Death(_timer);
        //
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerBaseSCrit playerhit = collision.gameObject.GetComponent<PlayerBaseSCrit>();
        BossBaseClass boss = collision.gameObject.GetComponent<BossBaseClass>();
        if (collision.gameObject.tag == "Player") 
        {
            HitPlayer(player);
            Feedback();
            
        }
        if (boss != null) 
        {
            HitBoss(boss);
            Feedback();
        }
        if (collision.gameObject.tag == "wall") 
        {
            HitWall();
        }
        if (collision.gameObject.tag == "Bullet") 
        {
            HitBullet();
        }
    }
    private void Feedback()
    {
        print("effect");
        // particles
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles,
                transform.position, Quaternion.identity);
        }
        //audio
        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 0.5f);
        }
    }
}
