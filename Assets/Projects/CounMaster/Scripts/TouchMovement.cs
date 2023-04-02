using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchMovement : MonoBehaviour
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
        MinMAxPosCalculate();

        float xMove = 0;
        movement = context.ReadValue<Vector2>();
        
        //eğer kalabalık sağdan veya soldan dışarı taşmış ise bir şey yapmayacağız.
        if (movement.x < 0 )            
        {
            xMove =   speed;
            if (StaticInfoHolder.minXpos + xMove < StaticInfoHolder.minPlatformXpos || StaticInfoHolder.minXpos < StaticInfoHolder.minPlatformXpos)
            {
                return;
            }
            
        }else if (movement.x > 0)
        {
            xMove =  -speed;
            if (StaticInfoHolder.maxXpos + xMove > StaticInfoHolder.maxPlatformXpos || StaticInfoHolder.maxXpos > StaticInfoHolder.maxPlatformXpos)
            {
                return;
            }
        }
        this.transform.Translate( xMove, 0, 0 , Space.World);
    }

    private void MinMAxPosCalculate()
    {
        float maxXPos = -200000;
        float minXPos = 200000;
        foreach (var man in StaticInfoHolder.mans)
        {
            maxXPos = Mathf.Max(maxXPos,man.transform.position.x );
            minXPos = Mathf.Min(minXPos,man.transform.position.x );
        }
        StaticInfoHolder.maxXpos = maxXPos;
        StaticInfoHolder.minXpos = minXPos;

                //bu platformun genişliğini kullanarak maksimum ve minimum x pozisyon değerini bulacağız ki kalabalık fazla dışarı taşmasın.
        float yariGenislik = mainPlatform.lossyScale.x / 2;
        StaticInfoHolder.maxPlatformXpos = mainPlatform.position.x + yariGenislik;
        StaticInfoHolder.minPlatformXpos = mainPlatform.position.x - yariGenislik;
    }

}
