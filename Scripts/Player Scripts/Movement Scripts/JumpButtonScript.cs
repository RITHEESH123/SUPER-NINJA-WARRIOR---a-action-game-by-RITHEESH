using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Rigidbody playerTransform;

    // Start is called before the first frame update
    void Awake()
    {
        //playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayersAttacks>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Jump Button")
        {
            playerTransform.AddForce(0, 4, 0,ForceMode.Impulse);
            //playerAttack.AttackButtonPressed();
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "Jump Button")
        {
            playerTransform.AddForce(0, 0, 0);
            //playerAttack.AttackButtonReleased();
        }
    }
}















































