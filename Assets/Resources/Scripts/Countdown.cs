using UnityEngine;

// Used for auto destroy gameObject e.g. explosion particle, death effect particle, item pickup
public class Countdown : MonoBehaviour
{
    public float delay;

    private void Awake()
    {
        // Invoke 'DelayDestroy' after a delay
        Invoke("DelayDestroy", delay);
    }

    void DelayDestroy()
    {
        Destroy(gameObject);
    }
}
