using UnityEngine;

public class CountdownScript : MonoBehaviour
{
    public float countdown;

    private void Awake() {
        Invoke("Delay", countdown);
    }

    void Delay(){
        Destroy(gameObject);
    }
}
