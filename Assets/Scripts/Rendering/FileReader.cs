using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();

    public void LoadOBJ(string path)
    {
        vertices.Clear();
        triangles.Clear();

        string fileData;

        using (StreamReader reader = new StreamReader(path))
        {
            fileData = reader.ReadToEnd();
        }

        ParseOBJ(fileData);
        CreateMesh();
    }


    void ParseOBJ(string fileData)
    {
        string[] lines = fileData.Split('\n');

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            string[] parts = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            if (line.StartsWith("v "))
            {
                float x = float.Parse(parts[1]);
                float y = float.Parse(parts[2]);
                float z = float.Parse(parts[3]);

                vertices.Add(new Vector3(x, y, z));
            }
            else if (line.StartsWith("f "))
            {
                int[] face = new int[parts.Length - 1];

                for (int i = 1; i < parts.Length; i++)
                {
                    string[] sub = parts[i].Split('/');

                    face[i - 1] = int.Parse(sub[0]) - 1;
                }

                for (int i = 1; i < face.Length - 1; i++)
                {
                    triangles.Add(face[0]);
                    triangles.Add(face[i]);
                    triangles.Add(face[i + 1]);
                }
            }
        }
    }

    void CreateMesh()
    {
        CenterAndNormalizeModel();

        Mesh mesh = new Mesh();
        mesh.name = "OBJ Mesh";

        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        Debug.Log(mesh.bounds.center);
        Debug.Log(mesh.bounds.size);

        GetComponent<MeshFilter>().mesh = mesh;
    }

  
    void CenterAndNormalizeModel()
    {
        if (vertices.Count == 0) return;

        Vector3 min = vertices[0];
        Vector3 max = vertices[0];

        foreach (Vector3 v in vertices)
        {
            min = Vector3.Min(min, v);
            max = Vector3.Max(max, v);
        }

        Vector3 center = (min + max) / 2f;
        Vector3 size = max - min;

        float maxDimension = Mathf.Max(size.x, size.y, size.z);

        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] -= center;

            if (maxDimension > 0f)
            {
                vertices[i] /= maxDimension;
            }
        }
    }
    
}