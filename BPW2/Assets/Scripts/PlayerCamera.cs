using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float rotation = 0;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float cameraSpeed = 200;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime;

        rotation -= mouseY;

        float rotationY = transform.localEulerAngles.y;
        rotation = Mathf.Clamp(rotation, -90f, 90f);


        transform.localEulerAngles = new Vector3(rotation, rotationY, 0f);
        player.Rotate(0, mouseX, 0);
    }
}
