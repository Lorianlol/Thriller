using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    bool m_isGrounded;
    bool m_isWalled;


    public LayerMask m_groundLayer;
    public float m_groundCheckDistance = 0.4f;

    public Transform m_headCheck;
    public Transform m_footCheck;
    public float m_wallCheckDistance = 0.4f;

    Animator m_anim;
    Rigidbody2D m_body;

    bool m_FacingRight = true;

    public float m_Speed = 200f;
    public float m_jumpForce = 20f;

    public float m_CanJumpTime = 0.2f;
    private float m_JumpTimer;
    private bool m_isJumping;

    private Vector2 m_vec;
    private float m_input_h;

    // 二段跳
    private int m_jumpTimes;

    //死亡动画
    public float dieTime = 1f;



    void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_body = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_JumpTimer = 0f;
        m_isJumping = false;
        m_vec = new Vector2(0, m_jumpForce);
        m_jumpTimes = 0;
    }

    
    private void Update()
    {
        m_isGrounded = IsGrounded();


        if (m_anim.GetBool("Ground") != m_isGrounded)
        {
            m_anim.SetBool("Ground", m_isGrounded);
        }

        #region 跳跃代码
        // 跳跃
        if (m_isJumping && Input.GetButton("Jump"))
        {
            if (m_JumpTimer <= m_CanJumpTime)
            {
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
                m_JumpTimer += Time.deltaTime;
            }
            else
            {
                m_isJumping = false;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(m_isGrounded)
            {
                m_jumpTimes = 1;

                m_isJumping = true;
                m_JumpTimer = 0f;
                m_isGrounded = false;
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
            }
            else if (m_jumpTimes == 1)
            {
                m_jumpTimes = 2;

                m_isJumping = true;
                m_JumpTimer = 0f;
                m_isGrounded = false;
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
            }

        }
        

        if (Input.GetButtonUp("Jump"))
        {
            m_isJumping = false;
        }

        m_anim.SetFloat("vSpeed", m_body.velocity.y);
        #endregion


        m_input_h = Input.GetAxisRaw("Horizontal");
        Move(m_input_h);

        //判断是否攻击
        if (Input.GetButtonDown("Attack"))
        {
            m_anim.SetBool("attack", true);
        }
        else if (Input.GetButtonUp("Attack"))
        {
            m_anim.SetBool("attack", false);
        }

    }

    private void Move(float h)
    {
        m_isWalled = IsWalled(m_FacingRight ? 1 : -1);

        if (m_FacingRight)
        {
            if(h<0)
            {
                Flip();
            }
            else if(m_isWalled)
            {
                m_anim.SetBool("run", false);
                return;
            }
        }
        else
        {
            if(h>0)
            {
                Flip();
            }
            else if(m_isWalled)
            {
                m_anim.SetBool("run", false);
                return;
            }
        }

        Vector2 v = m_body.velocity;
        v.x = h * m_Speed * Time.deltaTime;        
        m_body.velocity = v;


        m_anim.SetBool("run", !(h == 0));
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private bool IsGrounded()
    {

        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, m_groundCheckDistance, m_groundLayer);
        if (hit.collider != null)
        {
            //Debug.Log("ground");
            return true;
        }
        return false;
    }

    private bool IsWalled(float dir)
    {
        RaycastHit2D hit1 = Physics2D.Raycast(m_headCheck.position, dir * Vector2.right, m_wallCheckDistance, m_groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(m_footCheck.position, dir * Vector2.right, m_wallCheckDistance, m_groundLayer);
        if ((hit1.collider == null)&&(hit2.collider == null))
        {
            return false;
        }
        return true;
    }

    public int m_HP = 10;
    public GameObject ui_GameOverImage;

    void BeDamaged(int damage)
    {
        Debug.Log("damage");
        m_HP -= damage;
        if(m_HP<=0)
        {
            // 玩家死亡
            
            m_anim.SetBool("dead", true);
            ui_GameOverImage.SetActive(true);
            //通过摄像机位置顺便设置每关的GAMEOVER图标位置
            
            ui_GameOverImage.transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            StartCoroutine(KillPlayer());
            //Destroy(gameObject);
        }
    }

    IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }
}
