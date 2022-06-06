using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject prefab;
    public int size;

    Queue<GameObject> poolDictionary; 

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        if ( poolDictionary != null )return;
        
        poolDictionary = new Queue<GameObject>();
        
        for( int i = 0; i < size; i++ )
        {
            AddObject();
        }
    }

    public GameObject SpawnObject( Vector3 position_, Quaternion rotation_ )
    {
        GameObject objectToSpawn = poolDictionary.Dequeue();
        objectToSpawn.SetActive( true );
        poolDictionary.Enqueue( objectToSpawn );

        objectToSpawn.transform.position = position_;
        objectToSpawn.transform.rotation = rotation_;

        ISpawnableObject spawnableObject = objectToSpawn.GetComponent<ISpawnableObject>();
        if ( spawnableObject != null ) spawnableObject.OnSpawn();

        return objectToSpawn;
    }

    void AddObject()
    {
        GameObject gameObject = Instantiate( prefab );
        gameObject.SetActive( false );
        poolDictionary.Enqueue( gameObject );
    }
}
