using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
        if(timer > fireRate){
            GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            BulletController bulletController = newBullet.GetComponent<BulletController>();
            bulletController.direction = 180;
            bulletController.type = BulletType.EnemyBullet;
            
            timer = 0;
            timer += Random.Range(-1.0f, 1.0f);
        }
        
    }

    public void OnHit(){
        HighscoreContoller.score += 50;
        Destroy(gameObject);
    }
}
