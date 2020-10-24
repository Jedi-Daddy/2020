﻿using System.Text.RegularExpressions;
using UnityEngine;

public class Map1 : MonoBehaviour
{
  public string level =
 @"1	1	5	1	6	0	0	0	0
 0	0	0	1	0	0	0	1	0
 0	1	0	0	0	1	0	1	0
 0	0	1	0	1	0	0	0	1
 1	0	1	0	0	0	1	0	1
 0	0	0	0	0	1	1	0	1
 0	1	0	0	1	1	0	0	0
 0	1	0	1	0	0	0	1	0
 0	0	0	0	0	1	1	0	0
1	1	1	0	5	0	0	0	1";

  public GameObject character;
  public GameObject floor_valid;
  public GameObject floor_obstacle;
  public GameObject floor_exit;
  public GameObject Parent;

  public void Start()
  {
    Vector3 playerVector = new Vector3(0, 0, 0);
    var map = ReadFromFile(level);
    for (int y = 0; y < map.Length; y++)
    {
      for (int x = 0; x < map[y].Length; x++)
      {
        switch (map[y][x])
        {
          case 0:
            var block = Instantiate(floor_valid, new Vector3(x, map.Length - y, 0), Quaternion.identity);
            block.transform.SetParent(Parent.transform);
            break;
          case 1:
            var obstacle = Instantiate(floor_obstacle, new Vector3(x, map.Length - y, 0), Quaternion.identity);
            obstacle.transform.SetParent(Parent.transform);
            break;
          case 5:
            var characterBackground = Instantiate(floor_valid, new Vector3(x, map.Length - y, 0), Quaternion.identity);
            characterBackground.transform.SetParent(Parent.transform);

            var characterBlock = Instantiate(character, Vector3.zero, Quaternion.identity);
            characterBlock.transform.SetParent(Parent.transform.parent);
            var rectTransform = characterBlock.GetComponent<RectTransform>();
            if (rectTransform != null)
              rectTransform.anchoredPosition = new Vector2(-map[0].Length * 50f + 50f, map.Length * 50f - 50f) +
                                               new Vector2(x * 100f, -y * 100f);

            playerVector = new Vector3(x, map.Length - y, 0);
            break;
          case 6:
            var exit = Instantiate(floor_exit, new Vector3(x, map.Length - y, 0), Quaternion.identity);
            exit.transform.SetParent(Parent.transform);
            break;
        }
      }
    }

    character.GetComponent<RectTransform>().position = playerVector;
  }

  public int[][] ReadFromFile(string level)
  {
    level = level.Replace("\t", "").Replace(" ", "");
    string[] lines = Regex.Split(level, "\r\n");
    int rows = lines.Length;

    int[][] map = new int[rows][];
    for (int i = 0; i < lines.Length; i++)
    {
      map[i] = new int[lines[i].Length];
      for (int j = 0; j < lines[i].Length; j++)
      {
        var x = lines[i][j].ToString();
        map[i][j] = int.Parse(lines[i][j].ToString());
      }
    }

    return map;
  }
}