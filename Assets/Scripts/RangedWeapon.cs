using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    float delayBeetwenShoot;
    public float DelayBeetwenShoot;
    public ObjectPooler bulletPooler;
    public float BulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayBeetwenShoot += Time.deltaTime;
        /*if ( Input.GetKeyDown( KeyCode.Mouse0 ) )
            Shoot();*/

    }

    public void Shoot( Vector3 offset )
    {
        if ( delayBeetwenShoot >= DelayBeetwenShoot )
        {
            /*if ( Input.GetKeyDown( KeyCode.Mouse0 ) )
                Shoot();*/
            delayBeetwenShoot = 0.0f;
            GameObject gameObject = bulletPooler.SpawnObject( transform.position + transform.forward + offset, transform.rotation );
            Bullet bullet = gameObject.GetComponent<Bullet>();
            bullet.Speed = BulletSpeed;
        }
    }

    public void LookAtTarget( Vector3 target )
    {
        transform.LookAt( target );
    }

}
