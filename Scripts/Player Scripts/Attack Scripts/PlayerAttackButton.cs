using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerAttackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayersAttacks playerAttack;

    // Start is called before the first frame update
    void Awake()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayersAttacks>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if(gameObject.name=="Attack Button")
        {
            playerAttack.AttackButtonPressed();
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "Attack Button")
        {
            playerAttack.AttackButtonReleased();
        }
    }
}
