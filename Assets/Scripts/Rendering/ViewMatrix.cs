using UnityEngine;

public static class ViewMatrix
{
    public static Matrix4x4 CreateViewMatrix(Vector3 pos, Vector3 target, Vector3 up)
    {
        // Forward: hacia dónde mira la cámara
        Vector3 F = (target - pos).normalized;

        // Right: eje derecha
        Vector3 R = Vector3.Cross(up, F).normalized;

        // Up corregido para asegurar ortogonalidad
        Vector3 U = Vector3.Cross(F, R);

        Matrix4x4 V = new Matrix4x4();

        // Fila 0
        V[0, 0] = R.x;
        V[0, 1] = R.y;
        V[0, 2] = R.z;
        V[0, 3] = -Vector3.Dot(R, pos);

        // Fila 1
        V[1, 0] = U.x;
        V[1, 1] = U.y;
        V[1, 2] = U.z;
        V[1, 3] = -Vector3.Dot(U, pos);

        // Fila 2
        V[2, 0] = -F.x;
        V[2, 1] = -F.y;
        V[2, 2] = -F.z;
        V[2, 3] = Vector3.Dot(F, pos);

        // Fila 3
        V[3, 0] = 0f;
        V[3, 1] = 0f;
        V[3, 2] = 0f;
        V[3, 3] = 1f;

        return V;
    }
}