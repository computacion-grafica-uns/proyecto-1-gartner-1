using UnityEngine;

public class WindowWall : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        Vector3[] vertices = new Vector3[]
        {
          new Vector3(-3.5f, 0, 0),
          new Vector3(-3.5f, 2.5f, 0),
          new Vector3(-2.5f, 2.5f, 0),
          new Vector3(-2.5f, 0, 0),

          new Vector3(-2.5f, 0.8f, 0),
          new Vector3(-1, 0.8f, 0),
          new Vector3(-1, 0, 0),

          new Vector3(-2.5f, 2, 0),
          new Vector3(-1, 2.5f, 0),
          new Vector3(-1, 2, 0),

          new Vector3(3.5f, 2.5f, 0),
          new Vector3(3.5f, 0, 0),
        };

        int[] triangles = new int[]
        {
          0, 1, 2,
          0, 2, 3,

          3, 4, 5,
          3, 5, 6,

          7, 2, 8,
          7, 8, 9,

          6, 8, 10,
          6, 10, 11
        };

        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = new Color(0.96f, 0.95f, 0.92f);
        }

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("WindowWall");
    }
}
