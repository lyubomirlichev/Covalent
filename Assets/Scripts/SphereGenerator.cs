using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private Material SphereMaterial;

    [SerializeField] private float sphereSize;

    public GameObject CreateSphereGameObject()
    {
        var sphere = new GameObject();
        var sphereMeshFilter = sphere.AddComponent<MeshFilter>();
        var sphereMesh = sphereMeshFilter.mesh;
        var sphereMeshRenderer = sphere.AddComponent<MeshRenderer>();
       
        sphereMeshRenderer.material = SphereMaterial;
        sphere.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);
        IcoSphere.Create(sphere);

        sphereMesh.RecalculateBounds();
        sphereMesh.RecalculateTangents();
        sphereMesh.RecalculateNormals();
        //sphereMesh.Optimize();

        return sphere;
    }
}