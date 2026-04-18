using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class FileReader
{
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();

    public void LoadOBJ(string path, float unitsToMeters = 1f)
    {
        vertices.Clear();
        triangles.Clear();

        string fileData;

        using (StreamReader reader = new StreamReader(path))
        {
            fileData = reader.ReadToEnd();
        }

        ParseOBJ(fileData);
        CenterAndPlaceOnGround(unitsToMeters);
    }

    public List<Vector3> GetVertices()
    {
        return vertices;
    }

    public List<int> GetTriangles()
    {
        return triangles;
    }

    void ParseOBJ(string fileData)
    {
        string[] lines = fileData.Split('\n');

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            if (line.StartsWith("v "))
            {
                float x = float.Parse(parts[1], CultureInfo.InvariantCulture);
                float y = float.Parse(parts[2], CultureInfo.InvariantCulture);
                float z = float.Parse(parts[3], CultureInfo.InvariantCulture);

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

    void CenterAndPlaceOnGround(float unitsToMeters)
    {
        if (vertices.Count == 0) return;

        // Convertir unidades a metros
        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] *= unitsToMeters;
        }

        Vector3 min = vertices[0];
        Vector3 max = vertices[0];

        foreach (Vector3 v in vertices)
        {
            min = Vector3.Min(min, v);
            max = Vector3.Max(max, v);
        }

        float centerX = (min.x + max.x) / 2f;
        float centerZ = (min.z + max.z) / 2f;

        // Centro en XZ, base en y = 0
        Vector3 offset = new Vector3(-centerX, -min.y, -centerZ);

        for (int i = 0; i < vertices.Count; i++)
        {
            vertices[i] += offset;
        }
    }
}