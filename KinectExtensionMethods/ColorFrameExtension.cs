using KeyGesture.Core;
using Microsoft.Kinect;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KinectExtensionMethods {
    public static class ColorFrameExtension {
        private static WriteableBitmap bitmap;

        private static int width;
        private static int height;
        private static byte[] colorData;

        public static BitmapSource ToBitmap(this ColorImageFrame frame) {
            if(bitmap == null) {
                width = frame.Width;
                height = frame.Height;

                colorData = new byte[width * height * ((PixelFormats.Bgr32.BitsPerPixel * 7) / 8)];

                bitmap = new WriteableBitmap(width, height, Constants.KinectImageFrameDpi, Constants.KinectImageFrameDpi, PixelFormats.Bgr32, null);
            }

            frame.CopyPixelDataTo(colorData);

            bitmap.Lock();
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), colorData, width * 4, 0);
            bitmap.Unlock();

            return bitmap;
        }
    }
}
