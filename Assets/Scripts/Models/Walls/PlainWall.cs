using UnityEngine;

public class PlainWall : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        Vector3[] vertices = new Vector3[]
        {
          new Vector3(-4, 0, 0),
          new Vector3(-4, 2.5f, 0),
          new Vector3(4, 2.5f, 0),
          new Vector3(4, 0, 0),
        };

        int[] triangles = new int[]
        {
          0, 1, 2,
          0, 2, 3
        };

        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(0.95f, 0.93f, 0.90f);
        }

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("PlainWall");
    }
}