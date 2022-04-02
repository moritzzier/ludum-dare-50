using Pixelplacement;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool IsDragged;
    public ItemType Type;

    StateMachine _stateMachine;
    Rigidbody2D _rb;
    PolygonCollider2D _collider;
    Vector3 _dragOffset;
    Plane _dragPlane;
    Camera _mainCamera;
    RectTransform _rectTransform;

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
        Gizmos.DrawWireSphere(transform.position, 1);
    }

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<PolygonCollider2D>();
        _mainCamera = Camera.main;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        Type = typeof(ItemType).GetRandomType();
        _stateMachine.ChangeState(Type.ToString());
        _collider.SetPolygonColliderToSpriteBounds();
        if (_rb != null) _rb.AddTorque(10f);
    }

    void OnMouseDown()
    {
        _dragPlane = new Plane(_mainCamera.transform.forward, transform.position);
        Ray camRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(camRay.origin, camRay.direction * 10, Color.green);

        _dragPlane.Raycast(camRay, out var planeDistance);
        _dragOffset = transform.position - camRay.GetPoint(planeDistance);
    }

    void OnMouseDrag()
    {
        IsDragged = true;
        Ray camRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _dragPlane.Raycast(camRay, out var planeDistance);

        _rb.MovePosition(camRay.GetPoint(planeDistance) + _dragOffset);
        _rb.velocity = Vector2.zero;

        //_rectTransform.pivot = Input.mousePosition;
        DebugDraw.DrawSphere(_rectTransform.pivot, 1f, Color.red);
        //_rb.angularVelocity = 0f;

        //transform.position = ;
    }

    private void OnMouseUp()
    {
        IsDragged = false;
    }

    //public void StartDrag(Vector3 offset, Plane plane)
    //{
    //    _dragPlane = plane;
    //    _dragOffset = offset;
    //    IsDragged = true;
    //}

    //public void Drag(Vector3 position)
    //{
    //    Ray camRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
    //    _dragPlane.Raycast(camRay, out var planeDistance);

    //    _rb.MovePosition((Vector2)(camRay.GetPoint(planeDistance) + _dragOffset));
    //    
    //}

    //public void EndDrag()
    //{
    //    IsDragged = false;
    //}
}
