using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject winText;

    int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        SpawnEnimies();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount == 0){
            level++;
            if(level < 6){
                SpawnEnimies();
            }
            else {
                Time.timeScale = 0;
                winText.SetActive(true);
            }
        }
    }

    void SpawnEnimies(){
        Instantiate(enemy, new Vector3(0, 3.5f, 0), enemy.transform.rotation, transform);
        for (int i = 1; i <= level; i++){
            Instantiate(enemy, new Vector3(1.5f * i, 3.5f, 0), enemy.transform.rotation, transform);
            Instantiate(enemy, new Vector3(1.5f * i * -1, 3.5f, 0), enemy.transform.rotation, transform);
        }
        
    }
}
