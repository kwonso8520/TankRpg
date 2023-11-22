using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRotation : MonoBehaviour
{
    public float rotationSpeed = 30.0f;
    public float maxVerticalAngle = 45.0f; // �߰�: �ִ� ���� ����
    public float minVerticalAngle = 0; // �߰�: �ּ� ���� ����

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
            // ���콺�� x, y���� �����ɴϴ�.
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            Vector3 currentRotation = turret.transform.rotation.eulerAngles;
            Vector3 currentGunRotation = gunBarrel.transform.rotation.eulerAngles;

            // ���콺�� x���� �̿��Ͽ� turret�� �����̼��� �����մϴ�.
            float newRotationY = currentRotation.y + mouseX * Time.deltaTime;

            // ���콺�� y���� �̿��Ͽ� gunBarrel�� �����̼��� �����մϴ�.
            float newRotationX = currentGunRotation.x - mouseY * Time.deltaTime;

            // ������ �����̼� ���� �����մϴ�.
            turret.transform.rotation = Quaternion.Euler(0, newRotationY, 0);
            gunBarrel.transform.rotation = Quaternion.Euler(newRotationX, newRotationY, 0);
        }
    }
}
