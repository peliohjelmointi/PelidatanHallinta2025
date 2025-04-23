using JetBrains.Annotations;
using UnityEngine;
using Newtonsoft.Json;


namespace KS
{
    public class PlayerMovement : MonoBehaviour, ISaveable
    {
        [SerializeField] float moveSpeed;
        [SerializeField] float jumpPower;

        Rigidbody rb;
        CapsuleCollider capsuleCollider;

        bool playerDead = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            capsuleCollider = GetComponent<CapsuleCollider>();
        }

        private void Start()
        {
            //Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (transform.position.y < 0 && !playerDead)
            {
                playerDead = true;
                GameEvents.OnGameOver?.Invoke();                
            }
            
            {
                MovePlayer();
            }
            
        }

        private void FixedUpdate()
        {
            if (Utilities.isGrounded(transform, capsuleCollider) && Input.GetKeyDown(KeyCode.Space))
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        void MovePlayer()
        {
            float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Translate(horizontal, 0, vertical);

            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        public void LoadGameData(GameData data)
        {
            transform.position = data.playerPosition;
            transform.eulerAngles = data.playerRotation;

            //transform.rotation = data.playerRotation; //VIRHE
        }

        public void SaveGameData(GameData data)
        {             
            data.playerPosition = transform.position;
            data.playerRotation = transform.eulerAngles;
        }
    }

}