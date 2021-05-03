using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject healthDisplay;
    public GameObject gameOvertext;
    public GameObject bullet;
    public double speed;
    public double fireRate;

    int health = 3;
    double fireTimer = 0;
    public void OnHit()
    {
        LoseHealth();
    }

    void LoseHealth(){
        
        if (health == 0){
            Time.timeScale = 0;
            gameOvertext.SetActive(true);
        }
        else{
            health -= 1;
            Destroy(healthDisplay.transform.GetChild(0).gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        movement.x += Input.GetAxisRaw("Horizontal");
        movement.y += Input.GetAxisRaw("Vertical");
        movement.Normalize();
        transform.position += movement * (float)Time.deltaTime * (float)speed;

        fireTimer += Time.deltaTime;
        if(Input.GetAxisRaw("Jump") == 1){
            if(fireTimer > fireRate){
                GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                BulletController bulletController = newBullet.GetComponent<BulletController>();
                bulletController.type = BulletType.PlayerBullet;
                fireTimer = 0;
            }
        }
    }
}
