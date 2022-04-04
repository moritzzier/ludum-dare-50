using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] float moveLineLength;
    [SerializeField] float moveSpeed;
    [SerializeField] float startingPosition;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * moveLineLength);
    }

    private void Start()
    {
        transform.localPosition = new Vector3(startingPosition, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x > moveLineLength)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }

        transform.localPosition += transform.right * moveSpeed * Time.deltaTime;
    }
}
