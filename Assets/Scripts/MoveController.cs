using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    public  Vector3 MoveVector;
    [SerializeField] private float gravityForce;

    CharacterController _characterController;

   
    void Start()
    {
       
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnBolvanov.Instance.SpawnBolvanchik(5);
        
        PlayerMove();
        
    }

    

    private void PlayerMove()
    {
        MoveVector = Vector3.zero;
        MoveVector.x = Input.GetAxis("Horizontal") * _speedMove;
        MoveVector.z = Input.GetAxis("Vertical") * _speedMove;
        MoveVector.y = gravityForce;

        _characterController.Move(MoveVector * Time.deltaTime);
    }
    
}
