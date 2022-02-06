using UnityEngine;
using UnityEngine.InputSystem;

namespace ECNBaseCode.Sample
{
    public class XRInputDebugger : MonoBehaviour
    {
        [Tooltip("Action Reference that represents the control")]
        [SerializeField] private InputActionReference _actionReference = null;

        protected void OnActionStarted(InputAction.CallbackContext ctx)
        {
            Debug.Log(_actionReference.name + "/" + ctx.action.name + " pressed");
        }

        protected void OnActionCanceled(InputAction.CallbackContext ctx)
        {
            Debug.Log(_actionReference.name + "/" + ctx.action.name + " released");
        }

        protected virtual void OnEnable()
        {
            if (_actionReference == null || _actionReference.action == null ||
                _actionReference.action.type != InputActionType.Button)
                return;

            _actionReference.action.started += OnActionStarted;
            _actionReference.action.canceled += OnActionCanceled;
        }

        protected virtual void OnDisable()
        {
            if (_actionReference == null || _actionReference.action == null ||
                _actionReference.action.type != InputActionType.Button)
                return;

            _actionReference.action.started -= OnActionStarted;
            _actionReference.action.canceled -= OnActionCanceled;
        }

        private void Update()
        {
            if (_actionReference == null || _actionReference.action == null ||
                _actionReference.action.type == InputActionType.Button)
                return;

            switch (_actionReference.action.expectedControlType)
            {
                case "Axis":
                    Debug.Log(_actionReference.name + "/" + _actionReference.action.name + ": " +
                        _actionReference.action.ReadValue<float>());
                    break;
                case "Vector2":
                    Debug.Log(_actionReference.name + "/" + _actionReference.action.name + ": " +
                        _actionReference.action.ReadValue<Vector2>());
                    break;
                default:
                    break;
            }

        }
    }
}