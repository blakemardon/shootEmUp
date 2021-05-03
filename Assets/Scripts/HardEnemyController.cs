using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyController : MonoBehaviour
{
    public GameObject bullet;
    public double fireRate;

    double timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(-1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            GameObject newBullet1 = Instantiate(bullet, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            BulletController bulletController1 = newBullet1.GetComponent<BulletController>();
            bulletController1.direction = 180;
            bulletController1.type = BulletType.EnemyBullet;

            GameObject newBullet2 = Instantiate(bullet, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            BulletController bulletController2 = newBullet2.GetComponent<BulletController>();
            bulletController2.direction = 135;
            bulletController2.type = BulletType.EnemyBullet;

            GameObject newBullet3 = Instantiate(bullet, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            BulletController bulletController3 = newBullet3.GetComponent<BulletController>();
            bulletController3.direction = 225;
            bulletController3.type = BulletType.EnemyBullet;

            timer = 0;
            timer += Random.Range(-1.0f, 1.0f);
        }

    }

    public void OnHit()
    {
        HighscoreContoller.score += 100;
        Destroy(gameObject);
    }
}
