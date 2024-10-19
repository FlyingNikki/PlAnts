using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid_PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private GameObject cellIndicator;
    [SerializeField] private Grid_InputManager inputManager;
    [SerializeField] private Grid grid;
    [SerializeField] private ObjectDatabase_SO database;
    [SerializeField] private GameObject gridVisualization;
    [SerializeField] private LayerMask objectLayer;

    private int selectedObjectIndex = -1;

    private void Start()
    {
        StopPlacment();
    }

    public void StartPlacement(int ID)
    {
        StopPlacment();
        selectedObjectIndex = database.objectData.FindIndex(data => data.ID == ID);
        if (selectedObjectIndex < 0)
        {
            Debug.LogError($"NO ID FOUND {ID}");
            return;
        }
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnCliced += PlacesStructure;
        inputManager.OnExit += StopPlacment;
    }

    private void PlacesStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }

        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        Vector3 worldPosition = grid.CellToWorld(gridPosition);

        // Check if the placement position is valid
        if (!IsValidPlacement(worldPosition))
        {
            Debug.LogWarning("Invalid placement");
            return;
        }

        // Place the object
        GameObject newObject = Instantiate(database.objectData[selectedObjectIndex].Perfab);
        newObject.transform.position = worldPosition;
    }

    private void StopPlacment()
    {
        selectedObjectIndex = -1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnCliced -= PlacesStructure;
        inputManager.OnExit -= StopPlacment;
    }

    private void Update()
    {
        if (selectedObjectIndex < 0)
            return;

        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        mouseIndicator.transform.position = mousePos;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

    private bool IsValidPlacement(Vector3 positon)
    {
        if (IsOnccupied(positon))
        {
            Debug.LogWarning("Space is already occupied");
            return false;
        }

        return true;
    }

    private bool IsOnccupied(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapBox(position, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, objectLayer);
        return colliders.Length > 0;
    }
}
