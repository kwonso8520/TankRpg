using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRotation : MonoBehaviour
{
    public float rotationSpeed = 30.0f;
    public float maxVerticalAngle = 45.0f; // 추가: 최대 수직 각도
    public float minVerticalAngle = 0; // 추가: 최소 수직 각도

    public GameObject turret;
    public GameObject gunBarrel;

    [SerializeField]
    private ShopTrigger shopTrigger;


    void Update()
    {
        if (!shopTrigger.isShowing)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            // 마우스의 x, y값을 가져옵니다.
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            Vector3 currentRotation = turret.transform.rotation.eulerAngles;
            Vector3 currentGunRotation = gunBarrel.transform.rotation.eulerAngles;

            // 마우스의 x값을 이용하여 turret의 로테이션을 조정합니다.
            float newRotationY = currentRotation.y + mouseX * Time.deltaTime;

            // 마우스의 y값을 이용하여 gunBarrel의 로테이션을 조정합니다.
            float newRotationX = currentGunRotation.x - mouseY * Time.deltaTime;

            // 조정된 로테이션 값을 적용합니다.
            turret.transform.rotation = Quaternion.Euler(0, newRotationY, 0);
            gunBarrel.transform.rotation = Quaternion.Euler(newRotationX, newRotationY, 0);
        }
    }
}
