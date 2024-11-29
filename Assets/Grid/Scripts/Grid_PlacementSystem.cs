using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid_PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndicator;
    [SerializeField] GameObject cellIndicator;
    [SerializeField] private Grid_InputManager inputManager;
    [SerializeField] protected Grid grid;

    [Space]
    [SerializeField] private ObjectDatabase_SO database;
    [SerializeField] private GameObject gridVisualization;
    private int selectedObjectIndex = -1;

    private GridData spikePlant, poisenPlant;
    private Renderer previewRenderer;
    private List<GameObject> placedGameObject = new();

    private void Start()
    {
        StopPlacement();
        spikePlant = new();
        poisenPlant = new();
        previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        selectedObjectIndex = database.objectData.FindIndex(data => data.ID == ID);

        if (selectedObjectIndex < 0)
        {
            Debug.LogError($"NO ID FOUND {ID}!");
            return;
        }

        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);

        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        if (placementValidity == false)
            return;

        GameObject newObject = Instantiate(database.objectData[selectedObjectIndex].Perfab);
        newObject.transform.position = grid.CellToWorld(gridPosition);
        placedGameObject.Add(newObject);
        GridData selectedData = database.objectData[selectedObjectIndex].ID == 0 ? spikePlant : poisenPlant;
        selectedData.AddObjectAt(gridPosition, database.objectData[selectedObjectIndex].Size, database.objectData[selectedObjectIndex].ID, placedGameObject.Count - 1);
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = database.objectData[selectedObjectIndex].ID == 0 ? spikePlant : poisenPlant;

        return selectedData.CanPlaceObjectAt(gridPosition, database.objectData[selectedObjectIndex].Size);
    }

    private void StopPlacement()
    {
        selectedObjectIndex = -1;

        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);

        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
    }

    private void Update()
    {
        if (selectedObjectIndex < 0)
            return;

        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        previewRenderer.material.color = placementValidity ? Color.green : Color.red;

        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
