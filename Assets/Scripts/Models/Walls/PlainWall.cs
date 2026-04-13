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

        return new MeshData(vertices, triangles, null);
    }

    public override void Create()
    {
        Create("PlainWall");
    }
}