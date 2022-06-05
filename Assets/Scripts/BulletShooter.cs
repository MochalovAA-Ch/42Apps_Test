using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    float delayBeetwenShoot;
    public float DelayBeetwenShoot;
    public ObjectPooler bulletPooler;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayBeetwenShoot += Time.deltaTime;
        if( delayBeetwenShoot >= DelayBeetwenShoot )
        {
            if ( Input.GetKeyDown( KeyCode.Mouse0 ) )
                Shoot();
        }

    }

    void Shoot()
    {
        delayBeetwenShoot = 0.0f;
        GameObject gameObject = bulletPooler.SpawnObject( transform.position, transform.rotation );
        Bullet bullet = gameObject.GetComponent<Bullet>();
    }

}
