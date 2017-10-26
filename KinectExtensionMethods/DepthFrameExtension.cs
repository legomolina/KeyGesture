using KeyGesture.Core;
using Microsoft.Kinect;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KinectExtensionMethods {
    public static class DepthFrameExtension {
        private static WriteableBitmap bitmap;

        private static int width;
        private static int height;
        private static byte[] colorData;
        private static short[] depthData;

        public static BitmapSource ToBitmap(this DepthImageFrame frame) {
            if (bitmap == null) {
                width = frame.Width;
                height = frame.Height;

                depthData = new short[frame.PixelDataLength];
                colorData = new byte[frame.PixelDataLength * 4];

                bitmap = new WriteableBitmap(width, height, Constants.KinectImageFrameDpi, Constants.KinectImageFrameDpi, PixelFormats.Bgr32, null);
            }

            frame.CopyPixelDataTo(depthData);

            for (int depthIndex = 0, colorIndex = 0; depthIndex < frame.PixelDataLength; depthIndex++, colorIndex += 4) {
                int depthDistance = depthData[depthIndex] >> DepthImageFrame.PlayerIndexBitmaskWidth;

                if (depthDistance < Constants.KinectMaximumDistance) {
                    colorData[colorIndex + Constants.ByteArrayBlueIndex] = 255;
                    colorData[colorIndex + Constants.ByteArrayGreenIndex] = 204;
                    colorData[colorIndex + Constants.ByteArrayRedIndex] = 173;
                }
                else if (depthDistance > Constants.KinectMaximumDistance) {
                    colorData[colorIndex + Constants.ByteArrayBlueIndex] = 173;
                    colorData[colorIndex + Constants.ByteArrayGreenIndex] = 173;
                    colorData[colorIndex + Constants.ByteArrayRedIndex] = 255;
                }
                else {
                    byte monochromeColor = (byte)(255 - (depthDistance >> 5));

                    colorData[colorIndex + Constants.ByteArrayBlueIndex] = monochromeColor;
                    colorData[colorIndex + Constants.ByteArrayGreenIndex] = monochromeColor;
                    colorData[colorIndex + Constants.ByteArrayRedIndex] = monochromeColor;
                }
            }

            bitmap.Lock();
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), colorData, width * 4, 0);
            bitmap.Unlock();

            return bitmap;
        }
    }
}
