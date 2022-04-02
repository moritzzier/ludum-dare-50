using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItems : MonoBehaviour
{
    [SerializeField] LayerMask itemLayer;

    Item _currentDraggingItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);
            if (rayHit.collider != null)
            {
                _currentDraggingItem = rayHit.collider.GetComponent<Item>();
                _currentDraggingItem.StartDrag();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_currentDraggingItem != null)
            {
                _currentDraggingItem.EndDrag();
                _currentDraggingItem = null;
            }
        }

        if (_currentDraggingItem != null)
        {
            _currentDraggingItem.Drag(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}