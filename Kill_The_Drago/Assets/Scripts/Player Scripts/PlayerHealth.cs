using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    private bool hit = true;

    public GameObject flash,panel;

    public Slider slider;
    public SpriteRenderer playerSpr;

    public Color collideColor, colldieColor2;
    public AudioClip axeHit;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        

        if(slider.value > health)
            slider.value -= .25f;
        else
            slider.value += .25f;

        if (health < 1 && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerDeath") || transform.position.y < -3)
        {
            StartCoroutine(PlayersDeath());
        }
    }

    IEnumerator PlayersDeath()
    {
        anim.SetBool("Death", true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        yield return new WaitForSeconds(.1f);
        anim.SetBool("Death", false);
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0;
        //restart The level
        panel.SetActive(true);
        gameObject.tag = "Untagged";

    }

    public void TakeDamage(int damage)
    {
        if (hit)
        { 
            StartCoroutine(PlayerHit());
            health -= damage;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "FireBall")
        {
            TakeDamage(15);
            Destroy(target.gameObject);
        }

        if(target.tag == "HealthPotion" && health < 81)
        {
            Destroy(target.gameObject);
            health += 20;

        }

    }

    IEnumerator PlayerFlash()
    {
        for (int i = 0; i < 2; i++)
        {
            playerSpr.color = collideColor;
            yield return new WaitForSeconds(.1f);
        }

        for (int i = 0; i < 4; i++)
        {
            playerSpr.color = colldieColor2;
            yield return new WaitForSeconds(.1f);
            playerSpr.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }

    }

    IEnumerator PlayerHit()
    {
        SoundManager.instance.PlaySoundFx(axeHit, .2f);
        flash.SetActive(true);
        hit = false;
        StartCoroutine(PlayerFlash());
        yield return new WaitForSeconds(1.3f);
        hit = true;
        flash.SetActive(false);
    }

}
