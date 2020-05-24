using System;

namespace Steganography.Web.Helpers
{
    public static class CosineTransform
    {
        public static void DCT(double[] data)
        {
            double[] result = new double[data.Length];
            double c = Math.PI / (2.0 * data.Length);
            double scale = Math.Sqrt(2.0 / data.Length);
            for (int k = 0; k < data.Length; k++)
            {
                double sum = 0;
                for (int n = 0; n < data.Length; n++)
                    sum += data[n] * Math.Cos((2.0 * n + 1.0) * k * c);
                result[k] = scale * sum;
            }
            data[0] = result[0] / Math.Sqrt(2.0);
            for (int i = 1; i < data.Length; i++)
                data[i] = result[i];
        }

        public static void IDCT(double[] data)
        {
            double[] result = new double[data.Length];
            double c = Math.PI / (2.0 * data.Length);
            double scale = Math.Sqrt(2.0 / data.Length);
            for (int k = 0; k < data.Length; k++)
            {
                double sum = data[0] / Math.Sqrt(2.0);
                for (int n = 1; n < data.Length; n++)
                    sum += data[n] * Math.Cos((2 * k + 1) * n * c);

                result[k] = scale * sum;
            }
            for (int i = 0; i < data.Length; i++)
                data[i] = result[i];
        }
    }
}
