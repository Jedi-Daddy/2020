using System.Text.RegularExpressions;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
  public string level1 = 
@"1	1	0	1	6	0	0	0	0
 0	0	0	1	0	0	0	1	0
 0	1	0	0	0	1	0	1	0
 0	0	1	0	1	0	0	0	1
 1	0	1	0	0	0	1	0	1
 0	0	0	0	0	1	1	0	1
 0	1	0	0	1	1	0	0	0
 0	1	0	1	0	0	0	1	0
 0	0	0	0	0	1	1	0	0
 1	1	1	0	5	0	0	0	1";

  public Transform character;
  public Transform floor_valid;
  public Transform floor_obstacle;
  public Transform floor_exit;

  public void Start()
  {
    Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
    Debug.Log("Start1");
    var map = ReadFromFile(level1);
    for (int y = 0; y < map.Length; y++)
    {
      for (int x = 0; x < map[y].Length; x++)
      {
        switch (map[y][x])
        {
          case 0:
            Instantiate(floor_valid, new Vector3(x, y, 0), Quaternion.identity);
            break;
          case 1:
            Instantiate(floor_obstacle, new Vector3(x, y, 0), Quaternion.identity);
            break;
          case 5:
            Instantiate(floor_valid, new Vector3(x, y, 0), Quaternion.identity);
            Instantiate(character, new Vector3(x, y, 0), Quaternion.identity);
            break;
          case 6:
            Instantiate(floor_exit, new Vector3(x, y, 0), Quaternion.identity);
            break;
        }
      }
    }
  }

  public int[][] ReadFromFile(string level)
  {
    level = level.Replace("\t", "");
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
