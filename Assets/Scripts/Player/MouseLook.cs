using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float MouseSensitivity;
    public Transform playerBody;

    float xRotation = 0f;
    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        CheckEnenmyInSight();
    }



    void Rotate()
    {
        mouseX = Input.GetAxis( "Mouse X" ) * MouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis( "Mouse Y" ) * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp( xRotation, -90f, 90f );
        transform.localRotation = Quaternion.Euler( xRotation, 0.0f, 0.0f );
        playerBody.Rotate( Vector3.up * mouseX );
    }


    void CheckEnenmyInSight()
    {
        Ray ray = new Ray( transform.position, transform.forward );
        RaycastHit raycastHit;
        if( Physics.Raycast( ray, out raycastHit ) )
        {
            Enemy enemy = raycastHit.transform.GetComponent<Enemy>();
            if ( enemy != null )
                enemy.SetTargetMaterial();
            //Debug.Log( "rayCastHit" + raycastHit );
        }
    }

    private void LateUpdate()
    {
        /*xRotation -= mouseY;
        xRotation = Mathf.Clamp( xRotation, -90f, 90f );
        transform.localRotation = Quaternion.Euler( xRotation, 0.0f, 0.0f );*/
    }

}
