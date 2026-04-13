using UnityEngine;

public class Floor : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        Vector3[] vertices = new Vector3[]
        {
          new Vector3(-3.5f, 0, -4),
          new Vector3(3.5f , 0, -4),
          new Vector3(3.5f, 0, 4),
          new Vector3(-3.5f, 0, 4),
        };

        int[] triangles = new int[]
        {
          0, 1, 2,
          0, 2, 3,
        };

        Color[] colors = new Color[]
        {
          Color.white,
        };

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("Floor");
    }
}