using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Camera playerCamera;
    public PlayerController playerController;
    private AudioSource shootSound;
    public float waitTime = 0.3f;

    private float nextFireTime = 0f;
    bool a = false;
    Vector3 direction;
    void Start()
    {

        shootSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1) && Time.time >= nextFireTime && playerController.speed == 0.0f)
        {
            Shoot1();
            nextFireTime = Time.time + waitTime;
        }
    }
    IEnumerator ShootCoroutine()
    {
        playerController.anim.SetBool("IsShoot", true);
        yield return new WaitForSeconds(0.2f);
        playerController.anim.SetBool("IsShoot", false);
    }
    void Shoot1()
    {
        StartCoroutine(ShootCoroutine());
        // 1️⃣ Створюємо промінь
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 5f);


        RaycastHit hit;
        Vector3 targetPoint;
        int mask = ~LayerMask.GetMask("Player"); // усі шари, КРІМ "Player"

        if (Physics.Raycast(ray, out hit, 4000f, mask, QueryTriggerInteraction.Ignore))
{
            targetPoint = hit.point;
            Debug.DrawLine(transform.position, hit.point,Color.blue, 5f);
            Debug.Log("I hit" + hit.collider.name);
}

      
        else
            targetPoint = playerCamera.transform.position + playerCamera.transform.forward * 4000;


        // 2️⃣ Точка пострілу
        Vector3 firePoint = transform.position + new Vector3(0.1f, 0, 0);


        // 4️⃣ Обчислюємо напрямок
        // Debug.DrawLine(firePoint, targetPoint,Color.blue, 5f);
        direction = (targetPoint - firePoint).normalized;

        a = true;

        GameObject newBullet = Instantiate(bullet, firePoint, transform.rotation);

        // отримуємо компонент BulletBehavior з цієї кулі
        BulletBehaviior bulletBehavior = newBullet.GetComponent<BulletBehaviior>();

        // перевіряємо, чи він справді є, і тільки тоді викликаємо
        if (bulletBehavior != null)
        {

            bulletBehavior.Flight(direction);
        }


        // 6️⃣ Звук
        shootSound.Play();
    }
    void OnDrawGizmos()
    {
        if(a == false)
        {
            return;
        }
        Gizmos.DrawLine(transform.position, direction);
}
}

