using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{


    [SerializeField] private InputActionReference _actionReference = null;
    [SerializeField] private InputActionReference _actionReference1 = null;


    private Vector2 deplacement;
    private float speedshutZ;


    private void Update()
    {
        if (_actionReference == null || _actionReference.action == null || _actionReference.action.type == InputActionType.Button)
            return;

        //switch (_actionReference.action.expectedControlType)
        //{
        //    case "Axis":
        //        speedshutZ = _actionReference.action.ReadValue<float>() * 0.001f;  // pour le deplacement en Z
        //        break;
        //    case "Vector2":
        //        deplacement = _actionReference.action.ReadValue<Vector2>() * Time.deltaTime; // pour le deplacement en x et y 
        //        break;
        //    default:
        //        break;
        //}

        switch (_actionReference1.action.expectedControlType)
        {
            case "Axis":
                speedshutZ = _actionReference1.action.ReadValue<float>() * 0.01f;  // pour le deplacement en Z
                break;
            case "Vector2":
                deplacement = _actionReference1.action.ReadValue<Vector2>() * Time.deltaTime; // pour le deplacement en x et y 
                break;
            default:
                break;
        }

        if (transform.position.y < Camera.main.transform.position.y)
        {
            transform.Translate(new Vector3(deplacement.x, speedshutZ, deplacement.y));
        }
        if (transform.position.y > Camera.main.transform.position.y)
        {
            transform.Translate(new Vector3(deplacement.x, speedshutZ, -deplacement.y));
        }
    }


}
