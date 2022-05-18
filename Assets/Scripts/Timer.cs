using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private bool finished = false;
    

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; // starts when application starts
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;

        float t = Time.time - startTime; // amount of time since timer has started

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;

    }

    public float getTime()
    {
        return Time.time - startTime;
    }
    public void Finish()
    {
        finished = true;
        timerText.color = Color.red;
    }
}
