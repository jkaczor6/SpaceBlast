using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float leftBoundPadding = 5f;
    [SerializeField] float rightBoundPadding = 5f;
    [SerializeField] float topBoundPadding = 5f;
    [SerializeField] float bottomBoundPadding = 5f;
    InputAction moveAction;
    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;
    
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        InitBounds();
    }

    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0f,0f));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1f,1f));
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + bottomBoundPadding, maxBounds.y - topBoundPadding);

        transform.position = newPos;
    }
}
