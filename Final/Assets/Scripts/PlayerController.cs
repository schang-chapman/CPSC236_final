using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 25f;

    float horizontalMove = 0f;
    bool jumpFlag = false;
    bool jump = false;

    public GameObject bulletSpawn;
    public GameObject redBullet;
    public GameObject blueBullet;
    public GameObject yellowBullet;

    public GameObject blockSpawn;
    public GameObject playerBlock;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        BoundMovement();
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("isAttacking", false);

        if (jumpFlag)
        {
            jumpFlag = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetBool("isAttacking", true);
            Fire(redBullet);
        } else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetBool("isAttacking", true);
            Fire(blueBullet);
        } else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetBool("isAttacking", true);
            Fire(yellowBullet);
        } else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetBool("isAttacking", true);
            SpawnBlock();
        }
    }

    public void OnLanding()
    {
        jump = false;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpFlag = true;
        }
    }

    void Fire(GameObject bullet)
    {
        GameObject.Instantiate(bullet, bulletSpawn.transform);
    }

    void SpawnBlock()
    {
        GameObject newBlock = Instantiate(playerBlock);
        newBlock.transform.position = blockSpawn.transform.position;
    }

    void BoundMovement()
    {
        float dist = (this.transform.position - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        Vector3 playerSize = GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
            Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 4, rightBorder - playerSize.x / 4),
            Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 4, bottomBorder - playerSize.y / 4),
            this.transform.position.z
            );
    }

    public void End()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
