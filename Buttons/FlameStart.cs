using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlameStart : MonoBehaviour
{
    public List<ParticleSystem> pslist;

    public ParticleSystem ParticleSystemm;
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject presser;
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition -= new Vector3(0, 0.01f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition += new Vector3(0, 0.01f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void StartFlame()
    {
        pslist[0].Play();
        pslist[1].Play();
        pslist[2].Play();
        pslist[3].Play();
        pslist[4].Play();
        pslist[5].Play();
        pslist[6].Play();
        pslist[7].Play();
        pslist[8].Play();
        pslist[9].Play();
        pslist[10].Play();
        pslist[11].Play();
    }
}
