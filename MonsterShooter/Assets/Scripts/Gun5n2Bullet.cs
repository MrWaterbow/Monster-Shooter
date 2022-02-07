using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun5n2Bullet : MonoBehaviour
{
    private GameObject player;
    private GameObject monsters;
 
    void Start()
    {
        player = GameObject.Find("Player2");
        monsters = GameObject.FindGameObjectWithTag("Monsters");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Monsters")
        {
            Explosion(col.gameObject);
            NewMonsters();
        }
    }

    private void Explosion(GameObject monstersCol)
    {
        
        Gun5n2Monsters monstersScript = monsters.GetComponent<Gun5n2Monsters>();
        if (monstersScript.hP <= 1)
        {
            for (int i = 0; i < 50; i = i + 1)
            {
                Debug.Log("Все работвет");
                GameObject monstersClone = Instantiate(monstersCol, monstersCol.transform.position, monstersCol.transform.rotation);
                Destroy(monstersClone.GetComponent<Gun5n2Monsters>());
                monstersClone.GetComponent<Rigidbody2D>().isKinematic = false;
                monstersClone.transform.tag = "Untagged";
                monstersClone.GetComponent<SpriteRenderer>().color = Color.white;
                monstersClone.GetComponent<CapsuleCollider2D>().enabled = true;
                monstersClone.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
                monstersClone.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0), ForceMode2D.Impulse);
                monstersClone.GetComponent<Rigidbody2D>().gravityScale = 1;
                Destroy(monstersClone, 5.0f);
                Destroy(monstersCol);
            }
        }
        
    }
    private void NewMonsters()
    {

        Gun5n2Monsters monstersScript = monsters.GetComponent<Gun5n2Monsters>();
        if (monstersScript.hP <= 1)
        {
            Gun5n2Player playerScript = player.GetComponent<Gun5n2Player>();
            GameObject monstersBig = Instantiate(playerScript.monsters[Random.Range(0, playerScript.monsters.Length)], new Vector3(Random.Range(-70.0f, 70.0f), -11.0f, 0), Quaternion.Euler(0, 0, 0));

        }
    }
}
