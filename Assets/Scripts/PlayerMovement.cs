using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    float movementHorizontal;
    float movementVertical;
    float WalkingSpeed = 10;
    float rotationHorizontal;
    float rotationVertical;

   [SerializeField] Camera playerCamera;
   float mouseSensitivity = 100;
    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
       handleMovement(); 
    }

    void handleMovement()
    {

        
        rotationHorizontal += Input.GetAxisRaw("Mouse X") * Time.deltaTime* mouseSensitivity;
        rotationVertical -= Input.GetAxisRaw("Mouse Y")* Time.deltaTime * mouseSensitivity;
        rotationVertical = Mathf.Clamp(rotationVertical, -90f, 90f);

        movementHorizontal = Input.GetAxisRaw("Horizontal");
        movementVertical = Input.GetAxisRaw("Vertical");

        transform.Translate(movementHorizontal * WalkingSpeed * Time.deltaTime, 0, movementVertical * WalkingSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, rotationHorizontal, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationVertical, 0 , 0);

    }

}
