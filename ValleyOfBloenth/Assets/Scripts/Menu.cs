﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Button playBtn;
    public Button quitBtn;
    public Button playFrom;

    Animator anim;
    void Awake()
    {
        //setting up animator and buttons
        anim = GetComponent<Animator>();
        playBtn.onClick.AddListener(() => { ButtonClicked(0); });
        quitBtn.onClick.AddListener(() => { ButtonClicked(1); });
        playFrom.onClick.AddListener(() => { ButtonClicked(2); });
    }
    //load levels or quit based on button clicked
    private void ButtonClicked(int btn)
    {
        switch (btn)
        {
            case 0:
                StartCoroutine("LoadingLevels");
                break;
            case 1:
                Application.Quit();
                break;
            case 2:
                Application.LoadLevel(GameManager.lastLevel);
                break;
            default:
                Debug.Log("Btn clicked Nope");
                break;
        }
    }
    //wait for animations before loading new level
    IEnumerator LoadingLevels()
    {
        anim.SetTrigger("Play");
        yield return new WaitForSeconds(.5f);
        Application.LoadLevel(1);
    }

}
