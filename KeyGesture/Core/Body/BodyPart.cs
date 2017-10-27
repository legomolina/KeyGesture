using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;

namespace KeyGesture.Core.Body {
    public class BodyPart {
        private Joint startJoint;
        private Joint endJoint;
        private Vector4 rotation;
        private Point3D position;

        public Joint StartJoint {
            get => startJoint;
        }

        public Joint EndJoint {
            get => endJoint;
        }

        public Vector4 Rotation {
            get => rotation;
        }

        public Point3D Position {
            get => position;
        }

        public BodyPart(Skeleton skeleton, JointType startJoint, JointType endJoint) {
            this.startJoint = skeleton.Joints[startJoint];
            this.endJoint = skeleton.Joints[endJoint];

            this.position = new Point3D {
                X = (this.startJoint.Position.X - this.endJoint.Position.X) / 2,
                Y = (this.startJoint.Position.Y - this.endJoint.Position.Y) / 2,
                Z = (this.startJoint.Position.Z - this.endJoint.Position.Z) / 2
            };

            this.rotation = skeleton.BoneOrientations[startJoint].HierarchicalRotation.Quaternion;
        }

        public bool Contains(Joint joint) {
            return StartJoint == joint || EndJoint == joint;
        }

        public bool IsAdjacent(BodyPart part) {
            return Contains(part.StartJoint) || Contains(part.EndJoint);
        }
    }
}
