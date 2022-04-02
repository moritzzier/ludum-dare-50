using Pixelplacement;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool IsDragged;
    public ItemType Type;

    StateMachine stateMachine;
    Rigidbody2D rb;
    new PolygonCollider2D collider;

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
        Type = typeof(ItemType).GetRandomType();
        stateMachine.ChangeState(Type.ToString());
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
        rb.angularVelocity = 0f;
    }

    public void EndDrag()
    {
        IsDragged = false;
    }
}
