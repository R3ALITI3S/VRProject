using UnityEngine;

public class SwordSwingSound : MonoBehaviour
{
    [Header("Audio Settings")]
    [Tooltip("Audio source that will play the swing sounds.")]
    public AudioSource audioSource;

    [Tooltip("List of possible swing sounds.")]
    public AudioClip[] swingSounds;

    [Header("Swing Detection Settings")]
    [Tooltip("Minimum sword movement speed to trigger a swing sound.")]
    public float minSwingSpeed = 1.5f;

    [Tooltip("Cooldown time (in seconds) between swing sounds.")]
    public float swingCooldown = 0.4f;

    [Tooltip("Transform used to track sword movement (usually the sword itself).")]
    public Transform swordTransform;

    private Vector3 lastPosition;
    private float lastSwingTime;

    void Start()
    {
        if (swordTransform == null)
            swordTransform = transform; // Default to this GameObject

        lastPosition = swordTransform.position;
        lastSwingTime = -swingCooldown;
    }

    void Update()
    {
        // Calculate how fast the sword is moving
        Vector3 velocity = (swordTransform.position - lastPosition) / Time.deltaTime;
        float speed = velocity.magnitude;

        // If swinging fast enough and cooldown is finished, play a sound
        if (speed > minSwingSpeed && Time.time - lastSwingTime >= swingCooldown)
        {
            PlayRandomSwingSound();
            lastSwingTime = Time.time; // Reset cooldown timer
        }

        lastPosition = swordTransform.position;
    }

    void PlayRandomSwingSound()
    {
        if (audioSource == null || swingSounds.Length == 0)
            return;

        // 🎲 Randomly pick one swing sound
        AudioClip clip = swingSounds[Random.Range(0, swingSounds.Length)];

        // Play it once using PlayOneShot (so it doesn’t interrupt others)
        audioSource.PlayOneShot(clip);
    }
}
