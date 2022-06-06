using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveMode
{ 
    Left,
    Right,
    Stay
}


public class Enemy : MonoBehaviour, IHitable
{
    public float Speed;

    public Material defaultMaterial;
    public Material targetedMaterial;
    public RangedWeapon rangedWeapon;

    Transform playerTr;
    MeshRenderer meshRenderer;
    CharacterController characterController;
    MoveMode moveMode;

    float swithcMoveModeTime = 1.0f;
    float switchMoveModeTimer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        playerTr = FindObjectOfType<Player>().transform;
        characterController = GetComponent<CharacterController>();
        ChangeMoveMode();
    }

    // Update is called once per frame
    void Update()
    {
        if( CheckPlayer() )
        {
            rangedWeapon.LookAtTarget( playerTr.position );
            rangedWeapon.Shoot( rangedWeapon.transform.forward );
        }

        Move();
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

    void ChangeMoveMode()
    {
        moveMode = (MoveMode)Random.Range( 0, 3 );
    }

    void Move()
    {
        Vector3 dir = Vector3.zero;

        if ( moveMode == MoveMode.Left )
            dir = -transform.right;
        if ( moveMode == MoveMode.Right )
            dir = transform.right;

        if ( !CheckGround( dir ) )
        {
            switchMoveModeTimer += Time.deltaTime;
            if( switchMoveModeTimer >= swithcMoveModeTime )
            {
                ChangeMoveMode();
                switchMoveModeTimer = 0.0f;
            }

            dir = Vector3.zero;
        }
            

        characterController.Move( ( dir * Speed - Vector3.up * 9.8f ) * Time.deltaTime );
    }

    bool CheckGround( Vector3 dir)
    {
        return Physics.CheckSphere( transform.position - Vector3.up + dir, 0.5f );
    }

    public void SetTargetMaterial()
    {
        meshRenderer.material = targetedMaterial;
    }

    public void SetDefaulMaterial()
    {
        meshRenderer.material = defaultMaterial;
    }

    public void OnHit( bool IsPlayerBullet )
    {
        if ( IsPlayerBullet ) return;

        Debug.Log( "Попали в агента " + gameObject );
        gameObject.SetActive( false ); 
    }
}
