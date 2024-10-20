using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    private GatherInput gatherInput;
    public new Rigidbody2D rigidbody2D;
    private Animator animator;

    public int maxJumpCount = 2; // �ӹǹ��á��ⴴ�٧�ش
    private int currentJumpCount; // �纨ӹǹ���駷����ⴴ㹻Ѩ�غѹ

    private int direction = 1; // to right-hand side
    public float jumpForce;

    public float rayLength;
    public LayerMask groundLayer;
    public Transform leftPoint;
    public Transform rightPoint; // �ش����Ѻ��Ǩ�ͺ�����Ң��
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentJumpCount = maxJumpCount; // ��駤�Ҩӹǹ���駷����ⴴ�������
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValues();
    }

    private void FixedUpdate()
    {
        CheckStatus();
        Move();
        JumpPlayer();
    }

    private void Move()
    {
        Flip();
        rigidbody2D.velocity = new Vector2(speed * gatherInput.valueX, rigidbody2D.velocity.y);
    }

    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }

    private void SetAnimatorValues()
    {
        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
        animator.SetFloat("vSpeed", rigidbody2D.velocity.y);
        animator.SetBool("Grounded", grounded);
    }

    private void JumpPlayer()
    {
        if (gatherInput.jumpInput && (grounded || currentJumpCount > 0))
        {
            // ���ⴴ ���Ŵ�ӹǹ���駷����ⴴ��
            rigidbody2D.velocity = new Vector2(gatherInput.valueX * speed, jumpForce);
            currentJumpCount--;
        }
        // ���絤�� input �ͧ��á��ⴴ
        gatherInput.jumpInput = false;
    }

    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);

        // ��Ǩ�ͺ����բ�ҧ㴢�ҧ˹�������ʾ��
        grounded = leftCheckHit || rightCheckHit;

        // ���絨ӹǹ��á��ⴴ����������ʾ��
        if (grounded)
        {
            currentJumpCount = maxJumpCount;
        }
    }
}
