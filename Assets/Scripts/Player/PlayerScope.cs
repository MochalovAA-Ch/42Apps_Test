using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScope : MonoBehaviour
{
    Collider previousTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRayCast();
    }

    void CheckRayCast()
    {
        Ray ray = new Ray( transform.position, transform.forward );
        RaycastHit raycastHit;
        Physics.Raycast( ray, out raycastHit );
        ProcessCollision( raycastHit.collider );
    }

    private void ProcessCollision( Collider currentTarget )
    {
        // No collision this frame.
        if ( currentTarget == null )
        {
            // But there was an object hit last frame.
            if ( previousTarget != null )
            {
                OnRayExit( previousTarget );
            }
        }

        // The object is the same as last frame.
        else if ( previousTarget == currentTarget )
        {
            //DoEvent( OnRayStay, currentTarget );
        }

        // The object is different than last frame.
        else if ( previousTarget != null )
        {
            OnRayExit( previousTarget );
            OnRayEnter( currentTarget );
        }

        // There was no object hit last frame.
        else
        {
            OnRayEnter( currentTarget );
        }

        // Remember this object for comparing with next frame.
        previousTarget = currentTarget;
    }


    void OnRayEnter( Collider collider )
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if ( enemy != null )
            enemy.SetTargetMaterial();
    }

    void OnRayExit( Collider collider )
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if ( enemy != null )
            enemy.SetDefaulMaterial();
    }
}
