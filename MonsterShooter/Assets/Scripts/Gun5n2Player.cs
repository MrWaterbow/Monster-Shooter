using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun5n2Player : MonoBehaviour
{
    public GameObject bullet;
    private GameObject shootSideRight;
    private GameObject shootSideLeft;
    private GameObject leftHandDuck;
    private GameObject rightHandDuck;
    public GameObject man;
    private GameObject gun;
    public GameObject m16;
    public GameObject shootgun;
    public GameObject f40;
    public GameObject bFG;
    public GameObject[] monsters;
    bool shootStatus = true;
    float cooldown = 1.0f;
    private float plaerSpeedMove = 20.0f;

    void Start()
    {
        GameObject monstersBig = Instantiate(monsters[Random.Range(0, monsters.Length)], new Vector3(Random.Range(-70.0f, 70.0f), -11.0f, 0), Quaternion.Euler(0, 0, 0));
        leftHandDuck = GameObject.FindGameObjectWithTag("LeftHandDuck");
        rightHandDuck = GameObject.FindGameObjectWithTag("RightHandDuck");
        gun = GameObject.FindGameObjectWithTag("Gun");
    }

    public void NextLvlButton()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene("Gun5n2");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        Gun5n2Monsters.score = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Monsters")
        {
            col.gameObject.transform.position = new Vector3(Random.Range(-70.0f, 70.0f), -11.0f, 0);
        }
    }

    public void MoveLeft()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-plaerSpeedMove, 0f, 0f);
        gun.GetComponent<SpriteRenderer>().flipX = false;
        gun.transform.position = leftHandDuck.transform.position;
        man.GetComponent<SpriteRenderer>().flipX = false;
    }

    public void MoveRight()
    {
        
        GetComponent<Rigidbody2D>().velocity = new Vector3(plaerSpeedMove, 0f, 0f);
        gun.GetComponent<SpriteRenderer>().flipX = true;
        gun.transform.position = rightHandDuck.transform.position;
        man.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void MoveStop()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f, 0f);
    }

    public void ButtonGun1()
    {
        m16.SetActive(true);
        shootgun.SetActive(false);
        f40.SetActive(false);
        bFG.SetActive(false);

        if (man.GetComponent<SpriteRenderer>().flipX == true)
        {
            m16.GetComponent<SpriteRenderer>().flipX = true;
            m16.transform.position = rightHandDuck.transform.position;
        }
        else
        {
            m16.GetComponent<SpriteRenderer>().flipX = false;
            m16.transform.position = leftHandDuck.transform.position;
        }
    }
    public void ButtonGun2()
    {
        m16.SetActive(false);
        shootgun.SetActive(true);
        f40.SetActive(false);
        bFG.SetActive(false);

        if (man.GetComponent<SpriteRenderer>().flipX == true)
        {
            shootgun.GetComponent<SpriteRenderer>().flipX = true;
            shootgun.transform.position = rightHandDuck.transform.position;
        }
        else
        {
            shootgun.GetComponent<SpriteRenderer>().flipX = false;
            shootgun.transform.position = leftHandDuck.transform.position;
        }
    }

    public void ButtonGun3()
    {
        m16.SetActive(false);
        shootgun.SetActive(false);
        f40.SetActive(true);
        bFG.SetActive(false);
        f40.transform.position = rightHandDuck.transform.position;

        if (man.GetComponent<SpriteRenderer>().flipX == true)
        {
            f40.GetComponent<SpriteRenderer>().flipX = true;
            f40.transform.position = rightHandDuck.transform.position;
        }
        else
        {
            f40.GetComponent<SpriteRenderer>().flipX = false;
            f40.transform.position = leftHandDuck.transform.position;
        }
    }

    public void ButtonGun4()
    {
        m16.SetActive(false);
        shootgun.SetActive(false);
        f40.SetActive(false);
        bFG.SetActive(true);
        bFG.transform.position = rightHandDuck.transform.position;

        if (man.GetComponent<SpriteRenderer>().flipX == true)
        {
            bFG.GetComponent<SpriteRenderer>().flipX = true;
            bFG.transform.position = rightHandDuck.transform.position;
        }
        else
        {
            bFG.GetComponent<SpriteRenderer>().flipX = false;
            bFG.transform.position = leftHandDuck.transform.position;
        }
    }

    public void ShootGun()
    {
        shootSideRight = GameObject.FindGameObjectWithTag("shootSideRight");
        shootSideLeft = GameObject.FindGameObjectWithTag("shootSideLeft");

        if(gun.name == "M16")
        {
            if (gun.GetComponent<SpriteRenderer>().flipX == true)
            {
                ShootM16(50.0f, shootSideRight);
            }
            if (gun.GetComponent<SpriteRenderer>().flipX == false)
            {
                ShootM16(-50.0f, shootSideLeft);
            }
        }
        if(gun.name == "Shotgun")
        {
            if (gun.GetComponent<SpriteRenderer>().flipX == true)
            {
                StartCoroutine("ShootDrobovikRight");
            }
            if (gun.GetComponent<SpriteRenderer>().flipX == false)
            {
                StartCoroutine("ShootDrobovikLeft");
            }
        }
        if (gun.name == "F40")
        {
            if (gun.GetComponent<SpriteRenderer>().flipX == true)
            {
                ShootF40(100.0f, shootSideRight);
            }
            if (gun.GetComponent<SpriteRenderer>().flipX == false)
            {
                ShootF40(-100.0f, shootSideLeft);
            }
        }
        if (gun.name == "BFG")
        {
            if (gun.GetComponent<SpriteRenderer>().flipX == true)
            {
                StartCoroutine("ShootBFGRight");
            }
            if (gun.GetComponent<SpriteRenderer>().flipX == false)
            {
                StartCoroutine("ShootBFGLeft");
            }
        }
    }

    private IEnumerator ShootBFGRight()
    {
        GameObject bulletClone = Instantiate(bullet, shootSideRight.transform.position, bullet.transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(50.0f, 0, 0);
        bulletClone.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bulletClone.GetComponent<SpriteRenderer>().color = new Color32(34, 255, 0, 255);

        yield return new WaitForSeconds(1.0f);

        for (int j = 0; j < 10; j = j + 1)
        {
            GameObject bulletClone1 = Instantiate(bulletClone, bulletClone.transform.position, bulletClone.transform.rotation);
                    
            bulletClone1.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
            bulletClone1.GetComponent<SpriteRenderer>().color = new Color32(34, 255, 0, 255);
            bulletClone1.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0), ForceMode2D.Impulse);
            bulletClone1.GetComponent<Rigidbody2D>().gravityScale = 0;
            Destroy(bulletClone1, 1.0f);
        }
        Destroy(bulletClone);
    }
    private IEnumerator ShootBFGLeft()
    {
        GameObject bulletClone = Instantiate(bullet, shootSideLeft.transform.position, bullet.transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(-50.0f, 0, 0);
        bulletClone.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bulletClone.GetComponent<SpriteRenderer>().color = new Color32(34, 255, 0, 255);

        yield return new WaitForSeconds(0.5f);

        for (int j = 0; j < 30; j = j + 1)
        {
            GameObject bulletClone1 = Instantiate(bulletClone, bulletClone.transform.position, bulletClone.transform.rotation);

            bulletClone1.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
            bulletClone1.GetComponent<SpriteRenderer>().color = new Color32(34, 255, 0, 255);
            bulletClone1.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), 0);
            bulletClone1.GetComponent<Rigidbody2D>().gravityScale = 0;
            Destroy(bulletClone1, 1.0f);
        }
        Destroy(bulletClone);
    }

    private void ShootM16(float i, GameObject shootPlace)
    {
        GameObject bulletClone = Instantiate(bullet, shootPlace.transform.position, bullet.transform.rotation);
        bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(i, 0, 0);
        bulletClone.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
        Destroy(bulletClone, 2.0f);
    }
    
    public IEnumerator ShootDrobovikRight()
    {
        for (int i = 1; i <= 5; i++)
        {
            GameObject bulletClone = Instantiate(bullet, shootSideRight.transform.position, bullet.transform.rotation);
            bulletClone.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(100.0f, Random.Range(100.0f, -100.0f), 0);
            Destroy(bulletClone, 2.0f);
        }
        
        shootStatus = false;
        yield return new WaitForSeconds(cooldown);
        shootStatus = true;
    }

    public IEnumerator ShootDrobovikLeft()
    {
        for (int i = 1; i <= 5; i++)
        {
            GameObject bulletClone = Instantiate(bullet, shootSideLeft.transform.position, bullet.transform.rotation);
            bulletClone.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(-100.0f, Random.Range(100.0f, -100.0f), 0);
            Destroy(bulletClone, 2.0f);
        }
        
        shootStatus = false;
        yield return new WaitForSeconds(cooldown);
        shootStatus = true;
    }

    public void ShootF40(float i, GameObject shootPlace)
    {
        GameObject bulletClone1 = Instantiate(bullet, shootPlace.transform.position, bullet.transform.rotation);
        bulletClone1.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
        bulletClone1.GetComponent<Rigidbody2D>().velocity = new Vector3(i, 0, 0);
        Destroy(bulletClone1, 2.0f);

        GameObject bulletClone2 = Instantiate(bullet, shootPlace.transform.position, bullet.transform.rotation);
        bulletClone2.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
        bulletClone2.GetComponent<Rigidbody2D>().velocity = new Vector3(i, -30.0f, 0);
        Destroy(bulletClone2, 2.0f);
        
        GameObject bulletClone3 = Instantiate(bullet, shootPlace.transform.position, bullet.transform.rotation);
        bulletClone3.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
        bulletClone3.GetComponent<Rigidbody2D>().velocity = new Vector3(i, 30.0f, 0);
        Destroy(bulletClone3, 2.0f);
    }

    void Update()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
    }
}
