using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CatController : MonoBehaviour
{
    private Rigidbody2D rBody2D;
    private float jumpForce = 650f;
    private float moveForce = 50f;
    private Animator anim;
   // bool isJumping=false;
    // Start is called before the first frame update
    void Start()
    {
        this.rBody2D=this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isJumping = true;
            this.rBody2D.AddForce(Vector2.up * this.jumpForce);
        }
        int dirX = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dirX = -1;
            var x = Mathf.Clamp(this.transform.position.x, -2.5f, 2.5f);
            var pos = this.transform.position;
            pos.x = x;
            this.transform.position = pos;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dirX = 1;
            var x = Mathf.Clamp(this.transform.position.x, -2.5f, 2.5f);
            var pos = this.transform.position;
            pos.x = x;
            this.transform.position = pos;
        }
        float speedX=Mathf.Abs(this.rBody2D.velocity.x);//���ǵ�� �����ϼ� �����ϱ� ���밪
        if (speedX < 2f)
        {
            this.rBody2D.AddForce(new Vector2(dirX, 0) * this.moveForce);
        }
        if (dirX != 0)
        {
            this.transform.localScale = new Vector3(dirX, 1, 1);
        }
        //�÷��̾��� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ���
        this.anim.speed = speedX / 2.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("game clear ������ ��ȯ");
        SceneManager.LoadScene("ClearScene");
    }
}
