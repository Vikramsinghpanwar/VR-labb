using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainTvUI : MonoBehaviour
{
    public GameObject menuPannel, welcomePannel, chemicalPannel, InstrumentsPannel, ManualPannel;
    private void Start()
    {
        chemicalPannel.SetActive(false);
        menuPannel.SetActive(false);
        welcomePannel.SetActive(true);
        InstrumentsPannel.SetActive(false);
        ManualPannel.SetActive(false);
    }

    // Start is called before the first frame update
    public void Continue()
    {
        chemicalPannel.SetActive(false);
        menuPannel.SetActive(true);
        welcomePannel.SetActive(false);
        InstrumentsPannel.SetActive(false);
        ManualPannel.SetActive(false);
    }

    public void ChemicalEquations()
    {
        chemicalPannel.SetActive(true);
        menuPannel.SetActive(false);
        welcomePannel.SetActive(false);
        InstrumentsPannel.SetActive(false);
        ManualPannel.SetActive(false);
    }

    public void Instruments()
    {
        chemicalPannel.SetActive(false);
        menuPannel.SetActive(false);
        welcomePannel.SetActive(false);
        InstrumentsPannel.SetActive(true);
        ManualPannel.SetActive(false);
    }

    public void Manual()
    {
        chemicalPannel.SetActive(false);
        menuPannel.SetActive(false);
        welcomePannel.SetActive(false);
        InstrumentsPannel.SetActive(false);
        ManualPannel.SetActive(true);
    }



    public void Back1()
    {
        menuPannel.SetActive(false);
    }
    public void Restartt()
    {
        SceneManager.LoadScene("Main_scene");
    }
}
