using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Dictionary<Direction, int> _rotationByDirection = new() 
    {
        { Direction.North, 0 }, // also 360
        { Direction.East, 90 },
        { Direction.South, 180 },
        { Direction.West, 270 }
    };
    private Direction _facingDirection;
    private bool _isRotating = false;

    // smooth rotation
    [SerializeField] private float RotationTime = 0.5f;
    private float _rotationTimer = 0.0f;
    private Quaternion _previousRotation;

    private RoomBase _currentRoom = null;

    // smooth movement
    [SerializeField] private float MovementTime = 2.0f;
    private bool _isMoving = false;
    private float _movementTimer = 0.0f;
    private Vector3 _previousPosition;
    private Vector3 _moveToPosition;

    public void Setup()
    {
        // simple array of all directions
        Direction[] directions = new Direction[] { Direction.North, Direction.East, Direction.South, Direction.North };
        // roll a random direction
        _facingDirection = directions[UnityEngine.Random.Range(0, directions.Length)];
        // Update the transform
        SetFacingDirection();
    }

    private void SetFacingDirection()
    {
        // Note: transform.rotation is type "Quaternion", we hate working with those
        // Get the transform's rotation, use eulerAngles for easier math (Vector3)
        Vector3 facing = transform.rotation.eulerAngles;
        // Set the y value
        facing.y = _rotationByDirection[_facingDirection];
        // save the rotation back, converting it to a Quaternion first
        transform.rotation = Quaternion.Euler(facing);
    }

    private void Update()
    {
        if (_isMoving)
        {
            Vector3 currentPosition = Vector3.Slerp(_previousPosition, _moveToPosition, _movementTimer / MovementTime);

            transform.position = currentPosition;

            _movementTimer += Time.deltaTime;

            if (_movementTimer > MovementTime)
            {
                _isMoving = false;
                _movementTimer = 0.0f;
                transform.position = _moveToPosition; // snap to final position
            }
        }
        if (_isRotating)
        {
            // Continue the movement until is is finished
            // Quaternion.Lerp for Linear movement, Quaternion.Slerp for smoothed movement
            Quaternion currentRotation = Quaternion.Slerp(
                _previousRotation, 
                Quaternion.Euler(new Vector3(0, _rotationByDirection[_facingDirection])),
                _rotationTimer / RotationTime);

            transform.rotation = currentRotation;

            _rotationTimer += Time.deltaTime;

            if (_rotationTimer > RotationTime)
            {
                _isRotating = false;
                _rotationTimer = 0.0f;
                SetFacingDirection(); // snap to final rotation
            }
        }
        else
        {
            // GetKeyDown is per-press basis. "Was the button pressed *this* frame?"
            bool rotateLeft = Input.GetKeyDown(KeyCode.A);
            bool rotateRight = Input.GetKeyDown(KeyCode.D);
            // ensure one or the other is true, not both
            if (rotateLeft && !rotateRight)
            {
                TurnLeft();
            }
            else if (rotateRight && !rotateLeft)
            {
                TurnRight();
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                if (_currentRoom != null)
                {
                    _currentRoom.OnRoomSearched();
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                RoomBase roomInFacingDirection = NextRoomInDirection();
                if (roomInFacingDirection != null)
                {
                    StartMovement(roomInFacingDirection);
                }
            }
        }
    }

    private void StartMovement(RoomBase targetRoom)
    {
        // don't overwrite _currentRoom, since that is done by the trigger
        _previousPosition = transform.position;
        _moveToPosition = targetRoom.transform.position;
        _isMoving = true;
    }

    private RoomBase NextRoomInDirection()
    {
        if (_currentRoom == null)
            return null;

        switch (_facingDirection)
        {
            case Direction.North:
                return _currentRoom.North;
            case Direction.East:
                return _currentRoom.East;
            case Direction.South:
                return _currentRoom.South;
            case Direction.West:
                return _currentRoom.West;
            default:
                Debug.LogError("Error: Unknown Direction!");
                return null;
        }
    }

    // Counterclockwise
    private void TurnLeft()
    {
        switch (_facingDirection)
        {
            case Direction.South:
                _facingDirection = Direction.East;
                break;
            case Direction.North:
                _facingDirection = Direction.West;
                break;
            case Direction.East:
                _facingDirection = Direction.North;
                break;
            case Direction.West:
                _facingDirection = Direction.South;
                break;
        }
        StartRotating();
    }

    // Clockwise
    private void TurnRight()
    {
        switch (_facingDirection)
        {
            case Direction.South:
                _facingDirection = Direction.West;
                break;
            case Direction.North:
                _facingDirection = Direction.East;
                break;
            case Direction.East:
                _facingDirection = Direction.South;        
                break;
            case Direction.West:
                _facingDirection = Direction.North;
                break;
        }
        StartRotating();
    }

    private void StartRotating()
    {
        _previousRotation = transform.rotation;
        _isRotating = true;
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        _currentRoom = otherObject.GetComponent<RoomBase>();
        _currentRoom.OnRoomEntered();
    }

    private void OnTriggerExit(Collider otherObject)
    {
        RoomBase exitingRoom = otherObject.GetComponent<RoomBase>();
        exitingRoom.OnRoomExited();
    }
}
