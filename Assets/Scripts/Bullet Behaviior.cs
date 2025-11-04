using UnityEngine;

public class BulletBehaviior : MonoBehaviour
{
    public float speedBullet = 0.0f; // швидкість польоту
    private Vector3 direction;        // напрямок руху
    private bool isFlying = false;    // чи запущена куля

    public void Flight(Vector3 where)
    {
        direction = where; // запам'ятати напрямок
        isFlying = true;
        Destroy(gameObject, 3f);      // знищити через 3 секунди
    }

    void Update()
    {
        if (isFlying)
        {
            Debug.Log(direction * speedBullet * Time.deltaTime);
            transform.position += direction * speedBullet * Time.deltaTime;
        }
    }
}
