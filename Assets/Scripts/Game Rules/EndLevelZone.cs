using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelZone : MonoBehaviour
{
    public string Message;
    public Text infoText; 

    public static bool IsEndLevel { get; private set; } 

    protected IEnumerator EndLevel( string message )
    {
        infoText.text = message;
        yield return new WaitForSeconds( 2 );
        IsEndLevel = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene( 0 );
    }



    private void OnTriggerEnter( Collider other )
    {
        if ( IsEndLevel ) return;

        
        if ( other.GetComponent<Player>() != null )
        {
            IsEndLevel = true;
            StartCoroutine( EndLevel( Message ) );
        }
    }
}
