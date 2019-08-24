using Assets;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The class that represents the front face of the cube
/// </summary>
public class FrontFace : BaseFace
{
    #region .: Overridden Methods :.
    public override void RotateClockwise<UpFace, RightFace, DownFace, LeftFace>(UpFace Up, RightFace Right, DownFace Down, LeftFace Left)
    {
        Commands.rotating = true;
        this.direction = Vector3.forward;
        this.clockwise = true;
        this.rotate = true;

        List<Transform> intUp = Cublets.Intersect(Up.Cublets).ToList();
        List<Transform> intRight = Cublets.Intersect(Right.Cublets).ToList();
        List<Transform> intDown = Cublets.Intersect(Down.Cublets).ToList();
        List<Transform> intLeft = Cublets.Intersect(Left.Cublets).ToList();

        Right.Cublets.RemoveAll(_ => intRight.Contains(_));
        Right.Cublets.AddRange(intUp);

        Down.Cublets.RemoveAll(_ => intDown.Contains(_));
        Down.Cublets.AddRange(intRight);

        Left.Cublets.RemoveAll(_ => intLeft.Contains(_));
        Left.Cublets.AddRange(intDown);

        Up.Cublets.RemoveAll(_ => intUp.Contains(_));
        Up.Cublets.AddRange(intLeft);
    }

    public override void RotateCounterClockwise<UpFace, RightFace, DownFace, LeftFace>(UpFace Up, RightFace Right, DownFace Down, LeftFace Left)
    {
        Commands.rotating = true;
        this.direction = Vector3.forward;
        this.clockwise = false;
        this.rotate = true;

        List<Transform> intUp = Cublets.Intersect(Up.Cublets).ToList();
        List<Transform> intRight = Cublets.Intersect(Right.Cublets).ToList();
        List<Transform> intDown = Cublets.Intersect(Down.Cublets).ToList();
        List<Transform> intLeft = Cublets.Intersect(Left.Cublets).ToList();

        Right.Cublets.RemoveAll(_ => intRight.Contains(_));
        Right.Cublets.AddRange(intDown);

        Down.Cublets.RemoveAll(_ => intDown.Contains(_));
        Down.Cublets.AddRange(intLeft);

        Left.Cublets.RemoveAll(_ => intLeft.Contains(_));
        Left.Cublets.AddRange(intUp);

        Up.Cublets.RemoveAll(_ => intUp.Contains(_));
        Up.Cublets.AddRange(intRight);
    } 
    #endregion
}
