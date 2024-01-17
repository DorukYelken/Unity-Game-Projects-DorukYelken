using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 2.0f;
    public float distance = 6.0f; // Kamera ile hedef arasındaki mesafe
    public float height = 2.0f;   // Kamera yüksekliği

    // Boş nesne (empty GameObject) referansı
    private GameObject pivot;

    void Start()
    {
        // Boş nesneyi oluştur ve karaktere bağla
        pivot = new GameObject("CameraPivot");
        pivot.transform.position = target.position;
        pivot.transform.rotation = target.rotation; // Karakterin rotasyonunu kameraya uygula
        transform.SetParent(pivot.transform);

        // Başlangıçta rotasyonu sıfırla
        Quaternion startRotation = Quaternion.Euler(18, 0, 0);
        pivot.transform.rotation = startRotation;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Karakterin etrafında yatay rotasyon
        pivot.transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Dikey rotasyon sadece kamera üzerinde etkili olacak
        pivot.transform.Rotate(Vector3.left * mouseY * rotationSpeed);

        // Kamera rotasyonunu güncelle
        float currentRotationAngleY = pivot.transform.eulerAngles.y;
        float newRotationAngleY = Mathf.LerpAngle(currentRotationAngleY, currentRotationAngleY + mouseX * rotationSpeed, rotationSpeed * Time.deltaTime);

        float currentRotationAngleX = pivot.transform.eulerAngles.x;
        float newRotationAngleX = Mathf.LerpAngle(currentRotationAngleX, currentRotationAngleX - mouseY * rotationSpeed, rotationSpeed * Time.deltaTime);

        // Sadece x ve y ekseninde rotasyon ekleniyor
        Quaternion newRotation = Quaternion.Euler(newRotationAngleX, newRotationAngleY, 0);

        // Kamerayı güncelle
        pivot.transform.rotation = newRotation;

        // Kameranın pozisyonunu güncelle
        transform.position = target.position - pivot.transform.forward * distance;
        transform.position += Vector3.up * height;
    }
}


