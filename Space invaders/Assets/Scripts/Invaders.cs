﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefab = new Invader[5];

    private int row = 5;
    private int col = 11;

    private Vector3 initialPosition;
    private Vector3 direction = Vector3.right;

    public Missile missilePrefab;

    public Powerup fastershotingPrefab;

    public Powerup stoptimePrefab;


    private void Awake()
    {
        initialPosition = transform.position;
        CreateInvaderGrid();
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), 1.5f, 1.5f); //Hur ofta ska den skjuta iv�g missiler
        InvokeRepeating(nameof(Fastershoting), 20f, 20f);
        InvokeRepeating(nameof(Stoptime), 25f, 25f);
    }

    //Skapar sj�lva griden med alla invaders.
    void CreateInvaderGrid()
    {
        for (int r = 0; r < row; r++)
        {
            float width = 2f * (col - 1);
            float height = 2f * (row - 1);

            //f�r att centerar invaders
            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
            Vector3 rowPosition = new Vector3(centerOffset.x, (2f * r) + centerOffset.y, 0f);

            for (int c = 0; c < col; c++)
            {
                Invader tempInvader = Instantiate(prefab[r], transform);

                Vector3 position = rowPosition;
                position.x += 2f * c;
                tempInvader.transform.localPosition = position;
            }
        }
    }

    //Aktiverar alla invaders igen och placerar fr�n ursprungsposition
    public void ResetInvaders()
    {
        direction = Vector3.right;
        transform.position = initialPosition;

        foreach (Transform invader in transform)
        {
            invader.gameObject.SetActive(true);
        }
    }

    //Skjuter slumpm�ssigt iv�g en missil.
    private void MissileAttack()
    {
        int nrOfInvaders = GetInvaderCount();

        if (nrOfInvaders == 0)
        {
            return;
        }

        foreach (Transform invader in transform)
        {

            if (!invader.gameObject.activeInHierarchy) //om en invader �r d�d ska den inte kunna skjuta...
                continue;


            float rand = UnityEngine.Random.value;
            if (rand< 0.2)
            {
                Instantiate(missilePrefab, invader.position, Quaternion.identity);
                break;
            }
        }

    }

    private void Fastershoting()
    {
        int nrOfInvaders = GetInvaderCount();

        if (nrOfInvaders == 0)
        {
            return;
        }

        foreach (Transform invader in transform)
        {

            if (!invader.gameObject.activeInHierarchy) //om en invader �r d�d ska den inte kunna skjuta...
                continue;


            float rand = UnityEngine.Random.value;
            if (rand < 0.15)
            {
                Instantiate(fastershotingPrefab, invader.position, Quaternion.identity);
                break;
            }
        }

    }

    private void Stoptime()
    {
        int nrOfInvaders = GetInvaderCount();

        if (nrOfInvaders == 0)
        {
            return;
        }

        foreach (Transform invader in transform)
        {

            if (!invader.gameObject.activeInHierarchy) //om en invader �r d�d ska den inte kunna skjuta...
                continue;


            float rand = UnityEngine.Random.value;
            if (rand < 0.2)
            {
                Instantiate(stoptimePrefab, invader.position, Quaternion.identity);
                break;
            }
        }

    }

    //Kollar hur m�nga invaders som lever
    public int GetInvaderCount()
    {
        int nr = 0;

        foreach (Transform invader in transform)
        {
            if (invader.gameObject.activeSelf)
                nr++;
        }
        return nr;
    }

    //Flyttar invaders �t sidan
    void Update()
    {
        float speed = 1f;
        transform.position += speed * Time.deltaTime * direction;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy) //Kolla bara invaders som lever
                continue;

            if (direction == Vector3.right && invader.position.x >= rightEdge.x - 1f)
            {
                AdvanceRow();
                break;
            }
            else if (direction == Vector3.left && invader.position.x <= leftEdge.x + 1f)
            {
                AdvanceRow();
                break;
            }
        }
    }
    //Byter riktning och flytter ner ett steg.
    void AdvanceRow()
    {
        direction = new Vector3(-direction.x, 0, 0);
        Vector3 position = transform.position;
        position.y -= 1f;
        transform.position = position;
    }
}
