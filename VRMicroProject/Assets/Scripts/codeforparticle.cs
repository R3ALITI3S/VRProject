using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
public class codeforparticle : MonoBehaviour
{
    public GameObject ammoPrefab;   
    public Transform spawnPoint;   

    private void Start()
    {
        // Get the XRSimpleInteractable component on this GameObject
        GetComponent<XRSimpleInteractable>()
            // Event triggered when the object is selected (pressed)
            .selectEntered
            // Register the OnPressed method as a listener
            .AddListener(OnPressed);
    }

    private void OnPressed(SelectEnterEventArgs args)
    {
        if (ammoPrefab != null && spawnPoint != null)
        {
            Instantiate(ammoPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
