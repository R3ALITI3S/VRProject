using UnityEngine;

public class Fruit : MonoBehaviour
{
    public ParticleSystem sliceEffect;
    public int scoreValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Katana"))
        {
            Slice();
        }
        else if (collision.collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }


    void Slice()
    {
        // Spawn particle effect
        if (sliceEffect != null)
        {
            ParticleSystem effect = Instantiate(sliceEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration); // Destroy particle after it finishes
        }

        // Update score
        GameManager.Instance.AddScore(scoreValue);

        // Destroy the fruit
        Destroy(gameObject);
    }
}