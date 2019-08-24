using Assets;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The class that represents the up face of the cube
/// </summary>
public class UpFace : BaseFace
{
    #region .: Overridden Methods :.
    public override void RotateClockwise<FrontFace, LeftFace, BackFace, RigthFace>(FrontFace Front, LeftFace Left, BackFace Back, RigthFace Right)
    {
        Commands.rotating = true;
        this.direction = Vector3.up;
        this.clockwise = true;
        this.rotate = true;

        List<Transform> intFront = Cublets.Intersect(Front.Cublets).ToList();
        List<Transform> intLeft = Cublets.Intersect(Left.Cublets).ToList();
        List<Transform> intBack = Cublets.Intersect(Back.Cublets).ToList();
        List<Transform> intRight = Cublets.Intersect(Right.Cublets).ToList();

        Left.Cublets.RemoveAll(_ => intLeft.Contains(_));
        Left.Cublets.AddRange(intFront);

        Back.Cublets.RemoveAll(_ => intBack.Contains(_));
        Back.Cublets.AddRange(intLeft);

        Right.Cublets.RemoveAll(_ => intRight.Contains(_));
        Right.Cublets.AddRange(intBack);

        Front.Cublets.RemoveAll(_ => intFront.Contains(_));
        Front.Cublets.AddRange(intRight);
    }

    public override void RotateCounterClockwise<FrontFace, LeftFace, BackFace, RigthFace>(FrontFace Front, LeftFace Left, BackFace Back, RigthFace Right)
    {
        Commands.rotating = true;
        this.direction = Vector3.up;
        this.clockwise = false;
        this.rotate = true;

        List<Transform> intFront = Cublets.Intersect(Front.Cublets).ToList();
        List<Transform> intLeft = Cublets.Intersect(Left.Cublets).ToList();
        List<Transform> intBack = Cublets.Intersect(Back.Cublets).ToList();
        List<Transform> intRight = Cublets.Intersect(Right.Cublets).ToList();

        Left.Cublets.RemoveAll(_ => intLeft.Contains(_));
        Left.Cublets.AddRange(intBack);

        Back.Cublets.RemoveAll(_ => intBack.Contains(_));
        Back.Cublets.AddRange(intRight);

        Right.Cublets.RemoveAll(_ => intRight.Contains(_));
        Right.Cublets.AddRange(intFront);

        Front.Cublets.RemoveAll(_ => intFront.Contains(_));
        Front.Cublets.AddRange(intLeft);
    } 
    #endregion
}
