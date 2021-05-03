using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreContoller : MonoBehaviour
{
    public static int score = 0;
    int localScore;
    Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = gameObject.GetComponent<Text>();
        localScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(localScore != HighscoreContoller.score){
            highscore.text = highscore.text.Remove(6);
            localScore = HighscoreContoller.score;
            highscore.text = highscore.text + localScore;
        }
    }
}
