using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun5n2PanelControl : MonoBehaviour
{
    public RectTransform panelControl;
    public RectTransform buttonGun2;
    public RectTransform buttonGun3;
    public RectTransform buttonGun4;
    public RectTransform buttonBuyGun2;
    public RectTransform buttonBuyGun3;
    public RectTransform buttonBuyGun4;
    public Button menuButton;

    public void CorutineMenu()
    {
        StartCoroutine(MenuButton());
    }

    public void CorutineClose()
    {
        StartCoroutine(CloseButton());
    }

    public IEnumerator MenuButton()
    {
        panelControl.gameObject.SetActive(true);
        for (float i = 810.0f; i >= 100; i--)
        {
            panelControl.anchoredPosition = new Vector3(0, i, 0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        menuButton.GetComponent<Button>().interactable = false;
    }

    public IEnumerator CloseButton()
    {
        for (float i = 100; i <= 810; i++)
        {
            panelControl.anchoredPosition = new Vector3(0, i, 0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        panelControl.gameObject.SetActive(false);
        menuButton.GetComponent<Button>().interactable = true;
    }

    public void BuyGun2()
    {
        if(Gun5n2Monsters.score >= 5)
        {
            Gun5n2Monsters.score -= 5;
            buttonGun2.GetComponent<Button>().interactable = true;
            buttonBuyGun2.GetComponent<Button>().interactable = false;
            Gun5n2Monsters.scoreText.text = "Score: " + Gun5n2Monsters.score;
        }
    }
    public void BuyGun3()
    {
        if (Gun5n2Monsters.score >= 7)
        {
            Gun5n2Monsters.score -= 7;
            buttonGun3.GetComponent<Button>().interactable = true;
            buttonBuyGun3.GetComponent<Button>().interactable = false;
            Gun5n2Monsters.scoreText.text = "Score: " + Gun5n2Monsters.score;
        }
    }

    public void BuyGun4()
    {
        if (Gun5n2Monsters.score >= 10)
        {
            Gun5n2Monsters.score -= 10;
            buttonGun4.GetComponent<Button>().interactable = true;
            buttonBuyGun4.GetComponent<Button>().interactable = false;
            Gun5n2Monsters.scoreText.text = "Score: " + Gun5n2Monsters.score;
        }
    }
}
