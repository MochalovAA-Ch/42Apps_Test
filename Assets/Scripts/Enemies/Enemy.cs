using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Material defaultMaterial;
    public Material targetedMaterial;

    MeshRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTargetMaterial()
    {
        renderer.material = targetedMaterial;
    }

    public void SetDefaulMaterial()
    {
        renderer.material = defaultMaterial;
    }
}
