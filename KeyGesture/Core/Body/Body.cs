using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGesture.Core.Body {
    public class Body {
        public BodyPart Head { get; set; }
        public BodyPart Spine { get; set; }
        public BodyPart Hip { get; set; }
        public BodyPart RightShoulder { get; set; }
        public BodyPart RightUpperArm { get; set; }
        public BodyPart RightForeArm { get; set; }
        public BodyPart RightHand { get; set; }
        public BodyPart LeftShoulder { get; set; }
        public BodyPart LeftUpperArm { get; set; }
        public BodyPart LeftForeArm { get; set; }
        public BodyPart LeftHand { get; set; }
        public BodyPart RightHip { get; set; }
        public BodyPart RightThigh { get; set; }
        public BodyPart RightShin { get; set; }
        public BodyPart RightFoot { get; set; }
        public BodyPart LeftHip { get; set; }
        public BodyPart LeftThigh { get; set; }
        public BodyPart LeftShin { get; set; }
        public BodyPart LeftFoot { get; set; }

        public Body(Skeleton skeleton) {
            Head = new BodyPart(skeleton, JointType.ShoulderCenter, JointType.Head);
            Spine = new BodyPart(skeleton, JointType.Spine, JointType.ShoulderCenter);
            Hip = new BodyPart(skeleton, JointType.HipCenter, JointType.Spine);

            RightShoulder = new BodyPart(skeleton, JointType.ShoulderCenter, JointType.ShoulderRight);
            RightUpperArm = new BodyPart(skeleton, JointType.ShoulderRight, JointType.ElbowRight);
            RightForeArm = new BodyPart(skeleton, JointType.ElbowRight, JointType.WristRight);
            RightHand = new BodyPart(skeleton, JointType.WristRight, JointType.HandRight);

            LeftShoulder = new BodyPart(skeleton, JointType.ShoulderCenter, JointType.ShoulderLeft);
            LeftUpperArm = new BodyPart(skeleton, JointType.ShoulderLeft, JointType.ElbowLeft);
            LeftForeArm = new BodyPart(skeleton, JointType.ElbowLeft, JointType.WristLeft);
            LeftHand = new BodyPart(skeleton, JointType.WristLeft, JointType.HandLeft);

            RightHip = new BodyPart(skeleton, JointType.HipCenter, JointType.HipRight);
            RightThigh = new BodyPart(skeleton, JointType.HipRight, JointType.KneeRight);
            RightShin = new BodyPart(skeleton, JointType.KneeRight, JointType.AnkleRight);
            RightFoot = new BodyPart(skeleton, JointType.AnkleRight, JointType.FootRight);

            LeftHip = new BodyPart(skeleton, JointType.HipCenter, JointType.HipLeft);
            LeftThigh = new BodyPart(skeleton, JointType.HipLeft, JointType.KneeLeft);
            LeftShin = new BodyPart(skeleton, JointType.KneeLeft, JointType.AnkleLeft);
            LeftFoot = new BodyPart(skeleton, JointType.AnkleLeft, JointType.FootLeft);
        }
    }
}
