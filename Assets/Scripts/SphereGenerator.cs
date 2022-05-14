using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private Material protonMaterial;
    [SerializeField] private Material neutronMaterial;
    [SerializeField] private Material electronMaterial;

    private Mesh sphereMesh;

    public void Init()
    {
        var sphere = new GameObject();
        var sphereMeshFilter = sphere.AddComponent<MeshFilter>();
        sphere.transform.localScale = Vector3.one;
        
        IcoSphere.Create(sphere);
        sphereMeshFilter.mesh.RecalculateBounds();
        sphereMeshFilter.mesh.RecalculateTangents();
        sphereMeshFilter.mesh.RecalculateNormals();
        sphereMeshFilter.mesh.Optimize();

        sphereMesh = sphereMeshFilter.mesh;

        Destroy(sphere);
    }

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
        sphereMeshFilter.mesh = sphereMesh;
        sphere.transform.localScale = new Vector3(scale, scale, scale);
        sphereMeshRenderer.material = material;
        sphereMeshRenderer.receiveShadows = false;
        
        return sphere;
    }
}