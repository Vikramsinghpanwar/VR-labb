using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlameStop : MonoBehaviour
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
        StopFlame();
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

    public void StopFlame()
    {
        pslist[0].Stop();
        pslist[1].Stop();
        pslist[2].Stop();
        pslist[3].Stop();
        pslist[4].Stop();
        pslist[5].Stop();
        pslist[6].Stop();
        pslist[7].Stop();
        pslist[8].Stop();
        pslist[9].Stop();
        pslist[10].Stop();
        pslist[11].Stop();
    }
}

