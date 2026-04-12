using UnityEngine;

public class Floor : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        Vector3[] vertices = new Vector3[]
        {
          new Vector3(-2.475f, 0, -2.26875f),
          new Vector3(-2.475f, 0, 2.26875f),
          new Vector3(2.475f, 0, 2.26875f),
          new Vector3(2.475f, 0, -2.26875f),
        };

        int[] triangles = new int[]
        {
          0, 1, 2,
          0, 2, 3
        };

        Color[] colors = new Color[]
        {
          Color.red,
          Color.green,
          Color.blue,
          Color.white
        };

        return new MeshData(vertices, triangles, colors);
    }

    public override void Create()
    {
        Create("Floor");
    }
}