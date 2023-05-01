using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private int OnOrOff;
    private bool isOn =true;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        print(OnOrOff = PlayerPrefs.GetInt("OnOrOff"));
        if (isOn)
        {
            OnOrOff = 1;
        }
        if (!isOn)
        {
                OnOrOff = 0;          
        }
        soundOnImage = button.image.sprite;
        PlayerPrefs.SetInt("OnOrOff", OnOrOff);
        PlayerPrefs.Save();
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("OnOrOff", OnOrOff);
        PlayerPrefs.Save();
    }

    public void ButtonClicked()
    {
        if (isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            OnOrOff = 0;
            audioSource.mute = true;
        }
        else {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
            OnOrOff = 1;

        }
        PlayerPrefs.SetInt("OnOrOff", OnOrOff);
    }
}
