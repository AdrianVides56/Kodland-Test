using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSense;
    [SerializeField] private Transform player, cameraRef;

    [SerializeField] private float xAxisClamp = 45;
    
    float rotateX, rotateY;
    Vector3 rotPlayer, rotCamera; 

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rotPlayer = player.rotation.eulerAngles;
        rotCamera = cameraRef.eulerAngles;

        if (mouseSense <= 0)
            mouseSense = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rotateX = Input.GetAxis("Mouse X") * mouseSense;
        rotateY = Input.GetAxis("Mouse Y") * mouseSense;

        rotPlayer.y += rotateX;

        rotCamera.y += rotateX;
        rotCamera.x -= rotateY;

        rotCamera.x = Mathf.Clamp(rotCamera.x, -xAxisClamp, xAxisClamp);

        player.rotation = Quaternion.Euler(rotPlayer);
        cameraRef.rotation = Quaternion.Euler(rotCamera);
    }
}
