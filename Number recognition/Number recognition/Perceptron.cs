using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_recognition
{
    class Perceptron
    {
        const int INPUT = 4; // bias포함 -- 클러스터 개수 
        const int OUTPUT = 10; // bias포함  -- 0부터 9까지 개수를 의미한다.  -- [숫자 클래스 개수만큼 ].

        //Fuzzy Max-Min neural-natework
        // 퍼지 최대-최소 신경망. 
        public double Fuzzy_MMNN(double[] x) // 클러스터 4개를 넣어서 [최종적으로 하나의 분류를 하는 부분.]
        {
            // [ 소속도를 받아서 ] 비교분류
            int i;
            // 돌아가는 기준이 합집합이다. 
            // 각 숫자에 대한 [가중치를 정해둔다]. 
            // 제일 높은 값이랑 맞으면 제일 높은값 
            double[][] w = new double[][] {
                new double[] {0.29, 0.94, 1, 0}, // 0
                new double[] {0, 0.3, 1, 0.5}, // 1
                new double[] {0.49, 0.92, 0.77, 1}, // 2
                new double[] {0.53, 0.82, 0, 1}, // 3
                new double[] {0.9, 1, 0, 0.09}, // 4
                new double[] {0.75, 0, 1, 0.8}, // 5
                new double[] {1, 0, 0.75, 0.80}, // 6
                new double[] {0.89, 1, 0, 0.28}, // 7
                new double[] {0.52, 1, 0, 0.42}, // 8
                new double[] {0.62, 0.75, 0, 1 } // 9
            };

            double[] tmp = new double[INPUT];
            double[] result = new double[OUTPUT]; // 10개를 구해야하닌깐.  -- 각숫자에대한 확률값이들어간다. 
            double max = 0.0;
            int number = -1;
                   
            for (i = 0; i < OUTPUT; i++) // 9까지 
            {
                result[i] = Max_Min(x, w[i]); // min,max 먼저하고 
                max = Math.Max(result[i], max);  // 제일 높은 숫자를 여기넣어서 그 숫자를 넘버로 넣어서 
                if (max == result[i]) // 가장 큰 숫자 인식한 것을  
                    number = i; //number 변수에 저장시킨후 리턴. 
            }

            Console.WriteLine("---------출력층-------------");
            for (i = 0; i < OUTPUT; i++)
                Console.WriteLine("[" + i + "] 이 인식한 결과 : " + result[i]);

            Console.WriteLine("----------결과--------------");
            //Console.WriteLine(number); 
            return number; // 해당 숫자 인식된 결과를 출력하는 부분 이다. 
        }

        //분류하기 위해 해준다. (교집합) 가중치랑 해주고
        public double Max_Min(double[] x, double[] w)
        {
            // 가중치랑 비교 min 한것과 더해서 리턴
            int i;
            double[] temp = new double[INPUT];
            double result = 0.0;
            double bias = 0.1; // 최소값을 정한다. 

            for (i = 0; i < INPUT; i++)
                temp[i] = Math.Min(x[i], w[i]); //클러스터 소속도랑 가중치랑 비교해서 작은값 골라냄.

            for (i = 0; i < INPUT; i++)
                temp[i] = Math.Max(temp[i], bias);

            for (i = 0; i < INPUT; i++)
                result += temp[i];

            return result;
        }

        // 0과 ~ 1사이의 값으로 변환하는 표준화 기법 사용. 
        // Min-Max Normalization(최소- 최대 정규화) 
        public double Min_Max_Normalization(double x, double max, double min)  // 엑티베이션 펑션 . --> 스트레칭 적용 
        {
            return (x - min) / (max - min);
        }
    }
}
