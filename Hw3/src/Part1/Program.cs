using System;
using System.Drawing;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace Deneme{

    class Homography{

        public static DenseMatrix matrix;

        static void Main(string[] args){
            
            double [,] dst = new double[4,2]{
                {0, 0},
                {900, 0},
                {900, 700},
                {0, 700}
            };

            ProcessImage1("Homework_3_img1.JPG", dst);
            ProcessImage2("Homework_3_img2.JPG", dst);
            ProcessImage3("Homework_3_img3.JPG", dst);
        }

        static void ProcessImage1(String imagePath,double [,] dst){
            
            Image image1 = Image.FromFile(imagePath);
            double[,] src1 = new double[4,2]{
                {500, 1970},
                {520, 350},
                {2600, 350},
                {2600, 1970}
            };
            double[] S1_1 = new double[2]{ 850, 710 };
            double[] S2_1 = new double[2]{ 1120, 1200 };
            double[] S3_1 = new double[2]{ 2500, 1900 };

            Graphics g1 = Graphics.FromImage(image1);
            Pen p = new Pen(Color.Red, 5);
            g1.FillEllipse(p.Brush, Convert.ToInt32(src1[0,0]), Convert.ToInt32(src1[0,1]), 40, 40);
            g1.FillEllipse(p.Brush, Convert.ToInt32(src1[1,0]), Convert.ToInt32(src1[1,1]), 40, 40);
            g1.FillEllipse(p.Brush, Convert.ToInt32(src1[2,0]), Convert.ToInt32(src1[2,1]), 40, 40);
            g1.FillEllipse(p.Brush, Convert.ToInt32(src1[3,0]), Convert.ToInt32(src1[3,1]), 40, 40);

            g1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g1.DrawString("S1", new Font("Arial", 50), p.Brush, Convert.ToInt32(S1_1[0]), Convert.ToInt32(S1_1[1]));
            g1.DrawString("S2", new Font("Arial", 50), p.Brush, Convert.ToInt32(S2_1[0]), Convert.ToInt32(S2_1[1]));
            g1.DrawString("S3", new Font("Arial", 50), p.Brush, Convert.ToInt32(S3_1[0]), Convert.ToInt32(S3_1[1]));
            
            // SAVE IMAGE
            image1.Save("Homework_3_img1_result.JPG");
            
            double[,] H;
            H = CalculateHomograpy(src1, dst);

            // print homography matrix
            Console.WriteLine();
            Console.WriteLine("Homography Matrix for Image 1");
            for(int i = 0; i < H.GetLength(0); i++){
                for(int j = 0; j < H.GetLength(1); j++){
                    Console.Write(H[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // calculate S1, S2, S3
            Console.WriteLine("Projection of S1, S2, S3 for Image 1");
            double[,] point1 = CalculateProjectionOfPoint(S1_1, H);
            double[,] point2 = CalculateProjectionOfPoint(S2_1, H);
            double[,] point3 = CalculateProjectionOfPoint(S3_1, H);

            Console.WriteLine("S1: " + S1_1[0] + " " + + S1_1[1]);
            Console.WriteLine("S1: " + point1[0,0] + " " + point1[1,0]);

            Console.WriteLine("S1: " + S2_1[0] + " " + + S2_1[1]);
            Console.WriteLine("S2: " + point2[0,0] + " " + point2[1,0]);

            Console.WriteLine("S1: " + S3_1[0] + " " + + S3_1[1]);
            Console.WriteLine("S3: " + point3[0,0] + " " + point3[1,0]);
            Console.WriteLine();
        }

        static void ProcessImage2(String imagePath, double[,] dst){
            
            Image image2 = Image.FromFile(imagePath);
            double[,] src2 = new double[4,2]{
                {480, 2150},
                {430, 480},
                {2680, 500},
                {2600, 2180}
            };

            double[] S1_2 = new double[2]{ 820, 850 };
            double[] S2_2 = new double[2]{ 1080, 1380 };
            double[] S3_2 = new double[2]{ 2500, 2100 };

            Graphics g2 = Graphics.FromImage(image2);
            Pen p = new Pen(Color.Red, 5);
            g2.FillEllipse(p.Brush, Convert.ToInt32(src2[0,0]), Convert.ToInt32(src2[0,1]), 40, 40);
            g2.FillEllipse(p.Brush, Convert.ToInt32(src2[1,0]), Convert.ToInt32(src2[1,1]), 40, 40);
            g2.FillEllipse(p.Brush, Convert.ToInt32(src2[2,0]), Convert.ToInt32(src2[2,1]), 40, 40);
            g2.FillEllipse(p.Brush, Convert.ToInt32(src2[3,0]), Convert.ToInt32(src2[3,1]), 40, 40);

            g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g2.DrawString("S1", new Font("Arial", 50), p.Brush, Convert.ToInt32(S1_2[0]), Convert.ToInt32(S1_2[1]));
            g2.DrawString("S2", new Font("Arial", 50), p.Brush, Convert.ToInt32(S2_2[0]), Convert.ToInt32(S2_2[1]));
            g2.DrawString("S3", new Font("Arial", 50), p.Brush, Convert.ToInt32(S3_2[0]), Convert.ToInt32(S3_2[1]));

            // SAVE IMAGE
            image2.Save("Homework_3_img2_result.JPG");

            double[,] H;
            H = CalculateHomograpy(src2, dst);

            // print homography matrix
            Console.WriteLine();
            Console.WriteLine("Homography Matrix for Image 2");
            for(int i = 0; i < H.GetLength(0); i++){
                for(int j = 0; j < H.GetLength(1); j++){
                    Console.Write(H[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // calculate S1, S2, S3
            Console.WriteLine("Projection of S1, S2, S3 for Image 2");
            double[,] point1 = CalculateProjectionOfPoint(S1_2, H);
            double[,] point2 = CalculateProjectionOfPoint(S2_2, H);
            double[,] point3 = CalculateProjectionOfPoint(S3_2, H);

            Console.WriteLine("S1: " + S1_2[0] + " " + + S1_2[1]);
            Console.WriteLine("S1: " + point1[0,0] + " " + point1[1,0]);

            Console.WriteLine("S1: " + S2_2[0] + " " + + S2_2[1]);
            Console.WriteLine("S2: " + point2[0,0] + " " + point2[1,0]);

            Console.WriteLine("S1: " + S3_2[0] + " " + + S3_2[1]);
            Console.WriteLine("S3: " + point3[0,0] + " " + point3[1,0]);
            Console.WriteLine();

            Console.WriteLine("Source of S1, S2, S3 for Image 2");

        }

        static void ProcessImage3(String imagePath, double[,] dst){

            Image image3 = Image.FromFile(imagePath);
            
            double[,] src3 = new double[4,2]{
                {580, 1930},
                {700, 280},
                {2590, 490},
                {2650, 1930}
            };

            double[] S1_3 = new double[2]{ 1050, 650 };
            double[] S2_3 = new double[2]{ 1260, 1150 };
            double[] S3_3 = new double[2]{ 2580, 1880 };

            Graphics g3 = Graphics.FromImage(image3);
            Pen p = new Pen(Color.Red, 5);
            g3.FillEllipse(p.Brush, Convert.ToInt32(src3[0,0]), Convert.ToInt32(src3[0,1]), 40, 40);
            g3.FillEllipse(p.Brush, Convert.ToInt32(src3[1,0]), Convert.ToInt32(src3[1,1]), 40, 40);
            g3.FillEllipse(p.Brush, Convert.ToInt32(src3[2,0]), Convert.ToInt32(src3[2,1]), 40, 40);
            g3.FillEllipse(p.Brush, Convert.ToInt32(src3[3,0]), Convert.ToInt32(src3[3,1]), 40, 40);

            g3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g3.DrawString("S1", new Font("Arial", 50), p.Brush, Convert.ToInt32(S1_3[0]), Convert.ToInt32(S1_3[1]));
            g3.DrawString("S2", new Font("Arial", 50), p.Brush, Convert.ToInt32(S2_3[0]), Convert.ToInt32(S2_3[1]));
            g3.DrawString("S3", new Font("Arial", 50), p.Brush, Convert.ToInt32(S3_3[0]), Convert.ToInt32(S3_3[1]));

            // SAVE IMAGE
            image3.Save("Homework_3_img3_result.JPG");

                        double[,] H;
            H = CalculateHomograpy(src3, dst);

            // print homography matrix
            Console.WriteLine();
            Console.WriteLine("Homography Matrix for Image 3");
            for(int i = 0; i < H.GetLength(0); i++){
                for(int j = 0; j < H.GetLength(1); j++){
                    Console.Write(H[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // calculate S1, S2, S3
            Console.WriteLine("Projection of S1, S2, S3 for Image 3");
            double[,] point1 = CalculateProjectionOfPoint(S1_3, H);
            double[,] point2 = CalculateProjectionOfPoint(S2_3, H);
            double[,] point3 = CalculateProjectionOfPoint(S3_3, H);

            Console.WriteLine("S1: " + S1_3[0] + " " + + S1_3[1]);
            Console.WriteLine("S1: " + point1[0,0] + " " + point1[1,0]);

            Console.WriteLine("S2: " + S2_3[0] + " " + + S2_3[1]);
            Console.WriteLine("S2: " + point2[0,0] + " " + point2[1,0]);

            Console.WriteLine("S3: " + S3_3[0] + " " + + S3_3[1]);
            Console.WriteLine("S3: " + point3[0,0] + " " + point3[1,0]);
            Console.WriteLine();

        }

        static double[,] CalculateHomograpy(double[,] src, double[,] dst){
            double[,] A = new double[8,8];
            double[,] B = new double[8,1];
            double[,] H = new double[8,1];

            for(int i = 0; i < 4; i++){
                A[2*i,0] = src[i,0];
                A[2*i,1] = src[i,1];
                A[2*i,2] = 1;
                A[2*i,3] = 0;
                A[2*i,4] = 0;
                A[2*i,5] = 0;
                A[2*i,6] = -src[i,0]*dst[i,0];
                A[2*i,7] = -src[i,1]*dst[i,0];
                A[2*i+1,0] = 0;
                A[2*i+1,1] = 0;
                A[2*i+1,2] = 0;
                A[2*i+1,3] = src[i,0];
                A[2*i+1,4] = src[i,1];
                A[2*i+1,5] = 1;
                A[2*i+1,6] = -src[i,0]*dst[i,1];
                A[2*i+1,7] = -src[i,1]*dst[i,1];
            }

            for(int i = 0; i < 4; i++){
                B[2*i,0] = dst[i,0];
                B[2*i+1,0] = dst[i,1];
            }

            Matrix<double> A_matrix = Matrix<double>.Build.DenseOfArray(A);
            Matrix<double> B_matrix = Matrix<double>.Build.DenseOfArray(B);

            Matrix<double> H_matrix = A_matrix.Solve(B_matrix);

            for(int i = 0; i < 8; i++){
                H[i,0] = H_matrix[i,0];
            }

            return H;
        }
       
        static double[,] CalculateProjectionOfPoint(double[] point, double[,] H){
            
            double[,] dst_point = new double[2,1];
            double srcX = point[0];
            double srcY = point[1];

            double dst1 = H[0,0] * srcX + H[1,0] * srcY + H[2,0];
            double dst2 = H[3,0] * srcX + H[4,0] * srcY + H[5,0];
            double dst3 = H[6,0] * srcX + H[7,0] * srcY + 1;

            dst_point[0,0] = dst1 / dst3;
            dst_point[1,0] = dst2 / dst3;

            return dst_point;
        }

        static double[,] ApplyInverseHomography(double[,] source_matrices, double[,] destination_matrices)
        {
            MathNet.Numerics.LinearAlgebra.Matrix<double> inverse_matrix = DenseMatrix.OfArray(source_matrices).Inverse();
            double[,] inverse_matrix_array = inverse_matrix.ToArray();
            double[,] homographyMatrix = CalculateHomograpy(inverse_matrix_array, destination_matrices);
           
           return homographyMatrix;
        }

        static double[,] CalculateInverseProjection(double[,] hm, double[,] uv)
        {
            double[,] match = ApplyInverseHomography(hm, uv);
            
            Console.WriteLine("(u,v) : " + uv[0, 0] + " , " + uv[1, 0] + " , " + uv[2, 0]);
            Console.WriteLine("(x,y) : " + match[0, 0] + " , " + match[1, 0] + " , " + match[2, 0]);

            return match;
        }

        static double[,] CalculateSourcePoints(double[,] destination, double[,] source)
        {
            int dRows = destination.GetLength(0);
            int dCols = destination.GetLength(1);

            int sRows = source.GetLength(0);
            int sCols = source.GetLength(1);

            double[,] target = new double[dRows, dCols];

            for (int i = 0; i < dRows; ++i)
            {
                for (int j = 0; j < sCols; ++j)
                {
                    for (int k = 0; k < dCols; ++k)
                    {
                        target[i,j] += destination[i, k] * source[k, j];
                    }

                }

            }

            double[,] result = new double[2, 1];

            result[0, 0] = target[0, 0] / target[2, 0];
            result[1, 0] = target[1, 0] / target[2, 0];

            Console.Write("x = " + result[0, 0].ToString("0.0000") + "   ");
            Console.Write("y = " + result[1, 0].ToString("0.0000"));
            Console.WriteLine();

            return result;
        }

    }
}

