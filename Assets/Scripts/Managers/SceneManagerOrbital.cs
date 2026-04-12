using UnityEngine;
using System.Collections.Generic;

public class SceneManagerOrbital : MonoBehaviour
{
    private List<CustomGameObject> customGameObjects = new List<CustomGameObject>();
    private OrbitalCamera orbitalCamera;
    private Matrix4x4 currentViewMatrix;

    private void CreateOrbitalCamera()
    {
        GameObject orbitalObj = new GameObject("Orbital Camera");

        orbitalObj.AddComponent<Camera>();
        OrbitalCamera orbital = orbitalObj.AddComponent<OrbitalCamera>();

        orbital.target = Vector3.zero;
        orbital.distance = 5f;
        orbital.yaw = 0f;
        orbital.pitch = 20f;
        orbital.keyboardSpeed = 100f;
        orbital.mouseSpeed = 3f;
        orbital.zoomSpeed = 5f;

        orbitalCamera = orbital;
        currentViewMatrix = orbital.GetViewMatrix();
    }

    private void LoadOBJ()
    {
        //string path = "Assets/Models/Bed1.obj";

        //GameObject obj = new GameObject("OBJ Model");

        //obj.AddComponent<MeshFilter>();
        //obj.AddComponent<MeshRenderer>();

        //FileReader loader = obj.AddComponent<FileReader>();

        //loader.LoadOBJ(path);

        //obj.GetComponent<MeshRenderer>().material = new Material(Shader.Find("BasicShader"));
    }

    private void UpdateViewMatrices()
    {
        if (customGameObjects == null) return;

        for (int i = 0; i < customGameObjects.Count; i++)
        {
            customGameObjects[i].SetViewMatrix(currentViewMatrix);
        }
    }

    void Start()
    {
        CreateOrbitalCamera();

        CustomGameObject floor = new Floor();
        floor.Create();

        CustomGameObject plainWall1 = new PlainWall();
        Matrix4x4 plainWall1ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(0, 0, -2.26875f), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        plainWall1.Create();
        plainWall1.SetModelMatrix(plainWall1ModelMatrix);

        CustomGameObject plainWall2 = new PlainWall();
        plainWall2.Create();
        Matrix4x4 plainWall2ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(0, 0, 2.26875f), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        plainWall2.SetModelMatrix(plainWall2ModelMatrix);

        customGameObjects.Add(floor);
        customGameObjects.Add(plainWall1);
        customGameObjects.Add(plainWall2);
    }

    void Update()
    {
        if (orbitalCamera != null)
        {
            orbitalCamera.HandleRotation();
            orbitalCamera.HandleZoom();
            currentViewMatrix = orbitalCamera.GetViewMatrix();
            
            UpdateViewMatrices();
        }
    }
}