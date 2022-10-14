using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float zoomedInFOV = 80f;
    float zoomedOutFOV;
    [SerializeField] float zoomedInSensitivity = 1.9f;
    float zoomedOutSensitivity;
    bool isZoomedIn = false;
    RigidbodyFirstPersonController playerController;

    private void Awake()
    {
        zoomedOutFOV = playerCamera.fieldOfView;
        zoomedOutSensitivity = playerController.mouseLook.XSensitivity;
        playerController = GetComponent<RigidbodyFirstPersonController>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomedIn)
            {
                HandleZoom(false, zoomedOutFOV, zoomedOutSensitivity);
            }
            else
            {
                HandleZoom(true, zoomedInFOV, zoomedInSensitivity);
            }
        }
    }

    private void HandleZoom(bool zoomToggle, float fov, float sensitivity)
    {
        isZoomedIn = zoomToggle;
        playerCamera.fieldOfView = fov;
        playerController.mouseLook.XSensitivity = sensitivity;
        playerController.mouseLook.YSensitivity = sensitivity;
    }
}
