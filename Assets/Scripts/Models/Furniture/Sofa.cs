using UnityEngine;

public class Sofa : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        string path = "Assets/OBJModels/Furniture/Sofas/sofa/sofa.obj";

        FileReader fileReader = new FileReader();
        fileReader.LoadOBJ(path);
        Vector3[] vertices = fileReader.GetVertices().ToArray();
        int[] triangles = fileReader.GetTriangles().ToArray();

        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(0.88f, 0.85f, 0.78f);
        }

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("Sofa");
    }
}