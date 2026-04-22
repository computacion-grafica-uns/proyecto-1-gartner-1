using UnityEngine;
using System.Collections.Generic;

public class SceneManagerOrbital : MonoBehaviour
{
    private List<CustomGameObject> customGameObjects = new List<CustomGameObject>();
    private OrbitalCamera orbitalCamera;
    private CustomGameObject roof;
    private List<CustomGameObject> walls = new List<CustomGameObject>();
    private Matrix4x4 currentViewMatrix;
    private void CreateOrbitalCamera()
    {
        GameObject orbitalObj = new GameObject("Orbital Camera");

        orbitalObj.AddComponent<Camera>();

        orbitalObj.transform.position = new Vector3(0, 0, -10f);
        OrbitalCamera orbital = orbitalObj.AddComponent<OrbitalCamera>();

        orbitalCamera = orbital;
        currentViewMatrix = orbital.GetViewMatrix();
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
        CreateOrbitalCamera();

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
        Matrix4x4 sofaModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(0.5f, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        sofa.SetModelMatrix(sofaModelMatrix);

        CustomGameObject tvCabinet = new TVCabinet();
        tvCabinet.Create();
        Matrix4x4 tvCabinetModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(3.1f, 0, 0), new Vector3(0, -90f * Mathf.Deg2Rad, 0), new Vector3(1.5f, 1.5f, 1.5f));
        tvCabinet.SetModelMatrix(tvCabinetModelMatrix);

        CustomGameObject TV = new TV();
        TV.Create();
        Matrix4x4 TVModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(3.2f, 0.6f, 0), new Vector3(0, -90f * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        TV.SetModelMatrix(TVModelMatrix);

        CustomGameObject carpet = new Carpet();
        carpet.Create();
        Matrix4x4 carpetModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(3f, 0, 0), new Vector3(-90 * Mathf.Deg2Rad, 0, 90 * Mathf.Deg2Rad), new Vector3(1, 1, 1));
        carpet.SetModelMatrix(carpetModelMatrix);

        CustomGameObject wideTableLivingRoom = new WideTable();
        wideTableLivingRoom.Create();
        Matrix4x4 wideTableLivingRoomModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(2f, 0, 0), new Vector3(0, 0, 0), new Vector3(0.4f, 0.4f, 0.4f));
        wideTableLivingRoom.SetModelMatrix(wideTableLivingRoomModelMatrix);


        CustomGameObject wideTableKitchen = new WideTable();
        wideTableKitchen.Create();
        Matrix4x4 wideTableKitchenModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-1.5f, 0, 2.5f), new Vector3(0, 90 * Mathf.Deg2Rad, 0), new Vector3(0.8f, 0.8f, 0.8f));
        wideTableKitchen.SetModelMatrix(wideTableKitchenModelMatrix);

        CustomGameObject chair1 = new Chair();
        chair1.Create();
        Matrix4x4 chair1ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-2.3f, 0, 3f), new Vector3(0, 90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        chair1.SetModelMatrix(chair1ModelMatrix);

        CustomGameObject chair2 = new Chair();
        chair2.Create();
        Matrix4x4 chair2ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-1f, 0, 3f), new Vector3(0, 90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        chair2.SetModelMatrix(chair2ModelMatrix);

        CustomGameObject chair3 = new Chair();
        chair3.Create();
        Matrix4x4 chair3ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-2.3f, 0, 2f), new Vector3(0, -90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        chair3.SetModelMatrix(chair3ModelMatrix);

        CustomGameObject chair4 = new Chair();
        chair4.Create();
        Matrix4x4 chair4ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-1f, 0, 2f), new Vector3(0, -90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        chair4.SetModelMatrix(chair4ModelMatrix);


        CustomGameObject kitchenCabinet1 = new KitchenCabinet();
        kitchenCabinet1.Create();
        Matrix4x4 kitchenCabinet2ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-2f, 0, -3.5f), new Vector3(0, -90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        kitchenCabinet1.SetModelMatrix(kitchenCabinet2ModelMatrix);

        CustomGameObject kitchenCabinet2 = new KitchenCabinet();
        kitchenCabinet2.Create();
        Matrix4x4 kitchenCabinet3ModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-1f, 0, -3.5f), new Vector3(0, -90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        kitchenCabinet2.SetModelMatrix(kitchenCabinet3ModelMatrix);

        CustomGameObject kitchenCabinetRounded = new KitchenCabinetRounded();
        kitchenCabinetRounded.Create();
        Matrix4x4 kitchenCabinetRoundedModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-2.32f, 0, -2.82f), new Vector3(0, -90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        kitchenCabinetRounded.SetModelMatrix(kitchenCabinetRoundedModelMatrix);

        CustomGameObject fridge = new Fridge();
        fridge.Create();
        Matrix4x4 fridgeModelMatrix = ModelMatrix.CreateModelMatrix(new Vector3(-3f, 0, -1f), new Vector3(0, -90 * Mathf.Deg2Rad, 0), new Vector3(1, 1, 1));
        fridge.SetModelMatrix(fridgeModelMatrix);

        customGameObjects.Add(floor);
        customGameObjects.Add(roof);
        customGameObjects.Add(plainWall1);
        customGameObjects.Add(plainWall2);
        customGameObjects.Add(doorWall);
        customGameObjects.Add(windowWall);

        customGameObjects.Add(sofa);
        customGameObjects.Add(tvCabinet);
        customGameObjects.Add(TV);
        customGameObjects.Add(carpet);
        customGameObjects.Add(wideTableLivingRoom);

        customGameObjects.Add(wideTableKitchen);
        customGameObjects.Add(chair1);
        customGameObjects.Add(chair2);
        customGameObjects.Add(chair3);
        customGameObjects.Add(chair4);

        customGameObjects.Add(kitchenCabinet1);
        customGameObjects.Add(kitchenCabinet2);
        customGameObjects.Add(kitchenCabinetRounded);
        customGameObjects.Add(fridge);
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

        ToggleRoof();
        ToggleWalls();
    }
}