using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContiniousMovement : MonoBehaviour
{
    public float speed = 1;
    public XRNode InputSource_move_left;
    //public XRNode InputSource_rotate_right;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float additionalHeight = 0.2f;
    private float fallingSpeed;
    private XROrigin rig;

    private Vector2 InputAxis;
    private CharacterController character;
    // Start is called before the first frame update
    void Start()
    {

        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {

        InputDevice device_left = InputDevices.GetDeviceAtXRNode(InputSource_move_left);
        //InputDevice device_right = InputDevices.GetDeviceAtXRNode(InputSource_rotate_right);
        device_left.TryGetFeatureValue(CommonUsages.primary2DAxis, out InputAxis);
        //device_right.TryGetFeatureValue(CommonUsages.primary2DAxis, out InputAxis);
    }

    private void FixedUpdate()
    {
        CapsuleFollowHeadSet();
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(InputAxis.x, 0, InputAxis.y);
        character.Move(direction * Time.fixedDeltaTime * speed);
        if (CheckIfGrounded())
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;

        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
        //character.
    }

    void CapsuleFollowHeadSet()
    {
        character.height = rig.CameraInOriginSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        return Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
    }
}