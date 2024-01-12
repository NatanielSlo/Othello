using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny
{
    internal class Sztokryba
    {
        int sizex = 8; int sizey = 8;
        int[,] result;
        int[] move;

        public Sztokryba()
        {
            this.result = new int[sizex + 1, sizey + 1];
            this.move = new int[2];
            this.move[0] = 0;
            this.move[1] = 0;
        }

        public int CalculateAmountBeat(int x, int y, int[,] piony, bool forenemy = false)
        {

            //prawo=gora
            int enemy = 1;
            if(forenemy == true) { enemy = 2; }
            int count = 0;
            int currentx = x;
            int currenty = y;
            while (true)
            {
                if (currentx + 1 > sizex - 1 || currenty + 1 > sizey - 1)
                {
                    break;
                }
                currentx++;
                currenty++;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = currentx - x;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x + i, y + i] == enemy)
                        {
                            count++;
                        }

                    }
                }
            }

            //lewo-gora
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx - 1 < 0 || currenty + 1 > sizey - 1)
                {
                    break;
                }
                currentx--;
                currenty++;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = currenty - y;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x - i, y + i] == enemy)
                        {
                            count++;
                        }

                    }
                }
            }

            //lewo-dol
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx - 1 < 0 || currenty - 1 < 0)
                {
                    break;
                }
                currentx--;
                currenty--;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = x - currentx;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x - i, y - i] == enemy)
                        {
                            count++;
                        }

                    }
                }
            }

            //prawo-dol
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx + 1 > sizex - 1 || currenty - 1 < 0)
                {
                    break;
                }
                currentx++;
                currenty--;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = y - currenty;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x + i, y - i] == enemy)
                        {
                            count++;
                        }

                    }
                }
            }


            //prawo
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx + 1 > sizex - 1)
                {
                    break;
                }
                currentx++;
                if (piony[currentx, y] == 0)
                {
                    break;
                }
                else if (piony[currentx, y] == 3 - enemy)
                {
                    int wynik = currentx - x;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x + i, y] == enemy)
                        {
                            count++;
                        }
                    }
                }
            }

            //lewo
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx - 1 < 0)
                {
                    break;
                }
                currentx--;
                if (piony[currentx, y] == 0)
                {
                    break;
                }
                else if (piony[currentx, y] == 3 - enemy)
                {
                    int wynik = x - currentx;

                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x - i, y] == enemy)
                        {
                            count++;
                        }
                    }
                }
            }

            //dól
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currenty - 1 < 0)
                {
                    break;
                }
                currenty--;
                if (piony[x, currenty] == 0)
                {
                    break;
                }
                else if (piony[x, currenty] == 3 - enemy)
                {
                    int wynik = y - currenty;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x, y - i] == enemy)
                        {
                            count++;
                        }

                    }
                }

            }


            //góra
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currenty + 1 > sizey - 1)
                {
                    break;
                }
                currenty++;
                if (piony[x, currenty] == 0)
                {
                    break;
                }
                else if (piony[x, currenty] == 3 - enemy)
                {
                    int wynik = currenty - y;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x, y + i] == enemy)
                        {
                            count++;
                        }

                    }
                }
            }
            return count;
        }

        public int[,] Bicie(int x, int y, bool forenemy, int[,] piony)
        {
            //prawo=gora
            int enemy = 1;
            if (forenemy == true) { enemy = 2; }
            bool bilo = false;
            int currentx = x;
            int currenty = y;
            while (true)
            {
                if (currentx + 1 > sizex - 1 || currenty + 1 > sizey - 1)
                {
                    break;
                }
                currentx++;
                currenty++;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = currentx - x;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x + i, y + i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x + i, y + i] = 3 - enemy;

                    }
                }
            }

            //lewo-gora
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx - 1 < 0 || currenty + 1 > sizey - 1)
                {
                    break;
                }
                currentx--;
                currenty++;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = currenty - y;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x - i, y + i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x - i, y + i] = 3 - enemy;

                    }
                }
            }

            //lewo-dol
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx - 1 < 0 || currenty - 1 < 0)
                {
                    break;
                }
                currentx--;
                currenty--;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = x - currentx;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x - i, y - i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x - i, y - i] = 3 - enemy;

                    }
                }
            }

            //prawo-dol
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx + 1 > sizex - 1 || currenty - 1 < 0)
                {
                    break;
                }
                currentx++;
                currenty--;
                if (piony[currentx, currenty] == 0)
                {
                    break;
                }
                else if (piony[currentx, currenty] == 3 - enemy)
                {
                    int wynik = y - currenty;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x + i, y - i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x + i, y - i] = 3 - enemy;

                    }
                }
            }


            //prawo
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx + 1 > sizex - 1)
                {
                    break;
                }
                currentx++;
                if (piony[currentx, y] == 0)
                {
                    break;
                }
                else if (piony[currentx, y] == 3 - enemy)
                {
                    int wynik = currentx - x;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x + i, y] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x + i, y] = 3 - enemy;
                    }
                }
            }

            //lewo
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx - 1 < 0)
                {
                    break;
                }
                currentx--;
                if (piony[currentx, y] == 0)
                {
                    break;
                }
                else if (piony[currentx, y] == 3 - enemy)
                {
                    int wynik = x - currentx;

                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x - i, y] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x - i, y] = 3 - enemy;
                    }
                }
            }

            //dól
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currenty - 1 < 0)
                {
                    break;
                }
                currenty--;
                if (piony[x, currenty] == 0)
                {
                    break;
                }
                else if (piony[x, currenty] == 3 - enemy)
                {
                    int wynik = y - currenty;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x, y - i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x, y - i] = 3 - enemy;

                    }
                }

            }


            //góra
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currenty + 1 > sizey - 1)
                {
                    break;
                }
                currenty++;
                if (piony[x, currenty] == 0)
                {
                    break;
                }
                else if (piony[x, currenty] == 3 - enemy)
                {
                    int wynik = currenty - y;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x, y + i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x, y + i] = 3 - enemy;

                    }
                }
            }
            return piony;

        }
        public int CalculatePositionValue(int x, int y)
        {
            if (x == 0 && y == 0 || x == 7 && y == 7 || x == 0 && y == 7 || x == 7 && y == 0) { return 100; }
            else if (x == 0 && y == 6 || x == 0 && y == 1 || x == 1 && y == 0 || x == 1 && y == 7 || x == 7 && y == 6 || x == 7 && y == 1 || x == 6 && y == 0 || x == 6 && y == 7) { return -30; }
            else if (x == 1 && y == 6 || x == 1 && y == 1 || x == 6 && y == 6 || x == 6 && y == 1) { return -50; }
            else if (x == 0 && y == 2 || x == 0 && y == 5 || x == 7 && y == 2 || x == 7 && y == 5 || x == 2 && y == 0 || x == 2 && y == 7 || x == 5 && y == 0 || x == 5 && y == 7) { return 6; }
            else if (x == 0 && y == 3 || x == 0 && y == 4 || x == 7 && y == 3 || x == 7 && y == 4 || y == 0 && x == 3 || y == 0 && x == 4 || y == 7 && x == 3 || y == 7 && x == 4) { return 2; }
            else if (x == 3 && y == 3 || x == 4 && y == 3 || x == 3 && y == 4 || x == 4 && y == 4) { return 3; }
            else return 0;
        }

        public int[,] EvaluatePossibilites(int[,] piony, bool forenemy = false)
        {
            int score = 0;
           
            for(int x = 0; x <sizex; x++)
            {
                for( int y = 0; y <sizey; y++)
                {
                    score = -1000;

                    if (piony[x,y] == 0)
                    {
                        if (CalculateAmountBeat(x, y, piony, forenemy) > 0)
                        {
                            score = CalculateAmountBeat(x, y, piony, forenemy) + CalculatePositionValue(x, y);
                            //change the amount bet so that the bot prioritizes beating better pieces
                            
                        }
                    }
          
                    
                    result[x,y] = score;
                }
            }
            return result;
        }
        private int MinMax(int[,] piony, int depth, int x, int y)
        {
            return 0;
            
        }

        public int[] CalculateBasicMove(int[,] piony, bool forenemy = false) {

            int[,] mozliwebicia = EvaluatePossibilites(piony, forenemy);
            int largest = -99;
            int largest_i = 8;
            int largest_p = 8;

            for (int i = 0; i < sizex + 1; i++)
            {
                for (int p = 0; p < sizey + 1; p++)
                {
                    if (mozliwebicia[i,p] > largest)
                    {
                        largest_i = i;
                        largest_p = p;
                        largest= mozliwebicia[i,p];
                    }
                }
            }
            move[0] = largest_i;
            move[1] = largest_p;
            return move;



        }
    }
}
