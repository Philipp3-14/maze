using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour
{
    private float stap = 2;
    public GameObject wall;
    public GameObject plant;
    int i, j;
    // Start is called before the first frame update
    void Start()
    {
        for (j = -25; j <= 25; j += 2)
        {
            for (i = -24; i <= 24; i += 2)
            {
                transform.position = new Vector3(j, 0, i);
                Instantiate(plant, transform.position, transform.rotation);

            }
        }
        MakeMazie(25);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void MakeMazie(int sise)
    {
        int i, j;
        int[,] chis = new int[sise, sise];
        for (i = 0; i < sise; i++)
        {
            for (j = 0; j < sise; j++)
            {chis[i, j] = 1;}
        }
        int[] plan = new int[2];
        for (i = 0; i < 2; i++)
        { plan[i] = 0; }
        chis[0, 0] = 0;
        int[] stap = new int[((sise + 1) / 2) * ((sise + 1) / 2)];
        for (i = 0; i < ((sise + 1) / 2) * ((sise + 1) / 2); i++)
        { stap[i] = 0; }
        int con = 1;
        int stapNum = 0;
        while (con < ((sise + 1) / 2) * ((sise + 1) / 2))
        {
            int[] nesw = new int[4];
            for (i = 0; i < 4; i++)
            { nesw[i] = 0; }
            if (plan[0] > 1)
            {
                if (chis[plan[0] - 2, plan[1]] == 1)
                { nesw[0] = 1; }
            }
            if (plan[1] < sise - 1)
            {
                if (chis[plan[0], plan[1] + 2] == 1)
                { nesw[1] = 1; }
            }
            if (plan[0] < sise - 1)
            {
                if (chis[plan[0] + 2, plan[1]] == 1)
                { nesw[2] = 1; }
            }
            if (plan[1] > 1)
            {
                if (chis[plan[0], plan[1] - 2] == 1)
                { nesw[3] = 1; }
            }
            int chaknesw = 0;
            for (i = 0; i < 4; i++)
            {
                if (nesw[i] == 1)
                {
                    chaknesw = 1;
                    break;
                }
            }
            if (chaknesw == 1)
            {
                i = 0;
                int neswNum;
                while (true)
                {
                    neswNum = Random.Range(0, 4);
                    if (nesw[neswNum] == 1)
                    { break; }
                    i++;
                }
                if (neswNum == 0)
                {
                    chis[plan[0] - 1, plan[1]] = 0;
                    chis[plan[0] - 2, plan[1]] = 0;
                    plan[0] = plan[0] - 2;
                }
                else if (neswNum == 1)
                {
                    chis[plan[0], plan[1] + 1] = 0;
                    chis[plan[0], plan[1] + 2] = 0;
                    plan[1] = plan[1] + 2;
                }
                else if (neswNum == 2)
                {
                    chis[plan[0] + 1, plan[1]] = 0;
                    chis[plan[0] + 2, plan[1]] = 0;
                    plan[0] = plan[0] + 2;
                }
                else
                {
                    chis[plan[0], plan[1] - 1] = 0;
                    chis[plan[0], plan[1] - 2] = 0;
                    plan[1] = plan[1] - 2;
                }
                stap[stapNum] = neswNum;
                stapNum++;
                con++;
                /*
                for(i=0;i<5;i++)
                {
                  for(j=0;j<5;j++)
                    {cout<<chis[i][j];}
                  cout<<endl;
                }
                cout<<endl;
                for(i=0;i<9;i++)
                {cout<<stap[i];}
                cout<<endl<<endl;
                */
            }
            else
            {
                stapNum--;
                if (stap[stapNum] == 0)
                { plan[0] = plan[0] + 2; }
                else if (stap[stapNum] == 1)
                { plan[1] = plan[1] - 2; }
                else if (stap[stapNum] == 2)
                { plan[0] = plan[0] - 2; }
                else
                { plan[1] = plan[1] + 2; }
                stap[stapNum] = 0;
            }
        }
        int[,] mazi = new int[sise + 2, sise + 2];
        for (i = 0; i < sise + 2; i++)
        {
            for (j = 0; j < sise + 2; j++)
            { mazi[i, j] = 1; }
        }
        for (i = 0; i < sise; i++)
        {
            for (j = 0; j < sise; j++)
            {
                if (chis[i, j] == 0)
                { mazi[i + 1, j + 1] = 0; }
            }
        }
        for (i = 0; i < sise + 2; i++)
        {
            for (j = 0; j < sise + 2; j++)
            {
                if (mazi[i, j] == 1)
                {
                    Instantiate(wall, new Vector3(2 * i - 26, 1, 2 * j - 26), transform.rotation);
                }
            }
        }
    }
}
