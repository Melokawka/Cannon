using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cannon; 
    public GameObject cannonBody; 
    public float horizontalRotationSpeed = 100f; // Speed of camera rotation
    public float verticalRotationSpeed = 100f; // Speed of camera rotation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        // Handle camera rotation
        float horizontalRotation = Input.GetAxis("Horizontal");
        float verticalRotation = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-verticalRotation, horizontalRotation, 0f) * horizontalRotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        // Handle cannon rotation
        float cannonHorizontalRotation = horizontalRotation * horizontalRotationSpeed * Time.deltaTime;
        //cannon.transform.Rotate(Vector3.up, cannonHorizontalRotation);
        cannonBody.transform.Rotate(Vector3.up, cannonHorizontalRotation);

        float cannonVerticalRotation = -verticalRotation * verticalRotationSpeed * Time.deltaTime;
        cannon.transform.Rotate(Vector3.forward, cannonVerticalRotation, Space.Self);
    }
}
