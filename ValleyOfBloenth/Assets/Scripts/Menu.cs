using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Button playBtn;
    public Button quitBtn;

    Animator anim;
    bool wait;//want to set load level to go after animations
    void Awake()
    {
        //setting up animator and buttons
        anim = GetComponent<Animator>();
        playBtn.onClick.AddListener(() => { ButtonClicked(0); });
        quitBtn.onClick.AddListener(() => { ButtonClicked(1); });
    }

    private void ButtonClicked(int btn)
    {
        switch (btn)
        {
            case 0:
                anim.SetTrigger("Play");
                Debug.Log("Play Animations");
                //want to set load level to go after animations
                Application.LoadLevel(1);
                break;
            case 1:
                Application.Quit();
                break;
            default:
                Debug.Log("Btn clicked Nope");
                break;
        }
    }

}
