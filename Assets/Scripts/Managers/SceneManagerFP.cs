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

        Camera cam = fpObject.AddComponent<Camera>();

        fpObject.transform.position = new Vector3(0, 0, -10f);
        FirstPersonCamera fp = fpObject.AddComponent<FirstPersonCamera>();

        fpCamera = fp;
        currentViewMatrix = fp.GetViewMatrix();
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
        Matrix4x4 plainWall1ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(3.5f, 0, 0), new Vector3(0, -90f * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        plainWall1.Create();
        plainWall1.SetModelMatrix(plainWall1ModelMatrix);

        CustomGameObject plainWall2 = new PlainWall();
        plainWall2.Create();
        Matrix4x4 plainWall2ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-3.5f, 0, 0), new Vector3(0, 90f * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        plainWall2.SetModelMatrix(plainWall2ModelMatrix);

        CustomGameObject doorWall = new DoorWall();
        doorWall.Create();
        Matrix4x4 doorWallModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(0, 0, -4f), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        doorWall.SetModelMatrix(doorWallModelMatrix);

        CustomGameObject windowWall = new WindowWall();
        windowWall.Create();
        Matrix4x4 windowWallModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(0, 0, 4f), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        windowWall.SetModelMatrix(windowWallModelMatrix);

        CustomGameObject sofa = new Sofa();
        sofa.Create();

        customGameObjects.Add(floor);
        customGameObjects.Add(plainWall1);
        customGameObjects.Add(plainWall2);
        customGameObjects.Add(doorWall);
        customGameObjects.Add(windowWall);
        customGameObjects.Add(sofa);
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