using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private Camera playerCamera1;
    [SerializeField] private Camera playerCamera2;
    [SerializeField] private float speed = 5f;

    private void FixedUpdate()
    {
        MoveCheck();
        ZoomCheck();
    }

    private void MoveCheck()
    {
        var moveAD = Input.GetAxis("HorizontalWASD");
        var moveSW = Input.GetAxis("VerticalWASD");
        var moveLeftRight = Input.GetAxis("HorizontalArrow");
        var moveDownUp = Input.GetAxis("VerticalArrow");

        if (moveAD != 0 || moveSW != 0)
            Movement(player1, new Vector3(moveAD, 0, moveSW));
        if (moveLeftRight != 0 || moveDownUp != 0)
            Movement(player2, new Vector3(moveLeftRight, 0, moveDownUp));
    }

    private void ZoomCheck()
    {
        var fow = playerCamera1.fieldOfView;
        if (Input.GetMouseButton(1))
        {
            if (!(fow > 40)) return;
            playerCamera1.fieldOfView -= 1f;
            playerCamera2.fieldOfView -= 1f;
        }
        else
        {
            if (!(fow < 60)) return;
            playerCamera1.fieldOfView += 1f;
            playerCamera2.fieldOfView += 1f;
        }
    }

    private void Movement(Component player, Vector3 dir)
    {
        player.transform.Translate(dir * (speed * Time.fixedDeltaTime));
    }
}