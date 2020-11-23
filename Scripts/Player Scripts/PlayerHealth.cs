using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float realHealth;

    private Animator anim;
    private bool playerDead;
    private bool playerBeHit;

    private Slider healthSlider; 
    private Text healthText;

    private BossHealth bossHealth;
    private Transform bossTransform;
    private bool victory;

    private AudioSource audioSource;
    public AudioClip playerDeadSound;

    private string ANIMATION_DEAD = "Dead";
    private string ANIMATION_ATTACK = "Attack";
    private string ANIMATION_VICTORY = "Victory";

    private string BASE_LAYER_DYING = "Base Layer.Dying";
    private string BASE_LAYER_VICTORY = "Base Layer.Victory";

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        healthSlider = GameObject.Find("Health Foreground").GetComponent<Slider>();
        healthText = GameObject.Find("Health Text").GetComponent<Text>();

        //Set the health Text and slider value
        healthText.text = realHealth.ToString();
        healthSlider.value = realHealth;

        bossTransform = GameObject.FindGameObjectWithTag("Boss").transform;
        bossHealth = bossTransform.gameObject.GetComponent<BossHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (realHealth <= 0)
        {
            realHealth = 0;
            PlayerDying();
        }
        if (playerDead)
        {
            StopPlayerDeadAnimation();
            StartCoroutine(PlayerDead());
        }
        if (realHealth > 1000)
        {
            realHealth = 1000f;
        }
        if (bossHealth.realHealth <= 0)
        {
            Victory();
        }
        if (victory)
        {
            StopVictoryAnimation();
            StartCoroutine(BossDead());
        }

    }

    void PlayerDying()
    {
        //audioSource.PlayOneShot(playerDeadSound);
        playerDead = true;
        anim.SetBool(ANIMATION_DEAD, true);
        anim.SetBool(ANIMATION_ATTACK, false);        
    }

    void StopPlayerDeadAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_DYING))
        {
            anim.SetBool(ANIMATION_DEAD, false);
        }
    }

    public void TakeDamage(float amount)
    {
        realHealth -= amount;

        if (realHealth <= 0)
        {
            realHealth = 0;
        }
        if (amount > 0)
        {
            healthText.text = realHealth.ToString();
            healthSlider.value = realHealth;
            playerBeHit = true;
        }
    }

    void Victory()
    {
        anim.SetBool(ANIMATION_VICTORY, true);
        victory = true;
    }

    void StopVictoryAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_VICTORY))
        {
            anim.SetBool(ANIMATION_VICTORY, false);
        }
    }

    IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }
    IEnumerator BossDead()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameWin");
    }


}//end
