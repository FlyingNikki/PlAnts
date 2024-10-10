using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grid_InputManager : MonoBehaviour
{
    [Header("----------Refrences---------->")]
    [SerializeField] private Camera sceneCamera;
    [SerializeField] protected LayerMask placementMask;

    public event Action OnCliced;
    public event Action OnExit;

    protected Vector3 lastPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnCliced?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExit?.Invoke();
        }
    }

    public bool IsPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, placementMask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }
}
