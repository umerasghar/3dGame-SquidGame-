using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowThirdPerson : MonoBehaviour
{
    public float cameraMoveSensitvity;
    float mouseX, mouseY;
    public Transform playerTransform;
    private Vector3 distanceFromPlayer;
    public  Transform cameraAnchor;
    // Start is called before the first frame update
    void Start()
    {
        distanceFromPlayer = cameraAnchor.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        FollowCamera();
    }
    void FollowCamera()
    {
        mouseX += Input.GetAxis("Mouse X") * cameraMoveSensitvity;
        mouseY -= Input.GetAxis("Mouse Y") * cameraMoveSensitvity;
        mouseY = Mathf.Clamp(mouseY, -35, 60);
        this.transform.LookAt(cameraAnchor);
        cameraAnchor.position = playerTransform.position + distanceFromPlayer;
        // followCam.transform.position = playerTransform.position + distanceFromPlayer;
        cameraAnchor.rotation = Quaternion.Euler(mouseY, mouseX, 0);

    }
}
