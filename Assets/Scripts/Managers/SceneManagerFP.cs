using UnityEngine;
using System.Collections.Generic;
public class SceneManagerFP : MonoBehaviour
{
    private List<CustomGameObject> customGameObjects = new List<CustomGameObject>();
    private FirstPersonCamera fpCamera;
    private CustomGameObject roof;
    private List<CustomGameObject> walls = new List<CustomGameObject>();
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

    private void ToggleRoof()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            roof.GetRenderer().enabled = !roof.GetRenderer().enabled;
        }
    }

    private void ToggleWalls()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            for (int i = 0; i < walls.Count; i++)
            {
                CustomGameObject wall = walls[i];
                wall.GetRenderer().enabled = !wall.GetRenderer().enabled;
            }
        }
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

        roof = new Roof();
        roof.Create();
        Matrix4x4 roofModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(0, 2.5f, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        roof.SetModelMatrix(roofModelMatrix);

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

        walls.Add(plainWall1);
        walls.Add(plainWall2);
        walls.Add(doorWall);
        walls.Add(windowWall);

        CustomGameObject sofa = new Sofa();
        sofa.Create();

        CustomGameObject wideTable = new WideTable();
        wideTable.Create();

        CustomGameObject chair1 = new Chair();
        chair1.Create();

        CustomGameObject chair2 = new Chair();
        chair2.Create();

        CustomGameObject chair3 = new Chair();
        chair3.Create();

        CustomGameObject chair4 = new Chair();
        chair4.Create();

        CustomGameObject kitchenCabinet1 = new KitchenCabinet();
        kitchenCabinet1.Create();

        CustomGameObject kitchenCabinet2 = new KitchenCabinet();
        kitchenCabinet2.Create();

        CustomGameObject kitchenCabinet3 = new KitchenCabinet();
        kitchenCabinet3.Create();

        CustomGameObject kitchenCabinetRounded = new KitchenCabinetRounded();
        kitchenCabinetRounded.Create();

        customGameObjects.Add(floor);
        customGameObjects.Add(roof);
        customGameObjects.Add(plainWall1);
        customGameObjects.Add(plainWall2);
        customGameObjects.Add(doorWall);
        customGameObjects.Add(windowWall);

        customGameObjects.Add(sofa);

        customGameObjects.Add(wideTable);
        customGameObjects.Add(chair1);
        customGameObjects.Add(chair2);
        customGameObjects.Add(chair3);
        customGameObjects.Add(chair4);

        customGameObjects.Add(kitchenCabinet1);
        customGameObjects.Add(kitchenCabinet2);
        customGameObjects.Add(kitchenCabinet3);

        customGameObjects.Add(kitchenCabinetRounded);

        //Fridge
        //TV
        //Carpet
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

        ToggleRoof();
        ToggleWalls();
    }
}