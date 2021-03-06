﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {

            GridProduct();

        }

        //Problem 1
        static void SumOfMultiples(int max)
        {

            int sum = 0;

            for (int i = 1; i < max; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }

            Console.WriteLine(sum + "");
        }

        //Problem 2
        static void Fibonacci()
        {

            int first = 1, previous = 1, fib = 0, sum = 0;

            while (fib < 4000000)
            {

                if (fib == 0) fib = 1;

                fib = first + previous;

                first = previous;
                previous = fib;

                if (fib % 2 == 0) sum += fib;
            }


            Console.WriteLine(sum + "");
        }

        //Problem 3
        static void PrimeFactor(long num)
        {

            long n = num / 2, i = 0, result = 0, r = 0;

            for (i = 2; i <= n; i++)
            {
                if (num % i == 0)
                {

                    if (result == 0)
                    {
                        result = i;
                    }
                    else
                    {
                        result *= i;
                    }

                    if (result == num) r = i;
                }
            }

            Console.WriteLine(r + "");
        }



        //Problem 8
        static void AdjacentDigit()
        {
            //String to Char Array
            char[] str = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450".ToCharArray();

            long num = 0, highest = 0, result = 0, currNum = 0;

            List<long> resultList = new List<long>();

            for (int i = 0; i < str.Length - 12; i++)
            {

                num = long.Parse(str[i].ToString());

                for (int j = i; j < i + 13; j++)
                {

                    currNum = long.Parse(str[j].ToString());

                    if (j == i)
                    {
                        result = currNum;
                    }
                    else result *= currNum;

                }

                if (result > highest) highest = result;
            }


            Console.WriteLine(highest + "");
        }


        //Problem 11
        static void GridProduct()
        {

            string[] contents = File.ReadAllText(@"C:\gridproduct.txt").Split();

            long[][] grid = new long[20][];

            long[] temp = new long[20];

            int x = 0, y = 0;


            for (int i = 0; i < contents.Length; i++) {

                if (contents[i] == "" || String.IsNullOrEmpty(contents[i]))
                {

                    grid[y] = new long[] { temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], temp[9], temp[10], temp[11], temp[12], temp[13], temp[14], temp[15], temp[16], temp[17], temp[18], temp[19] };
                    
                    x = 0;
                    y++;

                } else
                {

                    temp[x] = long.Parse(contents[i].ToString());

                    x++;
                }
            }

            grid[y] = new long[] { temp[0], temp[1], temp[2], temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], temp[9], temp[10], temp[11], temp[12], temp[13], temp[14], temp[15], temp[16], temp[17], temp[18], temp[19] };
            

            long highest = 0, result = 0, count = 0;
            x = 0; y = 0;

            for (int i = 0; i < contents.Length; i++) {

                if (count == 20) {
                    x = 0;
                    y++;
                    count = 0;
                }

                if (y == 20) break;

                //Up
                if (y > 2) {

                    result = grid[y][x] * grid[y - 1][x] * grid[y - 2][x] * grid[y - 3][x];

                    if (result > highest) highest = result;
                    result = 0;
                }

                //Down
                if (y < 17) {

                    result = grid[y][x] * grid[y + 1][x] * grid[y + 2][x] * grid[y + 3][x];

                    if (result > highest) highest = result;
                    result = 0;
                }

                //Left
                if (x > 2) {

                    result = grid[y][x] * grid[y][x - 1] * grid[y][x - 2] * grid[y][x - 3];

                    if (result > highest) highest = result;
                    result = 0;
                }

                //Right
                if (x < 17) {

                    result = grid[y][x] * grid[y][x + 1] * grid[y][x + 2] * grid[y][x + 3];

                    if (result > highest) highest = result;
                    result = 0;
                }

                //Diagonally

                //UpLeft
                if (x > 2 && y > 2) {

                    result = grid[y][x] * grid[y - 1][x - 1] * grid[y - 2][x - 2] * grid[y - 3][x - 3];

                    if (result > highest) highest = result;
                    result = 0;
                }

                //UpRight
                if (x < 17 && y > 2) {

                    result = grid[y][x] * grid[y - 1][x + 1] * grid[y - 2][x + 2] * grid[y - 3][x + 3];

                    if (result > highest) highest = result;
                    result = 0;
                }

                //DownLeft
                if (x > 2 && y < 17) {

                    result = grid[y][x] * grid[y + 1][x - 1] * grid[y + 2][x - 2] * grid[y + 3][x - 3];

                    if (result > highest) highest = result;
                    result = 0;
                }

                //DownRight
                if (x < 17 && y < 17) {

                    result = grid[y][x] * grid[y + 1][x + 1] * grid[y + 2][x + 2] * grid[y + 3][x + 3];

                    if (result > highest) highest = result;
                    result = 0;
                }

                x++;
                count++;
            }

            Console.WriteLine(highest + "");

        }

        //Problem 12
        static void TriangleNumbers()
        {

            long triangle = 1, count = 0, j = 1;

            while (count < 501)
            {

                count = 0;

                for (int i = 1; i <= triangle; i++)
                {
                    if (triangle % i == 0)
                    {
                        count++;
                    }
                }

                if (count > 500) break;

                j++;
                triangle += j;
            }

            Console.WriteLine(triangle + "");
        }

        //Problem 13
        static void LargeSum()
        {

            string str = "37107287533902102798797998220837590246510135740250463769376774900097126481248969700780504170182605387432498619952474105947423330951305812372661730962991942213363574161572522430563301811072406154908250230675882075393461711719803104210475137780632466768926167069662363382013637841838368417873436172675728112879812849979408065481931592621691275889832738442742289174325203219235894228767964876702721893184745144573600130643909116721685684458871160315327670386486105843025439939619828917593665686757934951621764571418565606295021572231965867550793241933316490635246274190492910143244581382266334794475817892575867718337217661963751590579239728245598838407582035653253593990084026335689488301894586282278288018119938482628201427819413994056758715117009439035398664372827112653829987240784473053190104293586865155060062958648615320752733719591914205172558297169388870771546649911559348760353292171497005693854370070576826684624621495650076471787294438377604532826541087568284431911906346940378552177792951453612327252500029607107508256381565671088525835072145876576172410976447339110607218265236877223636045174237069058518606604482076212098132878607339694128114266041808683061932846081119106155694051268969251934325451728388641918047049293215058642563049483624672216484350762017279180399446930047329563406911573244438690812579451408905770622942919710792820955037687525678773091862540744969844508330393682126183363848253301546861961243487676812975343759465158038628759287849020152168555482871720121925776695478182833757993103614740356856449095527097864797581167263201004368978425535399209318374414978068609844840309812907779179908821879532736447567559084803087086987551392711854517078544161852424320693150332599594068957565367821070749269665376763262354472106979395067965269474259770973916669376304263398708541052684708299085211399427365734116182760315001271653786073615010808570091499395125570281987460043753582903531743471732693212357815498262974255273730794953759765105305946966067683156574377167401875275889028025717332296191766687138199318110487701902712526768027607800301367868099252546340106163286652636270218540497705585629946580636237993140746255962240744869082311749777923654662572469233228109171419143028819710328859780666976089293863828502533340334413065578016127815921815005561868836468420090470230530811728164304876237919698424872550366387845831148769693215490281042402013833512446218144177347063783299490636259666498587618221225225512486764533677201869716985443124195724099139590089523100588229554825530026352078153229679624948164195386821877476085327132285723110424803456124867697064507995236377742425354112916842768655389262050249103265729672370191327572567528565324825826546309220705859652229798860272258331913126375147341994889534765745501184957014548792889848568277260777137214037988797153829820378303147352772158034814451349137322665138134829543829199918180278916522431027392251122869539409579530664052326325380441000596549391598795936352974615218550237130764225512118369380358038858490341698116222072977186158236678424689157993532961922624679571944012690438771072750481023908955235974572318970677254791506150550495392297953090112996751986188088225875314529584099251203829009407770775672113067397083047244838165338735023408456470580773088295917476714036319800818712901187549131054712658197623331044818386269515456334926366572897563400500428462801835170705278318394258821455212272512503275512160354698120058176216521282765275169129689778932238195734329339946437501907836945765883352399886755061649651847751807381688378610915273579297013376217784275219262340194239963916804498399317331273132924185707147349566916674687634660915035914677504995186714302352196288948901024233251169136196266227326746080059154747183079839286853520694694454072476841822524674417161514036427982273348055556214818971426179103425986472045168939894221798260880768528778364618279934631376775430780936333301898264209010848802521674670883215120185883543223812876952786713296124747824645386369930090493103636197638780396218407357239979422340623539380833965132740801111666627891981488087797941876876144230030984490851411606618262936828367647447792391803351109890697907148578694408955299065364044742557608365997664579509666024396409905389607120198219976047599490197230297649139826800329731560371200413779037855660850892521673093931987275027546890690370753941304265231501194809377245048795150954100921645863754710598436791786391670211874924319957006419179697775990283006991536871371193661495281130587638027841075444973307840789923115535562561142322423255033685442488917353448899115014406480203690680639606723221932041495354150312888033953605329934036800697771065056663195481234880673210146739058568557934581403627822703280826165707739483275922328459417065250945123252306082291880205877731971983945018088807242966198081119777158542502016545090413245809786882778948721859617721078384350691861554356628840622574736922845095162084960398013400172393067166682355524525280460972253503534226472524250874054075591789781264330331690";

            BigInteger result = new BigInteger();

            for (int i = 0; i < str.Length; i += 50)
            {
                result += BigInteger.Parse(str.Substring(i, Math.Min(str.Length, 50)));
            }

            Console.WriteLine(Convert.ToString(result).Substring(0, 10));
        }

        //Problem 14
        static void CollatzSeq()
        {

            long count = 0, currNum = 0, highest = 0, result = 0;

            for (int i = 2; i < 1000000; i++)
            {

                count = 0;

                currNum = i;

                while (currNum > 1)
                {

                    if (currNum % 2 == 0)
                    {
                        currNum /= 2;
                    }
                    else
                    {
                        currNum = 3 * currNum + 1;
                    }

                    count++;
                }

                if (count > highest)
                {
                    highest = count;
                    result = i;
                }
            }

            Console.WriteLine(result + "");
        }
    }
}
