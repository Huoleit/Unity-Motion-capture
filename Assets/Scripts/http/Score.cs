using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Use this for initialization
    public SendRecord sendRecord;
    public Text text;

    private int score;
    private int counter = 0;
	void Start () {
        score = 0;

    }
	
    public void Increase(int delta)
    {
        score += delta;
        counter += 1;
        text.text = "Score:" + score.ToString();

        if (counter >= 5)
        {
            sendRecord.Send("1", "200");
            counter = 0;

        }
    }
}
