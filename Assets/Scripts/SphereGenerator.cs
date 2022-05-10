using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private Material protonMaterial;
    [SerializeField] private Material neutronMaterial;
    [SerializeField] private Material electronMaterial;

    private List<Mesh> spheres = new List<Mesh>();
    private Mesh sphereMesh;
    public GameObject CreateNeutron(float scale)
    {
        return CreateSphere(neutronMaterial, scale);
    }
    
    public GameObject CreateElectron(float scale)
    {
        return CreateSphere(electronMaterial, scale);
    }
    public GameObject CreateProton(float scale)
    {
        return CreateSphere(protonMaterial, scale);
    }

    public GameObject CreateSphere(Material material, float scale)
    {
        var sphere = new GameObject();
        var sphereMeshFilter = sphere.AddComponent<MeshFilter>();
        var sphereMeshRenderer = sphere.AddComponent<MeshRenderer>();
        
        sphere.transform.localScale = new Vector3(scale, scale, scale);
        IcoSphere.Create(sphere);
        //even tho the mesh is re-recreated, gpu is clever enough to know they are the same configuration
        sphereMeshRenderer.receiveShadows = false;
        sphereMeshRenderer.shadowCastingMode = ShadowCastingMode.Off;
        sphereMeshRenderer.material = material;
        sphereMeshFilter.mesh.RecalculateBounds();
        sphereMeshFilter.mesh.RecalculateTangents();
        sphereMeshFilter.mesh.RecalculateNormals();
        sphereMeshFilter.mesh.Optimize();

        return sphere;
    }
}