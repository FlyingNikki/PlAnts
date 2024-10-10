using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator;
    [SerializeField] private GameObject cellIndicator;
    [SerializeField] private Grid_InputManager inputManager;
    [SerializeField] private Grid grid;
    [SerializeField] private ObjectDatabase_SO database;
    [SerializeField] private GameObject gridVisualization;

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
        inputManager.OnCliced += PlaceStructur;
        inputManager.OnExit += StopPlacment;
    }

    private void PlaceStructur()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }

        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        GameObject newObject = Instantiate(database.objectData[selectedObjectIndex].Perfab);
        newObject.transform.position = grid.CellToWorld(gridPosition);
    }

    private void StopPlacment()
    {
        selectedObjectIndex = -1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnCliced -= PlaceStructur;
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
}
