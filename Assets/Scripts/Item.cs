using Pixelplacement;
using UnityEngine;

public class Item : MonoBehaviour
{
    StateMachine stateMachine;
    Rigidbody2D rb;
    PolygonCollider2D collider;
    PolygonCollider2D childCollider;

    public bool IsDragged;

    public enum ItemType
    {
        OxygenTank,
        Syringe,
        Bloodbag,
        BandAid,
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<PolygonCollider2D>();

    }

    private void OnEnable()
    {
        string state = typeof(ItemType).GetRandomType().ToString();
        Debug.Log(state);
        stateMachine.ChangeState(state);
        collider.SetPolygonColliderToSpriteBounds();
        if (rb != null) rb.AddTorque(10f);
    }

    public void StartDrag()
    {
        IsDragged = true;
    }

    public void Drag(Vector3 position)
    {
        rb.MovePosition(position);
        rb.velocity = Vector2.zero;
    }

    public void EndDrag()
    {
        IsDragged = false;
    }
}
