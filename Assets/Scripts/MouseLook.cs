using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform playerBody;

    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float maxAngle = 60f;
    
    private float _xRotation;

    private void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate () {
        var mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        var mouseY = Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp (_xRotation, -maxAngle, maxAngle);
        playerHead.localRotation = Quaternion.Euler (_xRotation, 0f, 0f);
        playerBody.Rotate (Vector3.up * mouseX);
    }
}
