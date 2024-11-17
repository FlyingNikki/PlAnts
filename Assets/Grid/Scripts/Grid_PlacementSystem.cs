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

    private void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPostion();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
