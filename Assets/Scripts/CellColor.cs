using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellColor : MonoBehaviour
{
    [SerializeField]
    private GameObject cell;
    private Renderer cellRenderer;
    private Color newCellColor;
    private float col1, col2, col3;
    // Start is called before the first frame update
    void Start()
    {
        cellRenderer = cell.GetComponent<Renderer>();
        col1 = Random.Range(0f, 1f);
        col2 = Random.Range(0f, 1f);
        col3 = Random.Range(0f, 1f);

        newCellColor = new Color(col1, col2, col3);

        cellRenderer.material.SetColor("_Color", newCellColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
