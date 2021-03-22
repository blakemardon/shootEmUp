using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType{
    PlayerBullet,
    EnemyBullet
}

public class BulletController : MonoBehaviour
{
    public int direction = 0;
    public int speed;
    public BulletType type;

    private Vector3 vectorDirection;
    // Start is called before the first frame update
    void Start()
    {
        vectorDirection = Quaternion.Euler(new Vector3(0,0,direction)) * new Vector3(0, 1, 0);
        gameObject.transform.Rotate(new Vector3(0,0,direction));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vectorDirection * Time.deltaTime * speed;
        if(transform.position.x > 25 || transform.position.x < -25){
            Destroy(gameObject);
        }
        if (transform.position.y > 25 || transform.position.y < -25)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(type == BulletType.PlayerBullet){
            EnemyController enemy;
            if (collider.gameObject.TryGetComponent<EnemyController>(out enemy)){
                enemy.OnHit();
                Destroy(gameObject);
            }
        }
        else if(type == BulletType.EnemyBullet){
            PlayerController player;
            if (collider.gameObject.TryGetComponent<PlayerController>(out player)){
                player.OnHit();
                Destroy(gameObject);
            }
        }
    }
}
