using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce = 14f;

    [Header("Health")]
    public HealthBar healthBar;
    public float health = .5f;

    [Header("Animation")]
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private Rigidbody2D _rb;
    private float _moveInput;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        healthBar.UpdateHealthBar(health);
    }


    void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        if (_moveInput < 0)
            spriteRenderer.flipX = true;
        else if (_moveInput > 0)
            spriteRenderer.flipX = false;

        animator.SetFloat("speed", Mathf.Abs(_moveInput));
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveInput * moveSpeed, _rb.linearVelocity.y);
    }

    void UpdateHealth(float amount)
    {
        if (health + amount > 1)
            health = 1;
        else
            health += amount;

        healthBar.UpdateHealthBar(health);
    }

    public void OnTriggeredCollectable()
    {
        UpdateHealth(.2f);
    }
}
