using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    [Header("Stats")]
    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;

    [Header("Damage")]
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;

    [Header("Lifetime")]
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physcisMat;

    private void Start() {
        Setup();
    }

    private void Update() {

        // Explode if collide more than max
        if (collisions >= maxCollisions) EffectExplode();
        
        // Explode if doesn't hit anyting for 'maxLifetime' amount of time
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Invoke("Destroy", 0.05f);
    }

    // Method for explode effect
    void EffectExplode()
    {
        // Audio SFX
        FindObjectOfType<AudioManager>().Play("ProjectileHit");
        
        // Instatiate explosion game object
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
        
        Destroy();
        return;
    }

    void Explode()
    {
        // Audio
        FindObjectOfType<AudioManager>().Play("ProjectileHit");
        
        // Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        // Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            // Get component of enemy and call Take Damage
            enemies[i].GetComponent<EnemyHealth>().TakeDamage(explosionDamage);
        }

        // Destroy game object with a delay
        Invoke("Destroy", 0.01f);
    }

    void Destroy()
    {
        Destroy(gameObject);
        return;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        // Collision counter
        collisions++;

        // Check if collide with 'enemy'
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) 
        {
            Explode(); 
        }
        
    }

    void Setup()
    {
        // Create new physic material
        physcisMat = new PhysicMaterial();
        // physcisMat.bounciness = bounciness;
        physcisMat.frictionCombine = PhysicMaterialCombine.Minimum;
        physcisMat.bounceCombine = PhysicMaterialCombine.Maximum;

        // Set material to collider
        GetComponent<SphereCollider>().material = physcisMat;

        // Set gravity
        rb.useGravity = useGravity;
    }
}
