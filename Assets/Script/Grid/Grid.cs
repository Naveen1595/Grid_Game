using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int rows = 10;
    [SerializeField] private int columns = 10;
    [SerializeField] private int scale = 1;
    [SerializeField] private GameObject gridPrefabs;
    [SerializeField] private GameObject PlayerPrefabs;
    [SerializeField] private Vector2 leftBottomLocation = new Vector2(0, 0);
    [SerializeField] private GameObject[,] gridArray;

    private void Awake()
    {
        gridArray = new GameObject[columns, rows];
        if (gridPrefabs)
            GenerateGrid();             //if grid Prefabs is present then only generate
        else
            print("missing gridprefabs");


    }


    private void Start()
    {
        PlayerPrefabs.transform.localScale += new Vector3(2*scale, 2*scale, 0);             //Change Scale of Player as per Grid Scale
    }

    //Generate Grid Dynamically
    private void GenerateGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPrefabs, new Vector2(leftBottomLocation.x +  scale * i, leftBottomLocation.y + scale * j), Quaternion.identity);
                obj.transform.localScale = new Vector2(scale, scale);       //change scale
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStats>().x = obj.transform.position.x;
                obj.GetComponent<GridStats>().y = obj.transform.position.y;
                gridArray[i, j] = obj;
            }
        }
    }

}