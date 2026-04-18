using UnityEngine;

public class TV : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        string path = "Assets/OBJModels/Furniture/TVs/TV/TV.obj";

        FileReader fileReader = new FileReader();
        fileReader.LoadOBJ(path, 0.01f);
        Vector3[] vertices = fileReader.GetVertices().ToArray();
        int[] triangles = fileReader.GetTriangles().ToArray();

        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(0.08f, 0.08f, 0.09f);
        }

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("TV");
    }
}