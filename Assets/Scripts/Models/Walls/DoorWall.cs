using UnityEngine;

public class DoorWall : CustomGameObject
{
    protected override MeshData CreateMeshData()
    {
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(3.5f, 0, 0),
            new Vector3(3.5f, 2f, 0),
            new Vector3(3.45f, 2f, 0),
            new Vector3(3.45f, 0, 0),

            new Vector3(3.5f, 2f, 0),
            new Vector3(3.5f, 2.5f, 0),
            new Vector3(-3.5f, 2.5f, 0),
            new Vector3(-3.5f, 2f, 0),

            new Vector3(2.45f, 0, 0),
            new Vector3(2.45f, 2f, 0),
            new Vector3(-3.5f, 2f, 0),
            new Vector3(-3.5f, 0f, 0),
        };

        int[] triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3,

            4,5,6,
            4,6,7,

            8,9,10,
            8,10,11,
        };

        return new MeshData(vertices, triangles, null);
    }

    public override void Create()
    {
        Create("DoorWall");
    }
}