using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    StateMachine stateMachine;
    Rigidbody2D rb;

    public enum ItemType
    {
        Syringe,
        Blood,
        Bandage,
    }

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetItem(ItemType type)
    {
        stateMachine.ChangeState(type.ToString());
    }

    public void StartDrag()
    {
        stateMachine.ChangeState("Blood");
    }

    public void Drag(Vector3 position)
    {
        Vector2 directionToMouse = position - this.transform.position;

        rb.AddForce(directionToMouse * 10);
    }

    public void EndDrag()
    {
        stateMachine.ChangeState("Syringe");
    }
}
