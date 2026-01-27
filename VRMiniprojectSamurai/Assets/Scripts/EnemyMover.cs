using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [Tooltip("Speed at which the object moves toward the player.")]
    public float moveSpeed = 2f;

    [Tooltip("How close before the object stops or disappears.")]
    public float stopDistance = 0.2f;

    private Transform player;

    void Start()
    {
        // Try to find the XR Rig or MainCamera (for Meta Quest)
        Camera mainCam = Camera.main;
        if (mainCam != null)
            player = mainCam.transform;  // Player head/camera as target
        else
            Debug.LogWarning("MoveToPlayer: No Main Camera found!");
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(player); // Optional: face player
        }
        else
        {
            // Optional: destroy or trigger effect when reaching player
            Destroy(gameObject);
        }
    }
}
