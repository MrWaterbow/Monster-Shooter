using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun5n2ButtonInventor : MonoBehaviour
{
    public GameObject panelInventor;
    public GameObject player;
    public RectTransform buttonGun2;
    public RectTransform buttonGun3;
    public RectTransform buttonGun4;

    private void OnMouseDown()
    {
        StartCoroutine(InventorButtonUp());
        StartCoroutine(InventorButtonDown());
    }

    public void BuyGun2()
    {
        if (Gun5n2Monsters.score >= 5)
        {
            Gun5n2Monsters.score -= 5;
            buttonGun2.GetComponent<Button>().interactable = true;
            Gun5n2Monsters.scoreText.text = "Score: " + Gun5n2Monsters.score;
        }
    }

    public void BuyGun3()
    {
        if (Gun5n2Monsters.score >= 7)
        {
            Gun5n2Monsters.score -= 7;
            buttonGun3.GetComponent<Button>().interactable = true;
            Gun5n2Monsters.scoreText.text = "Score: " + Gun5n2Monsters.score;
        }
    }

    public void BuyGun4()
    {
        if (Gun5n2Monsters.score >= 10)
        {
            Gun5n2Monsters.score -= 10;
            buttonGun4.GetComponent<Button>().interactable = true;
            Gun5n2Monsters.scoreText.text = "Score: " + Gun5n2Monsters.score;
        }
    }

    public IEnumerator InventorButtonUp()
    {
        if(panelInventor.transform.position.y <= -30.0f)
        {
            
            for (float i = -30.0f; i <= -12.0f; i++)
            {
                panelInventor.transform.position = new Vector3(player.transform.position.x, i, 0);
                yield return new WaitForSeconds(Time.deltaTime * 10);
            }
        }
    }
    public IEnumerator InventorButtonDown()
    {
        if (panelInventor.transform.position.y >= -12.0f)
        {

            for (float i = -12.0f; i >= -30.0f; i--)
            {
                panelInventor.transform.position = new Vector3(player.transform.position.x, i,0 );
                yield return new WaitForSeconds(Time.deltaTime * 10);
            }
        }
    }

}
