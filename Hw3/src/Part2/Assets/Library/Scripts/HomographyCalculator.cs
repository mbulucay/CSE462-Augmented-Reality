using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra;

public class HomographyCalculator : MonoBehaviour
{
    private void Start()
    {}
    private void Update()
    {}

    public static bool DEBUG = false;

    public static void PrintMatrix(Matrix<double> matrix)
    {
        for (int i = 0; i < matrix.RowCount; i++)
        {
            string row = "";
            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                row += matrix[i, j] + " ";
            }
            Debug.Log(row);
        }
    }

    public static double[,] CalculateHomographyMatrix(double[,] s, double[,] d)
    {
        double[] H = CalculateHomography(s, d);
        double[,] HMatrix = new double[3, 3];

        int row = 0;
        for (int i = 0; i < H.Length; i++)
        {
            // HMatrix[row, i % 3] = H[i];
            // if (i % 3 == 2)
            // {
            //     row++;
            // }

            if (i % 3 == 0){
                if(i != 0){
                    ++row;
                }
            }
            HMatrix[row, i % 3] = H[i];
        }


        return HMatrix;
    }

    public static double[,] CalcProjection(double[,] hm, double[,] xy)
    {
        double[,] match = HomographyCalculator.MakeHomographyCalculation(hm, xy);
        if (DEBUG)
        {
            Debug.Log("Applying Homography...");
            Debug.Log("(x,y) : " + xy[0, 0] + " , " + xy[1, 0] + " , " + xy[2, 0]);
            Debug.Log("(u,v) : " + match[0, 0] + " , " + match[1, 0] + " , " + match[2, 0]);
        }

        return match;
    }
    
    public static double[,] CalcInverseProjection(double[,] hm, double[,] uv)
    {
        double[,] match = HomographyCalculator.ApplyInverseHomography(hm, uv);
        if (DEBUG)
        {
            Debug.Log("Applying Inverse Homography...");
            Debug.Log("(u,v) : " + uv[0, 0] + " , " + uv[1, 0] + " , " + uv[2, 0]);
            Debug.Log("(x,y) : " + match[0, 0] + " , " + match[1, 0] + " , " + match[2, 0]);
        }

        return match;
    }

    public static double[] CalculateHomography(double[,] s, double[,] d)
    {
        int N = s.GetLength(0);
        int M = 9;

        double[,] A = new double[2 * N, M];

        // current point
        int p = 0;
        for (int i = 0; i < 2 * N; i++)
        {
            if (i % 2 != 0)
            {
                A[i, 0] = 0;
                A[i, 1] = 0;
                A[i, 2] = 0;
                A[i, 3] = -1 * s[p, 0];
                A[i, 4] = -1 * s[p, 1];
                A[i, 5] = -1;
                A[i, 6] = s[p, 0] * d[p, 1];
                A[i, 7] = d[p, 1] * s[p, 1];
                A[i, 8] = d[p, 1];
                ++p;
            }
            else
            {
                A[i, 0] = -1 * s[p, 0];
                A[i, 1] = -1 * s[p, 1];
                A[i, 2] = -1;
                A[i, 3] = 0;
                A[i, 4] = 0;
                A[i, 5] = 0;
                A[i, 6] = s[p, 0] * d[p, 0];
                A[i, 7] = d[p, 0] * s[p, 1];
                A[i, 8] = d[p, 0];
            }
        }

        DenseMatrix matrix = DenseMatrix.OfArray(A);
        Svd<double> SVD = matrix.Svd(true);

        double[] H = new double[M];
        for (int i = 0; i < M; i++)
        {
            H[i] = SVD.VT[8, i];
        }

        return H;
        
        // return SVD.VT.Row(SVD.VT.RowCount - 1).ToArray();
    }

    public static double[,] ApplyInverseHomography(double[,] source_matrices, double[,] destination_matrices)
    {
        MathNet.Numerics.LinearAlgebra.Matrix<double> inverse_matrix = DenseMatrix.OfArray(source_matrices).Inverse();

        double[,] b = new double[3, 1];
        b[0, 0] = destination_matrices[0, 0];
        b[1, 0] = destination_matrices[1, 0];
        b[2, 0] = 1;

        double[,] inverse_matrix_array = inverse_matrix.ToArray();

        double[,] homographyMatrix = MakeHomographyCalculation(inverse_matrix_array, destination_matrices);

        return homographyMatrix;

        // return MakeHomographyCalculation(inverse_matrix.ToArray(), a);
    }

    public static double[,] MakeHomographyCalculation(double[,] source_matrix, double[,] destination_matrices)
    {
        double[,] temp_matrix = MultiplyMatrices(source_matrix, destination_matrices);
        
        double[,] result = new double[,] { 
            { temp_matrix[0, 0] / temp_matrix[2, 0] }, 
            { temp_matrix[1, 0] / temp_matrix[2, 0] }, 
            { 1 } 
        };

        return result;
    }

    public static double [,] MultiplyMatrices(double[,] m1, double[,] m2){

        int m1Rows = m1.GetLength(0);
        int m1Cols = m1.GetLength(1);

        int m2Rows = m2.GetLength(0);
        int m2Cols = m2.GetLength(1);

        if (m1Cols != m2Rows)
        {
            throw new System.Exception("Matrices cannot be multiplied");
        }

        double[,] result = new double[m1Rows, m2Cols];

        for (int i = 0; i < m1Rows; i++)
        {
            for (int j = 0; j < m2Cols; j++)
            {
                for (int k = 0; k < m1Cols; k++)
                {
                    result[i, j] += m1[i, k] * m2[k, j];
                }
            }
        }

        return result;

    }

    public static double [,] MultiplyMatrices(double[,] m1, double[,] m2, double[,] m3)
    {
        return MultiplyMatrices(MultiplyMatrices(m1, m2), m3);
    }

    public static double[,] SumMatrices(double[,] m1, double[,] m2){

        int m1Rows = m1.GetLength(0);
        int m1Cols = m1.GetLength(1);

        int m2Rows = m2.GetLength(0);
        int m2Cols = m2.GetLength(1);

        if (m1Cols != m2Cols || m1Rows != m2Rows)
        {
            throw new System.Exception("Matrices cannot be summed");
        }

        double[,] result = new double[m1Rows, m1Cols];

        for (int i = 0; i < m1Rows; i++)
        {
            for (int j = 0; j < m1Cols; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }

        return result;
    }

}
