using UnityEngine;

public class KitchenCabinet : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        string path = "Assets/OBJModels/Furniture/Kitchen/Cabinets/KitchenCabinet1/KitchenCabinet1.obj";

        FileReader fileReader = new FileReader();
        fileReader.LoadOBJ(path);
        Vector3[] vertices = fileReader.GetVertices().ToArray();
        int[] triangles = fileReader.GetTriangles().ToArray();

        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(0.78f, 0.70f, 0.58f);
        }

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("KitchenCabinet");
    }
}