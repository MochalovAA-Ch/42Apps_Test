using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Material defaultMaterial;
    public Material targetedMaterial;

    Player player;

    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        player = FindObjectOfType<Player>();
        Debug.Log( player );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTargetMaterial()
    {
        meshRenderer.material = targetedMaterial;
    }

    public void SetDefaulMaterial()
    {
        meshRenderer.material = defaultMaterial;
    }
}
