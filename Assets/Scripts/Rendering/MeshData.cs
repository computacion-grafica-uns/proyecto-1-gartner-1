using UnityEngine;

public class MeshData
{
    public Vector3[] Vertices;
    public int[] Triangles;
    public Color[] Colors;

    public MeshData(Vector3[] vertices, int[] triangles, Color[] colors = null)
    {
        Vertices = vertices;
        Triangles = triangles;
        Colors = colors;
    }
}
