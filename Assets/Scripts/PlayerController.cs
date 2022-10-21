using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public JoystickMove joystickMove;
    public Transform playerRenderer;

    private void Awake()
    {
        joystickMove = GetComponent<JoystickMove>();
        Rand = Random.Range(0, 3);
        for (int j = 0; j < 100; j++)
        {
            if (temp.Contains(Rand))
            {
                Rand = Random.Range(0, 3);
            }
            else
                break;
        }
         RandomCharacterColor((ColorType)Rand);
        temp.Add(Rand);
  
    }
    private void Start()
    {
       
    }

    protected override void CharacterMoving()
    {
        Stair stair = CheckLayerStair();
        // khong co stair
        if (stair == null)
        {
            joystickMove.JoystickMoving();
        }
        // co stair
        else
        {
            // cung mau
            if (stair.colorType == characterColor)
            {
                joystickMove.JoystickMoving();
            }
            // khong cung mau
            else
            {
                // con gach
                if (listBrickCharater.Count > 0)
                {
                    stair.ChangeColor(characterColor);
                    RemoveBrick();
                }
                // het gach
                else

                {
                    joystickMove.StopMoving();
                }
            }
        }
    }

    public override void RandomCharacterColor(ColorType colorType)
    {
        base.RandomCharacterColor(colorType);
        playerRenderer.GetComponent<MeshRenderer>().material = characterMat[(int)colorType];
    }
}

