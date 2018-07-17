using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class fixPanel : MonoBehaviour {

    public GameObject ErrorPane;
    public GameObject refreshButton;
    public GameObject cameraButton;
    public GameObject titleBar;
    public GameObject qualityMeter;
    public GameObject scoreText;


    private string s = "";
    private bool onOff = false;

	// Use this for initialization
	void Start () {
        s = SceneManager.GetActiveScene().name;
        refreshButton.SetActive(false);
        scoreText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (DefaultTrackableEventHandler.trueFalse==true)
        {
            ErrorPane.SetActive(false);
            cameraButton.SetActive(false);
            titleBar.SetActive(false);
            qualityMeter.SetActive(false);
            refreshButton.SetActive(true);
            scoreText.SetActive(true);
        }
       
	}

    public void refresh()
    {
        SceneManager.LoadScene(s);
    }

    public void toogleFlash()
    {
        if(onOff==false)
        {
            CameraDevice.Instance.SetFlashTorchMode(true);
            onOff = true;
        }
        else
        {
            CameraDevice.Instance.SetFlashTorchMode(false);
            onOff = false;
        }
    }
}
