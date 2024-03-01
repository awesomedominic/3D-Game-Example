using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup sceneCover;
    public Button startButton;

    [SerializeField] private bool _fadeIn;
    [SerializeField] private bool _fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_fadeIn)
        {
            if(sceneCover.alpha < 1)
            {
                sceneCover.alpha += Time.deltaTime;
                if(sceneCover.alpha >= 1)
                {
                    _fadeIn = false;
                }
            }
        }

        if(_fadeOut)
        {
            if(sceneCover.alpha >= 0)
            {
                sceneCover.alpha -= Time.deltaTime;
                if(sceneCover.alpha == 0)
                {
                    _fadeOut = false;
                    startButton.gameObject.SetActive(false);
                }
            }
        }


    }

    public void FadeInUI()
    {
        //sceneCover.alpha = 0;
        _fadeIn = true;
    }

    public void FadeOutUI()
    {
        //sceneCover.alpha = 1;
        _fadeOut = true;
        GameObject.Find("UI Object").GetComponent<Timer>().StartGameTimer();
    }

    public void EndGame()
    {
    
    }
}
