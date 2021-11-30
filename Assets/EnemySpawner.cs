using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;

    [Header("Range X")]
    public float radX;

    [Header("Range y")]
    public float radY;

    [Header("Range z")]
    public float radZ;
    
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
            xPos = Random.Range((transform.position.x - radX), (transform.position.x + radX));
            yPos = Random.Range((transform.position.y - radY), (transform.position.y + radY));
            zPos = Random.Range((transform.position.z - radY), (transform.position.z + radY));

            Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radX);
        Gizmos.DrawWireSphere(this.transform.position, radY);
        Gizmos.DrawWireSphere(this.transform.position, radZ);
    }
}
