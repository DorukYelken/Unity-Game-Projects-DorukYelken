using UnityEngine;

public class RTSStyleCameraControl : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;

    void Update()
    {
        PanCamera();
    }

    void PanCamera()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 movement = Vector3.zero;

        // Fare ekranın kenarlarına yaklaştığında kamera hareketi
        if (mousePosition.x <= panBorderThickness)
        {
            movement.x = -1;
        }
        else if (mousePosition.x >= Screen.width - panBorderThickness)
        {
            movement.x = 1;
        }

        if (mousePosition.y <= panBorderThickness)
        {
            movement.z = -1;
        }
        else if (mousePosition.y >= Screen.height - panBorderThickness)
        {
            movement.z = 1;
        }

        // Hareket vektörünü normalize et ve hız ile çarp
        movement.Normalize();
        movement *= panSpeed * Time.deltaTime;

        // Kamerayı hareket ettir
        transform.Translate(movement, Space.World);
    }
}

