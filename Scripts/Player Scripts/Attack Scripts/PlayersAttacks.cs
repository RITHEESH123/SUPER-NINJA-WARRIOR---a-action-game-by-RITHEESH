using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayersAttacks : MonoBehaviour
{
    public GameObject skillOne_EffectPrefab;
    public GameObject skillOne_DamagePrefab;

    public Transform skillOne_Point;

    public Transform skillOnePoint_1;
    public Transform skillOnePoint_2;
    public Transform skillOnePoint_3;
    public Transform skillOnePoint_4;
    public Transform skillOnePoint_5;
    public Transform skillOnePoint_6;
    public Transform skillOnePoint_7;
    public Transform skillOnePoint_8;

    public GameObject skillTwo_EffectPrefab;
    public GameObject skillTwo_DamagePrefab;

    public Transform skillTwo_Point;

    public Transform skillTwoPoint_1;
    public Transform skillTwoPoint_2;
    public Transform skillTwoPoint_3;
    public Transform skillTwoPoint_4;
    public Transform skillTwoPoint_5;
    public Transform skillTwoPoint_6;

    public GameObject skillThree_EffectPrefab;

    public Transform skillThreePoint_1;
    public Transform skillThreePoint_2;
    public Transform skillThreePoint_3;
    public Transform skillThreePoint_4;
    public Transform skillThreePoint_5;

    public AudioClip skillOneMusic1;
    public AudioClip skillOneMusic2;
    public AudioClip playerSkillOneSound;
    public AudioClip skillTwoMusic;
    public AudioClip skillThreeMusic;

    private Animator anim;
    private AudioSource audioSource;

    private bool s1_NotUsed;
    private bool s2_NotUsed;
    private bool s3_NotUsed;

    //Animation States
    private string ANIMATION_ATTACK = "Attack";
    private string ANIMATION_SKILL_1 = "Skill1";
    private string ANIMATION_SKILL_2 = "Skill2";
    private string ANIMATION_SKILL_3 = "Skill3";

    private Button skillOne_Btn;
    private Button skillTwo_Btn;
    private Button skillThree_Btn;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        skillOne_Btn = GameObject.Find("Skill One Button").GetComponent<Button>();
        skillTwo_Btn = GameObject.Find("Skill Two Button").GetComponent<Button>();
        skillThree_Btn = GameObject.Find("Skill Three Button").GetComponent<Button>();

        skillOne_Btn.onClick.AddListener(() => SkillOneButtonPressed());
        skillTwo_Btn.onClick.AddListener(() => SkillTwoButtonPressed());
        skillThree_Btn.onClick.AddListener(() => SkillThreeButtonPressed());

        s1_NotUsed = true;
        s2_NotUsed = true;
        s3_NotUsed = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleButtonPresses();
    }

    //LISTENERS FOR BUTTONS BEGIN
    public void AttackButtonPressed()
    {
        anim.SetBool(ANIMATION_ATTACK, true);
    }
    public void AttackButtonReleased()
    {
        anim.SetBool(ANIMATION_ATTACK, false);
    }
    public void SkillOneButtonPressed()
    {
        anim.SetBool(ANIMATION_SKILL_1, true);
    }
    public void SkillTwoButtonPressed()
    {
        anim.SetBool(ANIMATION_SKILL_2, true);
    }
    public void SkillThreeButtonPressed()
    {
        anim.SetBool(ANIMATION_SKILL_3, true);
    }
    //LISTENERS FOR BUTTONS ENDS


    void HandleButtonPresses()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool(ANIMATION_ATTACK, true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool(ANIMATION_ATTACK, false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (s1_NotUsed)
            {
                s1_NotUsed = false;
                anim.SetBool(ANIMATION_SKILL_1, true);
                //Start Coroutine
                StartCoroutine(ResetSkills(1));
            }           
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (s2_NotUsed)
            {
                s2_NotUsed = false;
                anim.SetBool(ANIMATION_SKILL_2, true);
                //Start Coroutine
                StartCoroutine(ResetSkills(2));
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (s3_NotUsed)
            {
                s3_NotUsed = false;
                anim.SetBool(ANIMATION_SKILL_3, true);
                //Start Coroutine
                StartCoroutine(ResetSkills(3));
            }
        }

    }

    //SKILL EFFECTS

    //SKILL ONE
    void SkillOne(bool skillOne)
    {
        if (skillOne)
        {
            Instantiate(skillOne_EffectPrefab, skillOne_Point.position,
                skillOne_Point.rotation);
            audioSource.PlayOneShot(skillOneMusic1);
            //Start Coroutine
            StartCoroutine(SkillOneCoroutine());
        }
    }

    void SkillOneSound(bool play)
    {
        if (play)
        {
            audioSource.PlayOneShot(playerSkillOneSound);
        }
    }

    void SkillOneEnd(bool skillOneEnd)
    {
        if (skillOneEnd)
        {
            anim.SetBool(ANIMATION_SKILL_1, false);
        }
    }

    IEnumerator SkillOneCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_1.position, skillOnePoint_1.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_2.position, skillOnePoint_2.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_3.position, skillOnePoint_3.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_4.position, skillOnePoint_4.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_5.position, skillOnePoint_5.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_6.position, skillOnePoint_6.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_7.position, skillOnePoint_7.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_8.position, skillOnePoint_8.rotation);
        audioSource.PlayOneShot(skillOneMusic2);
    }

    // SKILL TWO
    void SkillTwo(bool skillTwo)
    {
        if (skillTwo)
        {
            Instantiate(skillTwo_EffectPrefab, skillTwo_Point.position, skillTwo_Point.rotation);
            audioSource.PlayOneShot(skillTwoMusic);
            // start coroutine
            StartCoroutine(SkillTwoCoroutine());
        }
    }
    void SkillTwoEnd(bool skillTwoEnd)
    {
        if (skillTwoEnd)
        {
            anim.SetBool(ANIMATION_SKILL_2, false);
        }
    }
    IEnumerator SkillTwoCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_1.position, skillTwoPoint_1.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_2.position, skillTwoPoint_2.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_3.position, skillTwoPoint_3.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_4.position, skillTwoPoint_4.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_5.position, skillTwoPoint_5.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_6.position, skillTwoPoint_6.rotation);
    }
    
    //SKILL THREE

    void SkillThree(bool skillThree)
    {
        if (skillThree)
        {
            audioSource.PlayOneShot(skillThreeMusic);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_1.position, skillThreePoint_1.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_2.position, skillThreePoint_2.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_3.position, skillThreePoint_3.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_4.position, skillThreePoint_4.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_5.position, skillThreePoint_5.rotation);
        }
    }

    void SkillThreeEnd(bool skillThreeEnd)
    {
        if (skillThreeEnd)
        {
            anim.SetBool(ANIMATION_SKILL_3, false);
        }
    }
    

    IEnumerator ResetSkills(int skill)
    {
        yield return new WaitForSeconds(3f);

        switch (skill)
        {
            case 1:
                s1_NotUsed = true;
                break;
            case 2:
                s2_NotUsed = true;
                break;
            case 3:
                s3_NotUsed = true;
                break;
        }
    }


}//end
