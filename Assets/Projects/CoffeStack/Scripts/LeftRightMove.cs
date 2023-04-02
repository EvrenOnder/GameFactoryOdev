using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftRightMove : MonoBehaviour
{
    private Vector2 movement;
    public float speed;

    private TouchControl touchControl;

    public Transform mainPlatform;
    private InputAction touchDelta;
    // Start is called before the first frame update
    private void Awake()
    {
        touchControl = new TouchControl();
        touchControl.TouchMove.Enable();
    }

    private void OnEnable()
    {
        touchControl.TouchMove.MoveHorizontal.performed += OnDeltaTouch;
    }
    public void OnDeltaTouch(InputAction.CallbackContext context)
    {
        

        float xMove = 0;
        movement = context.ReadValue<Vector2>();
        
        //eğer kalabalık sağdan veya soldan dışarı taşmış ise bir şey yapmayacağız.
        if (movement.x > 0 )            
        {
            xMove =   speed;    
        }else if (movement.x < 0)
        {
            xMove =  -speed;
        }
        this.transform.Translate( xMove, 0, 0 , Space.World);
    }
}
