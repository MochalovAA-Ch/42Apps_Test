using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController charController;

    public float Speed;
    public RangedWeapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if ( Input.GetKeyDown( KeyCode.Mouse0 ) )
            weapon.Shoot();
    }

    private void Move()
    {
        float x = Input.GetAxis( "Horizontal" );
        float y = Input.GetAxis( "Vertical" );

        Vector3 moveHorizontal = transform.right * x + transform.forward * y;

        charController.Move( ( moveHorizontal * Speed - Vector3.up*9.8f ) * Time.deltaTime );

    }

}
