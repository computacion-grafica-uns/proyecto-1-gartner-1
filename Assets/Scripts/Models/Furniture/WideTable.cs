using UnityEngine;
public class WideTable : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        string path = "Assets/OBJModels/Furniture/tables/widetable/widetable.obj";

        FileReader fileReader = new FileReader();
        fileReader.LoadOBJ(path);
        Vector3[] vertices = fileReader.GetVertices().ToArray();
        int[] triangles = fileReader.GetTriangles().ToArray();

        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(0.36f, 0.25f, 0.20f);
        }

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("WideTable");
    }
}