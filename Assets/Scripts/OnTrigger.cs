using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTrigger : MonoBehaviour
{

    private int count;
    public Text StarCountText;
    public AudioSource soundClip;

    void Start()
    {
        StarCountText.GetComponent<Text>();
        soundClip.GetComponent<AudioSource>();

        count = 0;
        setCountToText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            count = count + 1;
            playSoundClip();
            setCountToText();
        }
    }

    private void setCountToText()
    {
        StarCountText.text = "SCore:  " + count.ToString();
    }

    private void playSoundClip()
    {
        soundClip.Play();
    }
}
