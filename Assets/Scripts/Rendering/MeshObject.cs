using UnityEngine;

public static class MeshObject
{
    public static GameObject Create(string objectName, MeshData data, Material material)
    {
        GameObject obj = new GameObject(objectName);

        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        mesh.vertices = data.Vertices;
        mesh.triangles = data.Triangles;

        if (data.Colors != null && data.Colors.Length == data.Vertices.Length)
        {
            mesh.colors = data.Colors;
        }

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;
        meshRenderer.material = material;

        return obj;
    }
}