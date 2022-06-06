using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitable
{
    public Material defaultMaterial;
    public Material targetedMaterial;
    public RangedWeapon rangedWeapon;

    Transform playerTr;
    MeshRenderer meshRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        playerTr = FindObjectOfType<Player>().transform;
        Debug.Log( playerTr );
    }

    // Update is called once per frame
    void Update()
    {
        if( CheckPlayer() )
        {
            rangedWeapon.LookAtTarget( playerTr.position );
            rangedWeapon.Shoot( rangedWeapon.transform.forward );
        }
    }

    bool CheckPlayer()
    {
        Ray ray = new Ray( transform.position,  playerTr.position - transform.position );
        RaycastHit raycastHit;
        Physics.Raycast( ray, out raycastHit );
        if ( raycastHit.collider != null )
        {
            Player player = raycastHit.collider.GetComponent<Player>();
            if ( player != null )
                return true;
        }

        return false;
        //ProcessCollision( raycastHit.collider );


    }

    public void SetTargetMaterial()
    {
        meshRenderer.material = targetedMaterial;
    }

    public void SetDefaulMaterial()
    {
        meshRenderer.material = defaultMaterial;
    }

    public void OnHit()
    {
        gameObject.SetActive( false );
    }
}
