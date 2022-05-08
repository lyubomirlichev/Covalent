using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private Material protonMaterial;
    [SerializeField] private Material neutronMaterial;

    public GameObject CreateNeutron(float scale)
    {
        return CreateSphere(neutronMaterial, scale);
    }

    public GameObject CreateProton(float scale)
    {
        return CreateSphere(protonMaterial, scale);
    }

    public GameObject CreateSphere(Material material, float scale)
    {
        var sphere = new GameObject();
        var sphereMeshFilter = sphere.AddComponent<MeshFilter>();
        var sphereMesh = sphereMeshFilter.mesh;
        var sphereMeshRenderer = sphere.AddComponent<MeshRenderer>();

        sphereMeshRenderer.material = material;
        sphere.transform.localScale = new Vector3(scale, scale, scale);
        IcoSphere.Create(sphere);

        sphereMesh.RecalculateBounds();
        sphereMesh.RecalculateTangents();
        sphereMesh.RecalculateNormals();
        sphereMesh.Optimize();

        return sphere;
    }
}