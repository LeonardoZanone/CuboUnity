using Assets;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class that controls the inputs to rotate the cube
/// </summary>
public class Commands : MonoBehaviour
{
    public static bool rotating;
    private Dictionary<Faces, BaseFace> faces = new Dictionary<Faces, BaseFace>();
    public Transform Cube;
    void Start()
    {
        faces.Add(Faces.Front, FindObjectOfType<FrontFace>());
        faces.Add(Faces.Back, FindObjectOfType<BackFace>());
        faces.Add(Faces.Left, FindObjectOfType<LeftFace>());
        faces.Add(Faces.Right, FindObjectOfType<RightFace>());
        faces.Add(Faces.Up, FindObjectOfType<UpFace>());
        faces.Add(Faces.Down, FindObjectOfType<DownFace>());
    }

    void Update()
    {
        if (!rotating)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    faces[Faces.Front].RotateCounterClockwise(faces[Faces.Up], faces[Faces.Right], faces[Faces.Down], faces[Faces.Left]);
                }
                else if (Input.GetKeyDown(KeyCode.U))
                {
                    faces[Faces.Up].RotateCounterClockwise(faces[Faces.Front], faces[Faces.Left], faces[Faces.Back], faces[Faces.Right]);
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    faces[Faces.Right].RotateCounterClockwise(faces[Faces.Up], faces[Faces.Back], faces[Faces.Down], faces[Faces.Front]);
                }
                else if (Input.GetKeyDown(KeyCode.B))
                {
                    faces[Faces.Back].RotateCounterClockwise(faces[Faces.Up], faces[Faces.Left], faces[Faces.Down], faces[Faces.Right]);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    faces[Faces.Down].RotateCounterClockwise(faces[Faces.Front], faces[Faces.Right], faces[Faces.Back], faces[Faces.Left]);
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    faces[Faces.Left].RotateCounterClockwise(faces[Faces.Up], faces[Faces.Front], faces[Faces.Down], faces[Faces.Back]);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    faces[Faces.Front].RotateClockwise(faces[Faces.Up], faces[Faces.Right], faces[Faces.Down], faces[Faces.Left]);
                }
                else if (Input.GetKeyDown(KeyCode.U))
                {
                    faces[Faces.Up].RotateClockwise(faces[Faces.Front], faces[Faces.Left], faces[Faces.Back], faces[Faces.Right]);
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    faces[Faces.Right].RotateClockwise(faces[Faces.Up], faces[Faces.Back], faces[Faces.Down], faces[Faces.Front]);
                }
                else if (Input.GetKeyDown(KeyCode.B))
                {
                    faces[Faces.Back].RotateClockwise(faces[Faces.Up], faces[Faces.Left], faces[Faces.Down], faces[Faces.Right]);
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    faces[Faces.Down].RotateClockwise(faces[Faces.Front], faces[Faces.Right], faces[Faces.Back], faces[Faces.Left]);
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    faces[Faces.Left].RotateClockwise(faces[Faces.Up], faces[Faces.Front], faces[Faces.Down], faces[Faces.Back]);
                }
            }
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Cube.Rotate(0f, 3f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Cube.Rotate(0f, -3f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Cube.Rotate(-3f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Cube.Rotate(3f, 0f, 0f);
        }

    }
}
