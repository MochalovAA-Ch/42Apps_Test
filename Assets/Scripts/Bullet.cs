using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpawnableObject
{
    public float LifeTime;
    public float Speed;
    public ParticleSystem hitEffect;

    MeshRenderer meshRender;
    bool wasHit = false;
    float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( wasHit ) return;

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

    private void OnEnable()
    {
        if ( meshRender == null ) meshRender = GetComponent<MeshRenderer>();
        meshRender.enabled = true;
    }

    private void OnDisable()
    {

    }

    IEnumerator DisableObjectCourutine()
    {
        wasHit = true;
        meshRender.enabled = false;
        hitEffect.Play();
        yield return new WaitForSeconds( 0.2f );
        wasHit = false;
        gameObject.SetActive( false );
    }

    public void OnCollisionEnter( Collision collision )
    {
        //Debug.Log( collision );
    }

    private void OnTriggerEnter( Collider other )
    {
        if ( other.isTrigger ) return;    //Не берем в расчет другие тригеры

        IHitable hitable = other.GetComponent<IHitable>();
        if( hitable != null )
        {
            hitable.OnHit();
        }

        StartCoroutine( DisableObjectCourutine() );
        //Debug.Log( other );
    }
}
