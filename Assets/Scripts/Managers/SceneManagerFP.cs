using UnityEngine;
using System.Collections.Generic;

public class SceneManagerFP : MonoBehaviour
{
    private List<CustomGameObject> customGameObjects = new List<CustomGameObject>();
    private FirstPersonCamera fpCamera;
    private Matrix4x4 currentViewMatrix;

    private void CreateFPCamera()
    {
        GameObject fpObject = new GameObject("FPCamera");

        fpObject.AddComponent<Camera>();
        fpObject.transform.position = new Vector3(0f, 1.5f, -10f);
        FirstPersonCamera fp = fpObject.AddComponent<FirstPersonCamera>();

        fp.position = new Vector3(0f, 1.5f, -20f);
        fp.yaw = 0f;
        fp.pitch = 0f;
        fp.moveSpeed = 5f;
        fp.sprintSpeed = 9f;
        fp.mouseSensitivity = 2f;
        fp.keyboardRotationSpeed = 100f;

        fpCamera = fp;
        currentViewMatrix = fp.GetViewMatrix();
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
        CreateFPCamera();

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
        if(fpCamera != null)
        {
            fpCamera.HandleRotation();
            fpCamera.UpdateCameraVectors();
            fpCamera.HandleMovement();
            currentViewMatrix = fpCamera.GetViewMatrix();

            UpdateViewMatrices();
        }
    }
}