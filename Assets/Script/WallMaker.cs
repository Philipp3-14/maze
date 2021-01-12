using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour
{
    //private float stap = 2;
    public GameObject wall;
    public GameObject plant;
    int i, j;
    // Start is called before the first frame update
    void Start()
    {
        for (j = 0; j < 2*player.level; j += 2)
        {
            for (i = 0; i < 2 * player.level; i += 2)
            {
                transform.position = new Vector3(j, 0, i);
                Instantiate(plant, transform.position, transform.rotation);

            }
        }
        makeMaze(player.level);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.levelChang)
        {
            for (j = 0; j < 2 * player.level; j += 2)
            {
                for (i = 0; i < 2 * player.level; i += 2)
                {
                    transform.position = new Vector3(j, 0, i);
                    Instantiate(plant, transform.position, transform.rotation);
                }
            }
            makeMaze(player.level);
        }

    }
    void makeMaze(int size)
    {
        int i, j;
        int[,] grid = new int[size, size];
        for (i = 0; i < size; i++)
        {
            for (j = 0; j < size; j++)
            {grid[i, j] = 1;}
        }
        int[] place = new int[2];
        for (i = 0; i < 2; i++)
        { place[i] = 0; }
        grid[0, 0] = 0;
        int[] step = new int[((size + 1) / 2) * ((size + 1) / 2)];
        for (i = 0; i < ((size + 1) / 2) * ((size + 1) / 2); i++)
        { step[i] = 0; }
        int count = 1;
        int stapNum = 0;
        while (count < ((size + 1) / 2) * ((size + 1) / 2))
        {
            int[] direction = new int[4];
            for (i = 0; i < 4; i++)
            { direction[i] = 0; }
            if (place[0] > 1)
            {
                if (grid[place[0] - 2, place[1]] == 1)
                { direction[0] = 1; }
            }
            if (place[1] < size - 1)
            {
                if (grid[place[0], place[1] + 2] == 1)
                { direction[1] = 1; }
            }
            if (place[0] < size - 1)
            {
                if (grid[place[0] + 2, place[1]] == 1)
                { direction[2] = 1; }
            }
            if (place[1] > 1)
            {
                if (grid[place[0], place[1] - 2] == 1)
                { direction[3] = 1; }
            }
            int checkDirection = 0;
            for (i = 0; i < 4; i++)
            {
                if (direction[i] == 1)
                {
                    checkDirection = 1;
                    break;
                }
            }
            if (checkDirection == 1)
            {
                i = 0;
                int directionNumber;
                while (true)
                {
                    directionNumber = Random.Range(0, 4);
                    if (direction[directionNumber] == 1)
                    { break; }
                    i++;
                }
                if (directionNumber == 0)
                {
                    grid[place[0] - 1, place[1]] = 0;
                    grid[place[0] - 2, place[1]] = 0;
                    place[0] = place[0] - 2;
                }
                else if (directionNumber == 1)
                {
                    grid[place[0], place[1] + 1] = 0;
                    grid[place[0], place[1] + 2] = 0;
                    place[1] = place[1] + 2;
                }
                else if (directionNumber == 2)
                {
                    grid[place[0] + 1, place[1]] = 0;
                    grid[place[0] + 2, place[1]] = 0;
                    place[0] = place[0] + 2;
                }
                else
                {
                    grid[place[0], place[1] - 1] = 0;
                    grid[place[0], place[1] - 2] = 0;
                    place[1] = place[1] - 2;
                }
                step[stapNum] = directionNumber;
                stapNum++;
                count++;
            }
            else
            {
                stapNum--;
                if (step[stapNum] == 0)
                { place[0] = place[0] + 2; }
                else if (step[stapNum] == 1)
                { place[1] = place[1] - 2; }
                else if (step[stapNum] == 2)
                { place[0] = place[0] - 2; }
                else
                { place[1] = place[1] + 2; }
                step[stapNum] = 0;
            }
        }
        int[,] maze = new int[size + 2, size + 2];
        for (i = 0; i < size + 2; i++)
        {
            for (j = 0; j < size + 2; j++)
            { maze[i, j] = 1; }
        }
        for (i = 0; i < size; i++)
        {
            for (j = 0; j < size; j++)
            {
                if (grid[i, j] == 0)
                { maze[i + 1, j + 1] = 0; }
            }
        }
        player.levelChang = false;
        for (i = 0; i < size + 2; i++)
        {
            for (j = 0; j < size + 2; j++)
            {
                if (maze[i, j] == 1)
                {
                    Instantiate(wall, new Vector3(2 * i-2, 1, 2 * j-2 ), transform.rotation);
                }
            }
        }
    }
}
