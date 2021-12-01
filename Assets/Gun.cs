using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Animator animator;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletPerTap;
    public bool allowedButtonHold;
    
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    private void Awake() 
    {
        // Set magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;        
    }

    private void Update() 
    {
        MyInput();
        
    }

    void MyInput()
    {
        //Check input 'can gun hold left click or not'
        if (allowedButtonHold)
            shooting = Input.GetKey(KeyCode.Mouse0);
        else
            shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0 && !PauseBehaviour.isPaused)
        {
            bulletsShot = 0;
            Shoot();
            animator.SetBool("isShooting", shooting);
        }
    }

    private void Shoot()
    {
        readyToShoot = false;


        //Set raycast for hit position
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(.5f, .5f, 9));
        RaycastHit hit;

        //Check if hit
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }

        else
            //Set a far-away point if doesn't hit
            targetPoint = ray.GetPoint(75);

        //Get direction from attack -> target
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Get direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotate bullet to direction of shooting
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        
        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //If more than one bulletsPerTap repeat Shoot function
        if (bulletsShot < bulletPerTap && bulletsLeft > 0)
            Invoke ("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        //Allow shooting
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        //Invoke ReloadFinished
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
