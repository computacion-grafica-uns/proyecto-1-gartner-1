using UnityEngine;

public static class ProjectionMatrix
{
    public static Matrix4x4 CreateProjectionMatrix(float fov, float aspect, float near, float far)
    {
        float fovRad = fov * Mathf.Deg2Rad;
        float tanHalfFov = Mathf.Tan(fovRad / 2f);

        Matrix4x4 P = new Matrix4x4();

        // Primera fila
        P[0, 0] = 1f / (aspect * tanHalfFov);
        P[0, 1] = 0f;
        P[0, 2] = 0f;
        P[0, 3] = 0f;

        // Segunda fila
        P[1, 0] = 0f;
        P[1, 1] = 1f / tanHalfFov;
        P[1, 2] = 0f;
        P[1, 3] = 0f;

        // Tercera fila
        P[2, 0] = 0f;
        P[2, 1] = 0f;
        P[2, 2] = (far + near) / (near - far);
        P[2, 3] = (2f * far * near) / (near - far);

        // Cuarta fila
        P[3, 0] = 0f;
        P[3, 1] = 0f;
        P[3, 2] = -1f;
        P[3, 3] = 0f;

        return P;
    }
}