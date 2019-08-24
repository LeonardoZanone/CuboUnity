using Assets;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The class that represents the left face of the cube
/// </summary>
public class LeftFace : BaseFace
{
    #region .: Overridden Methods :.
    public override void RotateClockwise<UpFace, FrontFace, DownFace, BackFace>(UpFace Up, FrontFace Front, DownFace Down, BackFace Back)
    {
        Commands.rotating = true;
        this.direction = Vector3.right;
        this.clockwise = true;
        this.rotate = true;

        List<Transform> intUp = Cublets.Intersect(Up.Cublets).ToList();
        List<Transform> intBack = Cublets.Intersect(Back.Cublets).ToList();
        List<Transform> intDown = Cublets.Intersect(Down.Cublets).ToList();
        List<Transform> intFront = Cublets.Intersect(Front.Cublets).ToList();

        Back.Cublets.RemoveAll(_ => intBack.Contains(_));
        Back.Cublets.AddRange(intDown);

        Down.Cublets.RemoveAll(_ => intDown.Contains(_));
        Down.Cublets.AddRange(intFront);

        Front.Cublets.RemoveAll(_ => intFront.Contains(_));
        Front.Cublets.AddRange(intUp);

        Up.Cublets.RemoveAll(_ => intUp.Contains(_));
        Up.Cublets.AddRange(intBack);
    }

    public override void RotateCounterClockwise<UpFace, FrontFace, DownFace, BackFace>(UpFace Up, FrontFace Front, DownFace Down, BackFace Back)
    {
        Commands.rotating = true;
        this.direction = Vector3.right;
        this.clockwise = false;
        this.rotate = true;

        List<Transform> intUp = Cublets.Intersect(Up.Cublets).ToList();
        List<Transform> intBack = Cublets.Intersect(Back.Cublets).ToList();
        List<Transform> intDown = Cublets.Intersect(Down.Cublets).ToList();
        List<Transform> intFront = Cublets.Intersect(Front.Cublets).ToList();

        Back.Cublets.RemoveAll(_ => intBack.Contains(_));
        Back.Cublets.AddRange(intUp);

        Down.Cublets.RemoveAll(_ => intDown.Contains(_));
        Down.Cublets.AddRange(intBack);

        Front.Cublets.RemoveAll(_ => intFront.Contains(_));
        Front.Cublets.AddRange(intDown);

        Up.Cublets.RemoveAll(_ => intUp.Contains(_));
        Up.Cublets.AddRange(intFront);
    }
    #endregion
}
