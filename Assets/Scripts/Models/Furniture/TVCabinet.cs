using UnityEngine;
public class TVCabinet : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        string path = "Assets/OBJModels/Furniture/TVs/TVCabinet/TVCabinet.obj";

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
        Create("TV Cabinet");
    }
}