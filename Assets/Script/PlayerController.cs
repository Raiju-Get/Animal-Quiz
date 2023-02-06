using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movement;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position += new Vector3(movement, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.position -= new Vector3(movement, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position += new Vector3(0, movement, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))

        {
            this.transform.position -= new Vector3(0, movement, 0);
        }
    }
}

