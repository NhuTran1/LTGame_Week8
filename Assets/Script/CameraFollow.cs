using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Kéo object Airplane vào đây
    public Vector3 offset = new Vector3(0f, 10f, -30f); // Khoảng cách camera so với máy bay
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;

        // Tính toán vị trí mong muốn của camera
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        
        // Làm mượt chuyển động của camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Camera luôn nhìn về phía máy bay
        transform.LookAt(target);
    }
}