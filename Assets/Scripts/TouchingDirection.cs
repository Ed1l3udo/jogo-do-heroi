using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
public class TouchingDirection : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D touchingCol;
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    Animator animator;
    [SerializeField] private bool _IsGrounded;
    [SerializeField] private bool _IsOnWall;
    [SerializeField] private bool _IsOnCeiling;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    public bool IsGrounded
    {
        get
        {
            return _IsGrounded;
        }
        private set
        {
            _IsGrounded = value;
            animator.SetBool("isGrounded", value);
        }
    }
    public bool IsOnWall
    {
        get
        {
            return _IsOnWall;
        }
        private set
        {
            _IsOnWall = value;
            animator.SetBool("isOnWall", value);
        }
    }
    public bool _IsOnCeiling
    {
        get
        {
            return __IsOnCeiling;
        }
        private set
        {
            __IsOnCeiling = value;
            animator.SetBool("_isOnCeiling", value);
        }
    }
    private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            touchingCol = GetComponent<CapsuleCollider2D>();
            animator = GetComponent<Animator>();
        }
    private void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}