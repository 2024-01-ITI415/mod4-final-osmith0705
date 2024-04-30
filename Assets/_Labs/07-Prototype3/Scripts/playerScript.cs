using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class playerScript : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public GameObject keyCounter;
    public GameObject timergo;
    private TextMeshProUGUI timer;
    private TextMeshProUGUI keyCountText;
    private float stats = 0f;

    public GameObject winScreent;
    private TextMeshProUGUI winScreenText;

    public int keyCount = 0;
    public float countDown = 300f;

    public GameObject noEntryCanvas;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Key"))
        {
            source.PlayOneShot(clip);
            other.gameObject.SetActive(false);
            keyCount++;
            print(keyCount);

            keyCountText.text = "Keys: " + keyCount + "/4";
        }
        else
        {
            noEntryCanvas.SetActive(true);

            Invoke("destroyCanvas", 3f);
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            winScreent.SetActive(true);
            winScreenText.text = "You win. It took you" + stats + "seconds";
        }
    }
    public void destroyCanvas()
    {
        noEntryCanvas.SetActive(false);
    }
    void Update()
    {
        double countdownRound = System.Math.Round(countDown);
        float mins = Mathf.FloorToInt(countDown / 60);
        float sec = Mathf.FloorToInt(countDown % 60);
        string minutes = mins.ToString();
        string seconds = sec.ToString();
        timer = timergo.GetComponent<TextMeshProUGUI>();
        if (countdownRound > 0)
        {
            countDown -= Time.deltaTime;
            timer.text = minutes + ":" + seconds;
        }
        stats += Time.deltaTime;
        if (countDown <= 0)
        {
            winScreent.SetActive(true);
            winScreenText.text = "You Lose. You Collected " + keyCount + " keys and didn't finish the level";
        }
    }
    private void Start()
    {
        winScreenText = winScreent.GetComponent<TextMeshProUGUI>();
        keyCountText = keyCounter.GetComponent<TextMeshProUGUI>();
        keyCountText.text = "Keys: " + keyCount + "/4";
    }
}
