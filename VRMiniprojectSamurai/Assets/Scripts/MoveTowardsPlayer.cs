using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform player; // player head transform
    public float speed = 1f;

    void Update()
    {
        if (player == null) return;

        // Move toward the player's position
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}