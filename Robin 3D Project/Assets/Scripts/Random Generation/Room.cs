using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Direction direction;
    [SerializeField] private Transform anchorPoint;
    [SerializeField] private Transform tilemaps;

    [Space(10)]
    [SerializeField] private Transform forwardPoint;
    [SerializeField] private Transform backPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform leftPoint;

    [Space(10)]
    [SerializeField] private RoomChecker forwardChecker;
    [SerializeField] private RoomChecker backChecker;
    [SerializeField] private RoomChecker rightChecker;
    [SerializeField] private RoomChecker leftChecker;

    private MapGenerator mapGenerator;
    private Transform spawnPoint;

    private void Start()
    {
        mapGenerator = MapGenerator.Instance;

        mapGenerator.OnMaxRoomCountReached += () =>
        {
            StopCoroutine(SetRandomDirection());
            Debug.Log("Stopped Coroutine !");
        };
    }

    private void OnDisable()
    {
        mapGenerator.OnMaxRoomCountReached -= () =>
        {
            StopCoroutine(SetRandomDirection());
            Debug.Log("Stopped Coroutine !");
        };
    }

    public IEnumerator SetRandomDirection()
    {
        KIDOS();

        yield return new WaitForSeconds(1f);

        direction = (Direction)Random.Range(0, 4);

        Debug.Log("Get direction : " + direction);

        switch (direction)
        {
            case Direction.Forward:

                if (forwardChecker.IsBusy)
                {
                    yield return SetRandomDirection();
                }
                else if(!forwardChecker.IsBusy)
                {
                    yield return new WaitForSeconds(mapGenerator.SpawnCooldown);
                    spawnPoint = forwardPoint;
                    CreateCorridor();
                }

                break;

            case Direction.Back:

                if (backChecker.IsBusy)
                {
                    yield return SetRandomDirection();
                }
                else if (!backChecker.IsBusy)
                {
                    yield return new WaitForSeconds(mapGenerator.SpawnCooldown);
                    spawnPoint = backPoint;
                    CreateCorridor();
                }
                break;

            case Direction.Right:

                if (rightChecker.IsBusy)
                {
                    yield return SetRandomDirection();
                }
                else if (!rightChecker.IsBusy)
                {
                    yield return new WaitForSeconds(mapGenerator.SpawnCooldown);
                    spawnPoint = rightPoint;
                    CreateCorridor();
                }
                break;

            case Direction.Left:

                if (leftChecker.IsBusy)
                {
                    yield return SetRandomDirection();
                }
                else if (!leftChecker.IsBusy)
                {
                    yield return new WaitForSeconds(mapGenerator.SpawnCooldown);
                    spawnPoint = leftPoint;
                    CreateCorridor();
                }
                break;
        }
    }

    private void KIDOS()
    {
        forwardPoint.SetParent(transform);
        backPoint.SetParent(transform);
        rightPoint.SetParent(transform);
        leftPoint.SetParent(transform);
    }

    public void SetOffset(Direction direction)
    {
        float distance = Vector3.Distance(transform.position,
            anchorPoint.position);

        

        switch (direction)
        {
            case Direction.Forward:

                //tilemaps.rotation = Quaternion.Euler(0, 0, 0);

                transform.position = new Vector3(transform.position.x,
                5.5f,
                transform.position.z + distance);

                break;

            case Direction.Back:

                //tilemaps.rotation = Quaternion.Euler(0, -180, 0);

                transform.position = new Vector3(transform.position.x,
                5.5f,
                transform.position.z - distance);

                break;

            case Direction.Right:

                //tilemaps.rotation = Quaternion.Euler(0, 90, 0);

                transform.position = new Vector3(transform.position.x + distance,
                5.5f,
                transform.position.z);

                break;

            case Direction.Left:

                //tilemaps.rotation = Quaternion.Euler(0, -90, 0);

                transform.position = new Vector3(transform.position.x - distance,
                5.5f,
                transform.position.z);

                break;
        }

        StartCoroutine(SetRandomDirection());
    }

    private void CreateCorridor()
    {
        if (!mapGenerator.IsMaxRoomCountReached)
        {
            Corridor corridor = Instantiate(mapGenerator.corridor,
            new Vector3(spawnPoint.position.x, 5.5f, spawnPoint.position.z),
            spawnPoint.rotation);

            corridor.transform.SetParent(mapGenerator.transform);
            corridor.StartCoroutine(corridor.SetOffset(direction, mapGenerator));
        }

        
    }

}

public enum Direction
{
    Forward,
    Back,
    Right,
    Left
}
