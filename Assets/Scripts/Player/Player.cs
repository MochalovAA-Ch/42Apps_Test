using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    public float Speed;
    public RangedWeapon weapon;

    CharacterController charController;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        Debug.Log( "Старт игры" );
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if ( Input.GetKeyDown( KeyCode.Mouse0 ) )
            weapon.Shoot( Vector3.zero );
    }

    private void Move()
    {
        float x = Input.GetAxis( "Horizontal" );
        float y = Input.GetAxis( "Vertical" );

        Vector3 moveHorizontal = transform.right * x + transform.forward * y + offset;
        offset = Vector3.Lerp( offset, Vector3.zero, Time.deltaTime * 10);

        charController.Move( ( moveHorizontal * Speed - Vector3.up*9.8f ) * Time.deltaTime );
    }

    public void OnHit( bool IsPlayerBullet)
    {
        if ( !IsPlayerBullet ) return;

        offset = -transform.forward;
    }

}
