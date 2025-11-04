using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 300f;      // чутливість миші
    public Transform playerBody;          // об’єкт тіла гравця (Capsule, Player тощо)

    private float xRotation = 0f;         // вертикальний кут

    private float nextFireTime = 0f;

    void Start()
    {
        // Ховаємо курсор і фіксуємо його в центрі екрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Update()
    {
        // Рух миші
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Обчислюємо нахил камери по вертикалі
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Обертаємо камеру вгору-вниз
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Обертаємо тіло гравця (тобто Player) по горизонталі
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
