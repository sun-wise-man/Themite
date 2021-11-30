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
        if (collisions >= maxCollisions) EffectExplode();
        
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Invoke("Delay", 0.05f);
    }

    void EffectExplode()
    {
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
        Delay();
    }

    void Explode()
    {
        //Debug.Log("Hit!");
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call Take Damage
            enemies[i].GetComponent<EnemyHealth>().TakeDamage(explosionDamage);
        }

        Invoke("Delay", 0.01f);
    }

    void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        collisions++;

        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) 
        {
            Explode(); 
        }
        
    }

    void Setup()
    {
        //Create new physic material
        physcisMat = new PhysicMaterial();
        //physcisMat.bounciness = bounciness;
        physcisMat.frictionCombine = PhysicMaterialCombine.Minimum;
        physcisMat.bounceCombine = PhysicMaterialCombine.Maximum;

        //Set material to collider
        GetComponent<SphereCollider>().material = physcisMat;

        //Set gravity
        rb.useGravity = useGravity;
    }
    
    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, explosionRange);
    // }
}
