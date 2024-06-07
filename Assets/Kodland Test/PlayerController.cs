using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform rifleStart;
    [SerializeField] private Text HpText;

    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Victory;
    [SerializeField] private CharacterController characterController;
    
    Vector3 moveDirection = Vector3.zero;
    public float speed = 7;

    public float health = 0;

    void Start()
    {
        ChangeHealth(100); // Change initial health value to not be 0
    }

    public void ChangeHealth(int hp)
    {
        health += hp;
        if (health > 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            Lost();
        }
        HpText.text = health.ToString();
    }

    public void Win()
    {
        Victory.SetActive(true);
        Destroy(GetComponent<PlayerLook>());
        Cursor.lockState = CursorLockMode.None;
    }

    public void Lost()
    {
        GameOver.SetActive(true);
        Destroy(GetComponent<PlayerLook>());
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
       CheckMouseInput();
       CheckKeyboardInput();

        Collider[] targets = Physics.OverlapSphere(transform.position, 3);
        foreach (var item in targets)
        {
            if (item.tag == "Heal")
            {
                ChangeHealth(50);
                Destroy(item.gameObject);
            }
            if (item.tag == "Finish")
            {
                Win();
            }
            if (item.tag == "Enemy")
            {
                Lost();
            }
        }
    }

    void CheckMouseInput()
    {
         if (Input.GetMouseButtonDown(0))
        {
            GameObject buf = Instantiate(bullet);
            buf.transform.position = rifleStart.position;
            buf.GetComponent<Bullet>().setDirection(transform.forward);
            buf.transform.rotation = transform.rotation;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Collider[] tar = Physics.OverlapSphere(transform.position, 5);
            foreach (var item in tar)
            {
                if (item.tag == "Enemy")
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }

    void CheckKeyboardInput()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        moveDirection = (forward * Input.GetAxis("Vertical")) + (right * Input.GetAxis("Horizontal"));

        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}
