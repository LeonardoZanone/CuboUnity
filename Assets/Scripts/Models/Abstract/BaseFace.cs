using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    /// <summary>
    /// Generic class that represent any face of the cube
    /// </summary>
    public abstract class BaseFace : MonoBehaviour
    {

        #region .: Properties :.

        public List<Transform> Cublets = new List<Transform>();
        internal double rotation = 0;
        internal float speedRotation = 2;
        internal bool rotate;
        internal bool clockwise;
        internal Vector3 direction;

        #endregion

        #region .: Abstract Methods :.
        /// <summary>
        /// Rotates this face of the cube 90° clockwise
        /// </summary>
        /// <typeparam name="Face1" name="Face2" name="Face3" name="Face4">The four types of faces that are in contact with this, in clockwise order</typeparam>
        /// <param name="face1" name="face2" name="face3" name="face4">The four faces that are in contact with this, in clockwise order</param>
        public abstract void RotateClockwise<Face1, Face2, Face3, Face4>(Face1 face1,
                                                                Face2 face2,
                                                                Face3 face3,
                                                                Face4 face4) where Face1 : BaseFace where Face2 : BaseFace where Face3 : BaseFace where Face4 : BaseFace;
        /// <summary>
        /// Rotates this face of the cube 90° counter clockwise
        /// </summary>
        /// <typeparam name="Face1" name="Face2" name="Face3" name="Face4">The four types of faces that are in contact with this, in clockwise order</typeparam>
        /// <param name="face1" name="face2" name="face3" name="face4">The four faces that are in contact with this, in clockwise order</param>
        public abstract void RotateCounterClockwise<Face1, Face2, Face3, Face4>(Face1 face1,
                                                                Face2 face2,
                                                                Face3 face3,
                                                                Face4 face4) where Face1 : BaseFace where Face2 : BaseFace where Face3 : BaseFace where Face4 : BaseFace;
        #endregion

        #region .: Public Methods :.
        public void Update()
        {
            if (this.rotate)
            {
                if (clockwise)
                {
                    Cublets.ForEach(_ => _.RotateAround(this.transform.position, this.transform.forward, this.speedRotation));
                }
                else
                {
                    Cublets.ForEach(_ => _.RotateAround(this.transform.position, this.transform.forward, -this.speedRotation));
                }
                this.rotation += this.speedRotation;
            }
            if (Mathf.FloorToInt((float)this.rotation) == 90)
            {
                this.rotate = false;
                this.rotation = 0;
                Commands.rotating = false;
            }
        } 
        #endregion
    }
}
