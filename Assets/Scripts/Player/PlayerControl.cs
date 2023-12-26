using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Mover mover;
    [SerializeField] private Transform playerTransform;

    [SerializeField][Range(0.1f, 89.9f)] private float maxAnglePlane;
    [SerializeField][Range(-89.9f, 0f)] private float minAnglePlane;

    [SerializeField][Range(0.1f, 89.9f)] private float maxAngle;
    [SerializeField][Range(-89.9f, 0f)] private float minAngle;
    [SerializeField][Min(0.1f)] private float timePlaneSec;
    [SerializeField][Min(0.1f)] private float speedRotationUp;
    [SerializeField][Min(0.1f)] private float speedRotationDown;


    private bool isFalls = false;
    private float yInput = 0f;

    public void StrartMove(Rigidbody rb)
    {
        mover.StartMover(rb);
    }

    public void OnStartInput()
    {
        isFalls = false;
    }

    public void OnChengetInput(Vector2 direction)
    {
        isFalls = false;
        mover.SetPawerFactor((direction.x + 2) / 2);
        yInput = direction.y;
    }

    public void OnStopInput()
    {
        isFalls = true; 
    }  

    private void FixedUpdate()
    {
        if (!isFalls)
        {
            if (yInput > 0f && playerTransform.eulerAngles.z < maxAngle)
            {
                Rotation(yInput * speedRotationUp * Time.fixedDeltaTime);
            }
            else if (yInput < 0f )
            {
                if(playerTransform.eulerAngles.z - 360 > minAngle ||
                    playerTransform.eulerAngles.z < maxAngle)
                Rotation(yInput * speedRotationDown * Time.fixedDeltaTime);
            }
            else { return; }
        }
        else
        {
            if (transform.eulerAngles.z >= maxAnglePlane)
            {

            }
            else if (transform.eulerAngles.z < maxAnglePlane &&
                transform.eulerAngles.z > minAnglePlane)
            {

            }
            else
            {

            }
        }
    }

    private void Rotation(float angles)
    {
        Vector3 rotate = playerTransform.eulerAngles;
        rotate.z += angles;
        playerTransform.rotation = Quaternion.Euler(rotate);
    }
}
