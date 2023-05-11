using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopBurnerBTN : MonoBehaviour
{
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

    public void StopBurner()
    {
        ParticleSystemm.Stop();
    }
}
