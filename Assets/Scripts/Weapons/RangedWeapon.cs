using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    float delayBeetwenShoot;
    public float DelayBeetwenShoot;
    public ObjectPooler bulletPooler;
    public float BulletSpeed;

    public bool IsPlayerWeapon = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayBeetwenShoot += Time.deltaTime;
    }

    public void Shoot( Vector3 offset )
    {
        if ( delayBeetwenShoot >= DelayBeetwenShoot )
        {
            delayBeetwenShoot = 0.0f;
            GameObject gameObject = bulletPooler.SpawnObject( transform.position + transform.forward + offset, transform.rotation );
            Bullet bullet = gameObject.GetComponent<Bullet>();
            bullet.Speed = BulletSpeed;
            bullet.IsPlayerBullet = IsPlayerWeapon;
            Debug.Log( "Выстрел из оружия от " + this.transform.parent );
        }
    }

    public void LookAtTarget( Vector3 target )
    {
        transform.LookAt( target );
    }
}
