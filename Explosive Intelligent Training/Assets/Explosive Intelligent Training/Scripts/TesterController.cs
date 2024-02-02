using UnityEngine;

public class TesterController : MonoBehaviour
{
    private bool _inputMouseButtonClicked;
    private float _inputMouseX;
    private float _inputMouseY;
    private float _inputX;
    private float _inputY;
    private float _rotX;
    private float _rotY;
    [SerializeField] private float _sensMouseX;
    [SerializeField] private float _sensMouseY;
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedZ;
    [SerializeField] GameObject _testerCamera;
    [SerializeField] private Transform _cameraFollow;

    private void LateUpdate()
    {
        InputUpdate();
    }

    private void Update()
    {
        MoveUpdate();
    }

    private void InputUpdate()
    {
        _inputMouseX = Input.GetAxis("Mouse X");
        _inputMouseY = Input.GetAxis("Mouse Y");
        _inputX = Input.GetAxis("Horizontal");
        _inputY = Input.GetAxis("Vertical");
        _inputMouseButtonClicked = Input.GetMouseButton(0);

        _rotX += _inputMouseY * _sensMouseY * Time.deltaTime;
        _rotX = Mathf.Clamp(_rotX, -50f, 50f);
        _rotY += _inputMouseX * _sensMouseX * Time.deltaTime;

        Quaternion newRotation = Quaternion.Euler(-_rotX, _rotY, 0f);
        _testerCamera.transform.rotation = newRotation;
    }

    private void MoveUpdate()
    {
        _testerCamera.transform.position = _cameraFollow.position;
        Vector3 rot = _testerCamera.transform.eulerAngles;
        rot.x = 0;
        transform.rotation = Quaternion.Euler(rot);
        float MovX = _inputX * Time.deltaTime * _speedX;
        float MovZ = _inputY * Time.deltaTime * _speedZ;

        transform.position += (transform.forward * MovZ + transform.right * MovX);

    }

}
