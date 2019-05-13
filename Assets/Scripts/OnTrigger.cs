using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTrigger : MonoBehaviour
{
    public Text StarCountText;
    public AudioSource soundClip;

    void Start()
    {
        StarCountText.GetComponent<Text>();
        soundClip.GetComponent<AudioSource>();

        Points.playerPoints = 0;
        setCountToText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Points.playerPoints += 1;
            playSoundClip();
            setCountToText();
        }
    }

    private void setCountToText()
    {
        StarCountText.text = "Score:  " + Points.playerPoints.ToString();
    }

    private void playSoundClip()
    {
        soundClip.Play();
    }
}
