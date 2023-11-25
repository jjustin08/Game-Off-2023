using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    public Transform leftFoot;
    public Transform rightFoot;
    public Transform body;
    public Transform leftHand;
    public Transform rightHand;

    private Vector3 StartPosLeftFoot;
    private Vector3 StartPosRightFoot;
    private Vector3 StartPosBody;
    private Vector3 StartPosLeftHand;
    private Vector3 StartPosRightHand;

    [SerializeField] float maxDistance = 10f;

    private void Start()
    {
        StartPosLeftFoot = leftFoot.localPosition;
        StartPosRightFoot = rightFoot.localPosition;
        StartPosBody = body.localPosition;
        StartPosLeftHand= leftHand.localPosition;
        StartPosRightHand= rightHand.localPosition;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ScambleBody(maxDistance);
        }
    }

    public void ScambleBody(float distance)
    {
        SetRandomPosition(leftFoot, StartPosLeftFoot, distance);
        SetRandomPosition(rightFoot, StartPosRightFoot, distance);
        SetRandomPosition(body, StartPosBody, distance);
        SetRandomPosition(leftHand, StartPosLeftHand, distance);
        SetRandomPosition(rightHand, StartPosRightHand, distance);
    }

    private void SetRandomPosition(Transform bodyPart, Vector3 startPos, float distance)
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-distance, distance) + startPos.x,
            Random.Range(-distance, distance) + startPos.y,
            0
        );

        bodyPart.localPosition = randomOffset;
    }



    public bool CompareOtherBody(BodyPosition otherBody, float maxDistance)
    {
        float distance = 0f;

        distance += Vector3.Distance(leftFoot.position, otherBody.leftFoot.position);
        distance += Vector3.Distance(rightFoot.position, otherBody.rightFoot.position);
        distance += Vector3.Distance(body.position, otherBody.body.position);
        distance += Vector3.Distance(leftHand.position, otherBody.leftHand.position);
        distance += Vector3.Distance(rightHand.position, otherBody.rightHand.position);


        return distance <= maxDistance;
    }




}
