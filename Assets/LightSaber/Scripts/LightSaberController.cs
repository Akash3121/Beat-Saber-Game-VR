using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberController : MonoBehaviour
{
    public AudioClip blandeOnSound;
    public AudioClip blandeOffSound;

    public enum Hand { LEFT, RIGHT };
    public Hand hand = Hand.RIGHT;

    private AudioSource audioSource;
    private GameObject blade;
    private bool isBladeOn = false;

    // Start is called before the first frame update
    void Start()
    {
        blade = transform.Find("blade").gameObject;
        blade.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((hand == Hand.RIGHT && OVRInput.GetDown(OVRInput.RawButton.A)) ||
           (hand == Hand.LEFT && OVRInput.GetDown(OVRInput.RawButton.X))   ||
           Input.GetKeyDown(KeyCode.Space))
        {
            if (isBladeOn)
            {
                TurnBladeOff();
            }
            else
            {
                TurnBladeOn();
            }
        }
    }

    void TurnBladeOn()
    {
        blade.SetActive(true);
        isBladeOn = true;

        audioSource.clip = blandeOnSound;
        audioSource.Play();
    }

    void TurnBladeOff()
    {
        blade.SetActive(false);
        isBladeOn = false;

        audioSource.clip = blandeOffSound;
        audioSource.Play();
    }
}
