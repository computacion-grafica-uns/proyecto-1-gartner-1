using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomGameObject
{
    private GameObject gameObject;

    protected abstract MeshData CreateMeshData();

    public abstract void Create();

    public void Create(string name)
    {
        Material material = new Material(Shader.Find("BasicShader"));
        MeshData meshData = CreateMeshData();
        gameObject = MeshObject.Create(name, meshData, material);

        Matrix4x4 projectionMatrix = ProjectionMatrix.CreateProjectionMatrix(60f, (float)Screen.width / Screen.height, 0.1f, 50f);
        Matrix4x4 viewMatrix = ViewMatrix.CreateViewMatrix(new Vector3(0, 0, -2), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        Matrix4x4 modelMatrix = Matrix4x4.identity;

        SetProjectionMatrix(GL.GetGPUProjectionMatrix(projectionMatrix, true));
        SetViewMatrix(viewMatrix);
        SetModelMatrix(modelMatrix);
    }

    public void SetProjectionMatrix(Matrix4x4 projectionMatrix)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetMatrix("_ProjectionMatrix", projectionMatrix);
    }

    public void SetViewMatrix(Matrix4x4 viewMatrix)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetMatrix("_ViewMatrix", viewMatrix);
    }

    public void SetModelMatrix(Matrix4x4 modelMatrix)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetMatrix("_ModelMatrix", modelMatrix);
    }
    public MeshRenderer GetRenderer()
    {
        return gameObject.GetComponent<MeshRenderer>();
    }
}
