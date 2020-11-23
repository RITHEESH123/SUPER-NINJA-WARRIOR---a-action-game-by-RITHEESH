using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaitBeforeAttackingAgain : MonoBehaviour
{
    public int waitTime;
    private int fadeTime;

    private Text waitText;

    private Image fadeImg;

    private bool canFade;

    private GameObject waitBeforeAttackingPanel;

    // Start is called before the first frame update
    void Awake()
    {
        waitBeforeAttackingPanel = transform.GetChild(0).gameObject;

        waitText = waitBeforeAttackingPanel.GetComponentInChildren<Text>();
        waitText.text = waitTime.ToString();

        fadeImg = waitBeforeAttackingPanel.GetComponent<Image>();

        fadeTime = waitTime;

        waitBeforeAttackingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FadeOut();
    }

    public void ActivateFadeOut()
    {
        waitBeforeAttackingPanel.SetActive(true);
        waitText.text = waitTime.ToString();
        Color temp = fadeImg.color;
        temp.a = 1f;
        fadeImg.color = temp;
        StartCoroutine(CountDown());
    }

    void FadeOut()
    {
        if (canFade)
        {
            Color temp = fadeImg.color;
            temp.a -= (Time.deltaTime / fadeTime) / 2f;
            fadeImg.color = temp;
        }
    }

    IEnumerator CountDown()
    {
        canFade = true;
        yield return new WaitForSeconds(1);
        waitTime -= 1;

        if (waitTime != -1)
        {
            waitText.text = waitTime.ToString();
            StartCoroutine(CountDown());
        }
        else
        {
            waitTime = fadeTime;
            waitBeforeAttackingPanel.SetActive(false);
        }
    }

}
