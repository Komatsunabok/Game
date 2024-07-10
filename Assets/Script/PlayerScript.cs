using TMPro;
using UnityEngine;
//using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    //public PlayerScript playerScript;
    CharacterController controller;
    Animator animator;

    public TextMeshProUGUI scoreText;

    float normalSpeed = 3.0f;
    float sprintSpeed = 8.0f;
    float speed;
    
    float jump = 8.0f;
    float gravity = 10.0f;
    public int score = 0;

    Vector3 moveDirection = Vector3.zero;
    Vector3 startPos;

    public bool canRun = true;
    public float invincibleDuration = 3f;
    public float blinkInterval = 0.1f;

    //public void Awake()
    //{
    //    playerScript = this;
    //}

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canRun)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;
        }
        

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;
        Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed;

        if (controller.isGrounded)
        {
            moveDirection = moveZ + moveX;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jump;
            }
        }
        else
        {
            moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
            moveDirection.y -= gravity * Time.deltaTime;
        }

        animator.SetFloat("MoveSpeed", (moveZ + moveX).magnitude);

        transform.LookAt(transform.position + moveZ + moveX);

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void MoveStartPos()
    {
        controller.enabled = false;

        moveDirection = Vector3.zero;
        transform.position = startPos + Vector3.up * 10.0f;
        transform.rotation = Quaternion.identity;

        controller.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Treasure"))
        {
            score += 10;
            Debug.Log("Treasure found! score" + score);
            // ïÛï®Çå©Ç¬ÇØÇΩÇ∆Ç´ÇÃèàóùÇí«â¡
            Destroy(other.gameObject);
        }

    }

}
