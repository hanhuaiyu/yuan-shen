using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anima;
    public LayerMask ground;
    public Collider2D coll;
    public Collider2D BoxColl;
    public Transform touchingGround;

    public Text CaseNum;
    public Text AirEyeNum;
    public Text StoneEyeNum;

    public float speed = 300.0f;
    public float jumpForce = 15.0f;
    private int extraJump;

    public int LIFE = 5;
    private int case_num = 0;
    private int AirEye_num;
    private int StoneEye_num;
    public Vector2 ReliefPoint;

    private bool isHurt;
    private bool isTouchGround;

    public AudioSource jumpAudio, hurtAudio, collectAudio;

    //public AudioSource jumpAudio;
    //public AudioSource gemGet;
    //public AudioSource cherryGet;

    public Collider2D Sow;
    //public Collider2D EHitColl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        isHurt = false;
        Sow.enabled = false;
        extraJump = 1;

        ReliefPoint.x = transform.position.x;
        ReliefPoint.y = transform.position.y;
    }

    /*
     * 每一帧：
     * 1.先判断是否受伤，受伤时不受控制。
     * 2.再判断键盘输入，并实现移动，调整相应动画。
     * 3.最后，还有下落等不因键盘输入，而是由物理状态改变导致的动画。
     */
    private void FixedUpdate()
    {
        if (isHurt)
        {
            Hurting();
            return;
        }
        Movement();
        SwitchAnim();
        isTouchGround = Physics2D.OverlapCircle(touchingGround.position, 0.2f, ground);
    }

    //由于函数执行频率不同，分成两个。
    private void Update()
    {
        if (!isHurt) 
        {
            SowHit();
            Jump();
            RefreshText();
        }
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");//Player朝向

        rb.velocity = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);

        anima.SetFloat("running", Mathf.Abs(facedirection));//跑动动画
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
    }

    private void Jump()
    {
        if (isTouchGround)
            extraJump = 1;
        if (Input.GetButtonDown("Jump") && extraJump > 0)
        {
            extraJump -= 1;
            rb.velocity = Vector2.up * jumpForce;
            anima.SetBool("jumping", true);
            jumpAudio.Play();
        }
    }

    //处理跳跃与降落动作
    void SwitchAnim()
    {
        if (rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {
            anima.SetBool("falling", true);
        }
        if (anima.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.1f)
            {
                anima.SetBool("jumping", false);
                anima.SetBool("falling", true);
            }
        }
        else if (coll.IsTouchingLayers(ground))
        {
            anima.SetBool("falling", false);
        }
    }

    /*
     * 当接触到为“开关”的碰撞体。
     * 不在“Update()”内。
     * 由于角色有两个碰撞体，所以制定其中一个碰撞时才有效。
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.tag == "Heart" && coll.IsTouching(collision))
        {
            collectAudio.Play();
            collision.GetComponent<Animator>().Play("isGot");
        }*/
        if (collision.tag == "Case" && coll.IsTouching(collision))
        {
            collectAudio.Play();
            collision.GetComponent<Animator>().Play("Get");
        }
        if (collision.tag == "DeadLine" && coll.IsTouching(collision))
        {
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-6.0f, rb.velocity.y);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(6.0f, rb.velocity.y);
            }
            isHurt = true;
            anima.SetBool("hurting", true);
            hurtAudio.Play();
            Invoke("Relief", 1.0f);
        }
    }

    public void GetCase()
    {
        case_num += 1;
    }

    public void GetAirEye()
    {
        AirEye_num += 1;
    }

    public void GetStoneEye()
    {
        StoneEye_num += 1;
    }

    private void RefreshText()
    {
        
        CaseNum.text = case_num.ToString();
        AirEyeNum.text = AirEye_num.ToString();
        StoneEyeNum.text = StoneEye_num.ToString();
    }

    /*
     * 用来判断与结束“受伤”状态与“受伤”动画。
     */
    private void Hurting()
    {
        if (Mathf.Abs(rb.velocity.x) < 0.1f && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            isHurt = false;
            anima.SetBool("hurting", false);
        }
    }

    /*
     * 碰撞体相互接触时执行，不在“Update()”内。
     * 判断角色碰撞体碰撞到的碰撞体->对应的实体->的“tag”。
     * 如果角色在下降状态，销毁敌人实体。
     * 否则，触发受伤效果，处于受伤状态。
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Spike2 spike2 = collision.gameObject.GetComponent<Spike2>();
        if (collision.gameObject.tag == "Spike2")
        {
                spike2.JumpOn();
        }

        if (collision.gameObject.tag == "Enemies")
        {
            if (transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-6.0f, rb.velocity.y);
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(6.0f, rb.velocity.y);
            }
            isHurt = true;
            anima.SetBool("hurting", true);
            hurtAudio.Play();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (anima.GetBool("falling") )
            {
               enemy.Boom();
               //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
               //anima.SetBool("jumping", true);
            }
            else
            {
                if (transform.position.x < collision.gameObject.transform.position.x)
                {
                    rb.velocity = new Vector2(-6.0f, rb.velocity.y);
                }
                else if (transform.position.x > collision.gameObject.transform.position.x)
                {
                    rb.velocity = new Vector2(6.0f, rb.velocity.y);
                }
                isHurt = true;
                anima.SetBool("hurting", true);
                hurtAudio.Play();
            }
        }
    }

    private void SowHit()
    {
        if (anima.GetBool("hurting"))
            return;
        if (Mathf.Abs(rb.velocity.y) > 0.1f)
            return;
        if (Input.GetKeyDown(KeyCode.J))
        {
            Sow.enabled = true;
            anima.SetTrigger("attack");
        }
    }

    public void EndSowHit()
    {
        Sow.enabled = false;
        anima.SetTrigger("endAttack");
    }

    //受伤减少生命值
    public void ReduceLife(int num)
    {
        FindObjectOfType<Heart>().HeartBreak(LIFE);
        LIFE -= num;
        if(LIFE <= 0)
        {
            Restart();
        }
    }

    private void Relief()
    {
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(ReliefPoint.x, ReliefPoint.y + 2.0f, 0);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetNum(int type)
    {
        int number;
        switch(type)
        {
            case 1:
                number = case_num;
                break;
            case 2:
                number = AirEye_num;
                break;
            case 3:
                number =  StoneEye_num;
                break;
            default:
                number = case_num;
                break;
        }
        return number;
    }
}
