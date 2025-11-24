using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] InputActionReference moveActionReference;
    

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool flipX = false;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }    

    private void OnEnable()
    {
        moveActionReference.action.Enable();
    }

    private void OnDisable()
    {
        moveActionReference.action.Disable();
    }
    
    void Update()
    {
        _moveDirection = moveActionReference.action.ReadValue<Vector2>();
        
        if (_moveDirection.magnitude > 0.1f)
        {
            if (_moveDirection.x < 0)
            {
                flipX = true;
            }
            else if (_moveDirection.x > 0)
            {
                flipX = false;
            }
            _spriteRenderer.flipX = flipX;
            _animator.SetBool("isWalk", true);
        }
        else
        {
            _animator.SetBool("isWalk", false);
        }

        _rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }

    public void CheerUp()
    {
        _animator.SetTrigger("cheer");
    }
}
