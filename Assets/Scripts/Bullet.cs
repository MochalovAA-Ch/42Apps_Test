using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpawnableObject
{
    float lifeTime;
    public float LifeTime;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if( lifeTime > LifeTime )
        {
            gameObject.SetActive( false );
        }
        else
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
    }

    public void OnSpawn()
    {
        lifeTime = 0.0f;
    }
}
