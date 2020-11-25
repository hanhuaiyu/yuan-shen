using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class dragonmove : MonoBehaviour
{   //要移动的物体
    public GameObject PlatForm;
    //要移动物体开始的点
    public Transform point1;
    //要移动物体结束的点
    public Transform point2;
    //要移动物体的移动速度
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public float MoveSpeed = 2f;
    //要移动到的目标点
    public Transform target;
    public int a=0,b=0;


    public BulletCharacter bulletTemplate;
    public Transform firPoint;
    public List<BulletCharacter> tempBullets;
    void Start()
    {
           tempBullets = new List<BulletCharacter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(a==0)
        {
            if(PlatForm.transform.position.x - point1.position.x >= Mathf.Abs(0.02f))
            {
                PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point1.position, MoveSpeed*Time.deltaTime);


                
            }
            else if(b==0)
            {
                //Destroy(point1.gameObject);
                point1.gameObject.SetActive(false);
                a=1;
                b=1;
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirShotgun());
            }
        }
        else if(a==1)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point2.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point2.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==1)
            {
                point2.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=2;
                b=2;
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirShotgun());
            }
        }
        else if(a==2)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point3.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point3.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==2)
            {
                point3.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=3;
                b=3;
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirRound(5,firPoint.transform.position));
            }
        }
        else if(a==3)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point4.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point4.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==3)
            {
                point4.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=4;
                b=4;
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirShotgun());
            }
        }
        else if(a==4)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point5.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point5.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==4)
            {
                point5.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=5;
                b=5;
                point1.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FireTurbine());
            }
        }
        else if(a==5)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point1.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point1.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==5)
            {
                point1.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=6;
                b=6;
                point2.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FireBallBulle());
            }
        }
        else if(a==6)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point2.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point2.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==6)
            {
                point2.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=7;
                b=7;
                point3.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirShotgun());
            }
        }
        else if(a==7)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point3.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point3.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==7)
            {
                point3.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=8;
                b=8;
                point4.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FireBallBulle());
            }
        }
        else if(a==8)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point4.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point4.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==8)
            {
                point4.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=9;
                b=9;
                point5.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FireTurbine());
            }
        }
        else if(a==9)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point5.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point5.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==9)
            {
                point4.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=10;
                b=10;
                point5.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirShotgun());
            }
        }
        else if(a==10)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point5.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point5.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==10)
            {
                point5.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=11;
                b=11;
                point1.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FireTurbine());
            }
        }
        else if(a==11)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point1.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point1.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==11)
            {
                point1.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=12;
                b=12;
                point2.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirShotgun());
            }
        }
        else if(a==12)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point2.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point2.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==12)
            {
                point2.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=13;
                b=13;
                 point3.gameObject.SetActive(true);
                 StopAllCoroutines();
            ClearBulletsList();
            StartCoroutine(FirRound(5,firPoint.transform.position));
            }
        }
        else if(a==13)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point3.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point3.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==13)
            {
                point3.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=14;
                b=14;
                 point4.gameObject.SetActive(true);
                 StopAllCoroutines();
            ClearBulletsList();
            StartCoroutine(FirRoundGroup());
            }
        }
        else if(a==14)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point4.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point4.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==14)
            {
                point4.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=15;
                b=15;
                 point5.gameObject.SetActive(true);
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FirRound(5,firPoint.transform.position));
            }
        }
        else if(a==15)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point5.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point5.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==15)
            {
                point5.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=16;
                b=16;
                 point1.gameObject.SetActive(true);
                 StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FireBallBulle());
            }
        }
        else if(a==16)
        {
            if(Mathf.Abs(PlatForm.transform.position.x - point1.position.x) >=Mathf.Abs(0.02f))
            {
           PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point5.position, MoveSpeed*Time.deltaTime);
            }
            else if(b==16)
            {
                point1.gameObject.SetActive(false);
                //Destroy(point2.gameObject);
                a=17;
                b=17;
                StopAllCoroutines();
                ClearBulletsList();
                StartCoroutine(FireTurbine());
                //point1.gameObject.SetActive(true);

            }
        }
        else if (a == 17)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // else if(PlatForm.transform.position.x - point3.position.x >=0.02f)
        // {  
        //     Destroy(point2.gameObject);
        //     PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, point3.position, MoveSpeed*Time.deltaTime);
        // }

    }
    
















    /// <summary>
    /// 发射散弹
    /// </summary>
    /// <returns></returns>
    IEnumerator FirShotgun()
    {
        Vector3 bulletDir = firPoint.transform.up*-1; //由于资源的原因，我们这边的发射方向为物体的Up轴方向
        Quaternion leftRota = Quaternion.AngleAxis(-30, Vector3.forward);
        Quaternion RightRota = Quaternion.AngleAxis(30, Vector3.forward); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转30度
        for (int i=0;i<10;i++)     //散弹发射次数
        {
            for (int j=0;j<3;j++) //一次发射3颗子弹
            {
                switch (j)
                {
                    case 0:
                        CreatBullet(bulletDir, firPoint.transform.position);  //发射第一颗子弹，方向不需要进行旋转
                        break;
                    case 1:
                        bulletDir = RightRota * bulletDir;//第一个方向子弹发射完毕，旋转方向到下一个发射方向
                        CreatBullet(bulletDir, firPoint.transform.position);
                        break;
                    case 2:
                        bulletDir = leftRota*(leftRota * bulletDir); //右边方向发射完毕，得向左边旋转2次相同的角度才能到达下一个发射方向
                        CreatBullet(bulletDir, firPoint.transform.position);
                        bulletDir = RightRota * bulletDir; //一轮发射完毕，重新向右边旋转回去，方便下一波使用
                        break;
                }
            }
            yield return new WaitForSeconds(0.5f); //协程延时，0.5秒进行下一波发射
        }
    }

    /// <summary>
    /// 发射圆形弹幕
    /// </summary>
    /// <returns></returns>
    IEnumerator FirRound(int number,Vector3 creatPoint)
    {
        Vector3 bulletDir = firPoint.transform.up;
        Quaternion rotateQuate = Quaternion.AngleAxis(10, Vector3.forward);//使用四元数制造绕Z轴旋转10度的旋转
        for (int i=0;i< number; i++)    //发射波数
        {
            for (int j=0;j<36;j++)
            {
                CreatBullet(bulletDir, creatPoint);
                bulletDir = rotateQuate * bulletDir; //让发射方向旋转10度，到达下一个发射方向
            }
            yield return new WaitForSeconds(0.5f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;
    }

    /// <summary>
    /// 发射组合圆形弹幕
    /// </summary>
    /// <returns></returns>
    IEnumerator FirRoundGroup()
    {
        Vector3 bulletDir = firPoint.transform.up;
        Quaternion rotateQuate = Quaternion.AngleAxis(45, Vector3.forward);//使用四元数制造绕Z轴旋转45度的旋转
        List<BulletCharacter> bullets = new List<BulletCharacter>();       //装入开始生成的8个弹幕
        for (int i=0;i<8;i++)
        {
            var tempBullet = CreatBullet(bulletDir, firPoint.transform.position);
            bulletDir = rotateQuate * bulletDir; //生成新的子弹后，让发射方向旋转45度，到达下一个发射方向
            bullets.Add(tempBullet); 
        }
        yield return new WaitForSeconds(1.0f);   //1秒后在生成多波弹幕
        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].speed = 0; //弹幕停止移动
            StartCoroutine(FirRound(6, bullets[i].transform.position));//通过之前弹幕的位置，生成多波多方向的圆形弹幕
        }
    }

    /// <summary>
    /// 发射涡轮型弹幕
    /// </summary>
    /// <returns></returns>
    IEnumerator FireTurbine()
    {
        Vector3 bulletDir = firPoint.transform.up;      //发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(20, Vector3.forward);//使用四元数制造绕Z轴旋转20度的旋转
        float radius = 0.6f;        //生成半径
        float distance = 0.2f;      //每生成一次增加的距离
        for (int i=0;i<18;i++)
        {
            Vector3 firePoint = firPoint.transform.position + bulletDir * radius;   //使用向量计算生成位置
            StartCoroutine(FirRound(1, firePoint));     //在算好的位置生成一波圆形弹幕
            yield return new WaitForSeconds(0.05f);      //延时较小的时间（为了表现效果），计算下一步
            bulletDir = rotateQuate * bulletDir;        //发射方向改变
            radius += distance;     //生成半径增加
        }
    }

    /// <summary>
    /// 发射球形子弹
    /// </summary>
    /// <returns></returns>
    IEnumerator FireBallBulle()
    {
        Vector3 bulletDir = firPoint.transform.up;      //发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(10, Vector3.forward);//使用四元数制造绕Z轴旋转20度的旋转
        float distance = 1.0f;
        for (int j=0;j<8;j++)
        {
            for (int i = 0; i < 36; i++)
            {
                Vector3 creatPoint = firPoint.transform.position + bulletDir * distance;
                BulletCharacter tempBullet = CreatBullet(bulletDir, creatPoint);
                tempBullet.isMove = false;
                StartCoroutine(tempBullet.DirChangeMoveMode(10.0f, 0.4f, 15));
                bulletDir = rotateQuate * bulletDir;
            }
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
    }
    public BulletCharacter CreatBullet(Vector3 dir,Vector3 creatPoint)
    {
        BulletCharacter bulletCharacter = Instantiate(bulletTemplate, creatPoint, Quaternion.identity);
        bulletCharacter.gameObject.SetActive(true);
        bulletCharacter.dir = dir;
        tempBullets.Add(bulletCharacter);
        return bulletCharacter;
    }

    /// <summary>
    /// 清空子弹列表
    /// </summary>
    public void ClearBulletsList()
    {
        if (tempBullets.Count>0)
        {
            for (int i=(tempBullets.Count-1);i>=0;i--)
            {
                Destroy(tempBullets[i].gameObject);
            }
        }

        tempBullets.Clear();

    }
}
    /*void moveto(){
          //把物体移动到指定的位置点上
        PlatForm.transform.position = Vector2.MoveTowards(PlatForm.transform.position, target, MoveSpeed*Time.deltaTime);

        
    }*/


