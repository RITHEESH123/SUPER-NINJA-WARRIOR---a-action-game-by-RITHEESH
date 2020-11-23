using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public GameObject skill3;
    public GameObject skill3Point;

    public AudioClip earthHit;
    private AudioSource audioSource;

    public GameObject skill1;
    public GameObject skill1_Point_1;
    public GameObject skill1_Point_2;
    public GameObject skill1_Point_3;
    public GameObject skill1_Point_4;
    public GameObject skill1_Point_5;
    public GameObject skill1_Point_6;
    public GameObject skill1_Point_7;
    public GameObject skill1_Point_8;
    public GameObject skill1_Point_9;
    public GameObject skill1_Point_10;

    public GameObject sword;
    public GameObject hitPoint;
    private MeleeWeaponTrail swordTrail;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        swordTrail = sword.GetComponent<MeleeWeaponTrail>();
    }

    void Skill1(bool execute)
    {
        if (execute)
        {
            Instantiate(skill1, skill1_Point_1.transform.position, skill1_Point_1.transform.rotation);
            Instantiate(skill1, skill1_Point_2.transform.position, skill1_Point_2.transform.rotation);
            Instantiate(skill1, skill1_Point_3.transform.position, skill1_Point_3.transform.rotation);
            Instantiate(skill1, skill1_Point_4.transform.position, skill1_Point_4.transform.rotation);
            Instantiate(skill1, skill1_Point_5.transform.position, skill1_Point_5.transform.rotation);
            Instantiate(skill1, skill1_Point_6.transform.position, skill1_Point_6.transform.rotation);
            Instantiate(skill1, skill1_Point_7.transform.position, skill1_Point_7.transform.rotation);
            Instantiate(skill1, skill1_Point_8.transform.position, skill1_Point_8.transform.rotation);
            Instantiate(skill1, skill1_Point_9.transform.position, skill1_Point_9.transform.rotation);
            Instantiate(skill1, skill1_Point_10.transform.position, skill1_Point_10.transform.rotation);
            StartCoroutine(Skill1AfterWait());
        }
    }
    void Skill3(bool execute)
    {
        if (execute)
        {
            Instantiate(skill3, skill3Point.transform.position, skill3Point.transform.rotation);
            audioSource.PlayOneShot(earthHit);
        }
    }
    void SwordSlashAttack(bool isAttacking)
    {
        if (isAttacking)
        {
            swordTrail.Emit = true;
            hitPoint.SetActive(true);
        }
    }
    void SwordSlashAttackEnd(bool attackEnd)
    {
        if (attackEnd)
        {
            swordTrail.Emit = false;
            hitPoint.SetActive(false);
        }
    }

    IEnumerator Skill1AfterWait()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(skill1, skill1_Point_1.transform.position, skill1_Point_1.transform.rotation);
        Instantiate(skill1, skill1_Point_2.transform.position, skill1_Point_2.transform.rotation);
        Instantiate(skill1, skill1_Point_3.transform.position, skill1_Point_3.transform.rotation);
        Instantiate(skill1, skill1_Point_4.transform.position, skill1_Point_4.transform.rotation);
        Instantiate(skill1, skill1_Point_5.transform.position, skill1_Point_5.transform.rotation);
        Instantiate(skill1, skill1_Point_6.transform.position, skill1_Point_6.transform.rotation);
        Instantiate(skill1, skill1_Point_7.transform.position, skill1_Point_7.transform.rotation);
        Instantiate(skill1, skill1_Point_8.transform.position, skill1_Point_8.transform.rotation);
        Instantiate(skill1, skill1_Point_9.transform.position, skill1_Point_9.transform.rotation);
        Instantiate(skill1, skill1_Point_10.transform.position, skill1_Point_10.transform.rotation);
    }



}
