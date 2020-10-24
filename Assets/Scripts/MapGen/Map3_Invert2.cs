using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Map3_Invert2 : MonoBehaviour, IMap
{
  private class PlayerPosition
  {
    public int x;
    public int y;
  }
  private PlayerPosition _playerPosition;

  public static Map3_Invert2 Instance;
  private int[][] _map;

  private string level =
@"2	0	1	1	6	0	1	0	1
0	0	0	0	0	0	0	0	0
1	0	0	0	2	1	0	2	0
0	0	0	2	0	0	0	0	2
1	2	0	0	0	1	0	0	0
0	2	0	1	0	2	1	2	0
0	1	0	2	1	0	0	1	0
0	0	0	0	0	0	0	0	0
0	0	1	0	0	2	1	0	0
2	1	2	0	5	2	2	1	1";

  public GameObject character;
  public GameObject floor_valid;
  public GameObject floor_obstacle;
  public GameObject floor_exit;
  public GameObject floor_empty;
  public GameObject Parent;
    public Swipe Swipe;
    public void Awake()
  {
    Instance = this;
    _map = ReadFromFile(level);
    for (int y = 0; y < _map.Length; y++)
    {
      for (int x = 0; x < _map[y].Length; x++)
      {
        switch (_map[y][x])
        {
          case 0:
            var block = Instantiate(floor_valid, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
            block.transform.SetParent(Parent.transform);
            break;
          case 2:
            var obstacle = Instantiate(floor_obstacle, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
            obstacle.transform.SetParent(Parent.transform);
            break;
          case 1:
            var empty = Instantiate(floor_empty, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
            empty.transform.SetParent(Parent.transform);
            break;
          case 5:
            var characterBackground = Instantiate(floor_valid, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
            characterBackground.transform.SetParent(Parent.transform);

            var characterBlock = Instantiate(character, Vector3.zero, Quaternion.identity);
            characterBlock.transform.SetParent(Parent.transform.parent);
            var rectTransform = characterBlock.GetComponent<RectTransform>();
            if (rectTransform != null)
              rectTransform.anchoredPosition = new Vector2(-_map[0].Length * 50f + 50f, _map.Length * 50f - 50f) +
                                               new Vector2(x * 100f, -y * 100f);

            characterBlock.GetComponentInChildren<Player>().SetMap(this);
            _playerPosition = new PlayerPosition { x = x, y = y };
            break;
          case 6:
            var exit = Instantiate(floor_exit, new Vector3(x, _map.Length - y, 0), Quaternion.identity);
            exit.transform.SetParent(Parent.transform);
            break;
        }
      }
    }
    }

    private void OnEnable()
    {
        Swipe.FindPlayers();
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

  public bool CanGo(int x, int y)
  {
    try
    {
      var newX = _playerPosition.x + x;
      var newY = _playerPosition.y - y;

      var canGo = _map[newY][newX] != 2;

      if (canGo)
      {
        _playerPosition.x = newX;
        _playerPosition.y = newY;
      }

      return canGo;
    }
    catch (Exception ex)
    {
      return false;
    }
  }
  public bool IsFinish()
  {
    return _map[_playerPosition.y][_playerPosition.x] == 6;
  }
  public bool IsDead()
  {
    return _map[_playerPosition.y][_playerPosition.x] == 1;
  }
}
