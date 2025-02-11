using System;
class Program {
    static void Main() {
        string[] m = File.ReadAllLines(@"C:\Users\MV\OneDrive\Рабочий стол\Алгоритмизация и программирование\ргр\Отгадай число\Отгадай число\input_s1_10.txt");
        int n = Convert.ToInt16(m[0]), cnt = 0;
        int result = Convert.ToInt32(m[^1]);
        for (int x = -1000000; x < 1000000; x++) { 
            for (int i = n; i > 0 ; i--) {
                cnt += 1;
                if (m[i].EndsWith("x")) {
                    if (m[i].StartsWith("-"))
                        result += x;
                    if (m[i].StartsWith("+"))
                        result -= x;
                } else {
                    if (m[i].StartsWith("*")) {
                        string s = m[i].Substring(2);
                        int result_tmp = result;
                        result /= Convert.ToInt32(s);
                        if (result * Convert.ToInt32(s) != result_tmp)
                            break;
                    } else if (m[i].StartsWith("+")) {
                        string s = m[i].Substring(2);
                        result -= Convert.ToInt32(s);
                    } else {
                        if (m[i].StartsWith("-")) {
                            string s = m[i].Substring(2);
                            result += Convert.ToInt32(s);
                        }
                    }
                }        
            }      
            if ((cnt == n) && (result == x)) {
                Console.WriteLine(x);
                break;
            }
            result = Convert.ToInt32(m[^1]);
            cnt = 0;   
        }
    }
}       
