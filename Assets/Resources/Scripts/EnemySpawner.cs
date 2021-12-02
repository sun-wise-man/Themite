using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;

    // Set 'x' axis range
    [Header("Range X")]
    public float rangeX;

    // Set 'y' axis range
    [Header("Range y")]
    public float rangeY;

    // Set 'z' axis range
    [Header("Range z")]
    public float rangeZ;
    
    float xPos;
    float yPos;
    float zPos;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            // Randomize range
            xPos = Random.Range((transform.position.x - rangeX), (transform.position.x + rangeX));
            yPos = Random.Range((transform.position.y - rangeY), (transform.position.y + rangeY));
            zPos = Random.Range((transform.position.z - rangeZ), (transform.position.z + rangeZ));

            // Instatiate enemy in cuboid shape
            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, rangeX);
        Gizmos.DrawWireSphere(this.transform.position, rangeY);
        Gizmos.DrawWireSphere(this.transform.position, rangeZ);
    }
}
