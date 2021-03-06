﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Singleton
    public static GameManager instance = null;

    public GameObject floor;
    GameObject floorClone;

    // when this (GameManager) is instantiated from Loader, the maze also gets instantiated.
    public Maze maze;

    void Awake () {

        if(instance == null)
        {
            instance = this;
        } else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        floorClone = Instantiate(floor);

        maze = Instantiate(maze);

        maze.SetFloor(floorClone);
        maze.Init();
    }

    private void Start()
    {
        StartCoroutine(maze.CreateMazeInnerLayoutForLevel());
    }
    

}
