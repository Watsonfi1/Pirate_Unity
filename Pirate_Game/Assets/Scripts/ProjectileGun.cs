using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour{
    public GameObject bullet;
    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;

    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    
    bool shooting, readyToShoot, reloading;

    public KeyCode shootKey = KeyCode.Mouse0;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    private void Awake(){
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update(){
        MyInput()
    }

    private void MyInput(){
        if (allowButtonHold) shooting = Input.GetKey(shootKey);
        else shooting = Input.GetKeyDown(shootKey);

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = 0

            Shoot();
        }

    }

    private void Shoot(){
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else 
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float x = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.poition, Quaternion.identity);

        currentBullet.transform.forward = directionWithSpread.normalized;
        

        bulletsLeft--;
        bulletsShot++;
    }

}
