using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour {

    public int Type;

    public Sprite[] emptyTextures;

	// Use this for initialization
	void Start () {

        Type = Random.Range(0, 2);

        int x = (int) transform.position.x;
        int y = (int) transform.position.y;

        GRID.elements[x, y] = this;

        if (Type == 1)
            GRID.A++;

        loadTexture(Type);

	}
	
    void OnMouseUpAsButton()
    {
        loadTexture(1);

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        GRID.elements[x, y] = this;

    }

    public void loadTexture(int Texture)
    {
        GetComponent<SpriteRenderer>().sprite = emptyTextures[Texture];
    }

	// Update is called once per frame
	void Update () {
        
        if (GRID.C != 1 && Type == 1)
        {
            bool C = Random.value < 0.00001;
            

            if (C)
            {

                Type = 2;

                loadTexture(2);

                GRID.C++;
            }
        }

	}
}
