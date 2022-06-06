using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScope : MonoBehaviour
{
    Collider previousTarget;

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
        if ( currentTarget == null )
        {
            if ( previousTarget != null )
            {
                OnRayExit( previousTarget );
            }
        }
        else if ( previousTarget == currentTarget )
        {
            //Аналог OnStay event
        }
        else if ( previousTarget != null )
        {
            OnRayExit( previousTarget );
            OnRayEnter( currentTarget );
        }
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
