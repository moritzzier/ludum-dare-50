using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] StateMachine stateMachine;

    public enum ItemType
    {
        Syringe,
        Blood,
        Bandage,
    }

    public void SetItem(ItemType type)
    {
        stateMachine.ChangeState(type.ToString());
    }
}
