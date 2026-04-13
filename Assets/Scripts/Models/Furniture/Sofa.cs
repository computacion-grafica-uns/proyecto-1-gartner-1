using System.Collections.Generic;
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
            colors[i] = Color.blue;
        }

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("Sofa");
    }
}