using UnityEngine;
using System.Collections;

public class Cells : MonoBehaviour {


    float delaySeconds = 1.0f;
    float time = 0;

    // Use this for initialization
    void Start () {
	
	}

    void Update()
    {

        int[,] NewElements = new int[GRID.H, GRID.W];

            if (time < delaySeconds)
        {
            time += Time.deltaTime;
        }
        else
        {
            FFUpdate(0, 0, NewElements);

            time = 0;



            for (int i = 0; i < GRID.H; i++)
            {
                for (int j = 0; j < GRID.W; j++)
                {
                    // print(NewElements[i, j] + " ");
                    GRID.elements[i, j].loadTexture(NewElements[i, j]);

                    GRID.elements[i, j].Type = NewElements[i, j];

                }
                //print("/n");
            }

        }

    }

    void FFUpdate(int x, int y, int[,] NewElements)
    {

        for (int i=0; i < GRID.H; i++)
            for (int j = 0; j < GRID.W; j++)
            {
                if (GRID.elements[i, j].Type == 2)
                    NewElements[i, j] = 2;
                else
                    NewElements[i, j] = UpdateType(j, i);
            }
    }

    int UpdateType(int x, int y)
    {
        int up = 3;
        int down = 3;
        int left = 3;
        int right = 3;
        int upright = 3;
        int upleft = 3;
        int downright = 3;
        int downleft = 3;

        if (y + 1 < GRID.H)
            up = GRID.elements[y + 1, x].Type;

        if (y - 1 >= 0)
            down = GRID.elements[y - 1, x].Type;

        if (x + 1 < GRID.W)
            right = GRID.elements[y, x + 1].Type;

        if (x - 1 >= 0)
            left = GRID.elements[y, x - 1].Type;

        if (y + 1 < GRID.H && x + 1 < GRID.W)
            upright = GRID.elements[y + 1, x + 1].Type;

        if (y + 1 < GRID.H && x - 1 >= 0)
            upleft = GRID.elements[y + 1, x - 1].Type;

        if (y - 1 >= 0 && x + 1 < GRID.W)
            downright = GRID.elements[y - 1, x + 1].Type;

        if (y - 1 >= 0 && x - 1 >= 0)
            downleft = GRID.elements[y - 1, x - 1].Type;
        
        bool C = isCancer(up, down, left, right, upright, upleft, downright, downleft);

        int Neighbours = NeighbourCount(up, down, left, right, upright, upleft, downright, downleft);

        if (GRID.elements[y, x].Type == 1)
        {
            if (C)
                return 2;

            if (Neighbours > 3)
                return 0;
            else if (Neighbours < 2)
                return 0;
            else
                return 1;
        }
        else
            if (Neighbours == 3)
            return 1;
        else
            return 0;

    }

    int NeighbourCount(int up, int down, int left, int right, int upright, int upleft, int downright, int downleft)
    {
        int count = 0;

        if (up == 1)
            count++;
        if (down == 1)
            count++;
        if (left == 1)
            count++;
        if (right == 1)
            count++;
        if (upright == 1)
            count++;
        if (upleft == 1)
            count++;
        if (downright == 1)
            count++;
        if (downleft == 1)
            count++;

        return count;

    }

    bool isCancer(int up, int down, int left, int right, int upright, int upleft, int downright, int downleft)
    {

        if ((up == 2) || (down == 2) || (left == 2) || (right == 2) || (upright == 2) || (upleft == 2) || (downright == 2) || (downleft == 2))
            return true;

        return false;

    }

}
