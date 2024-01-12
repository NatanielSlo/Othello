using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektSemestralny
{
    internal class Board
    {
        int width = 129;
        int height = 110;
        int sizex = 8;
        int sizey = 8;
        public int[,] piony;
        int[,] mozliwebicia;
        int enemy = 0;

        int currentx = 0;
        int currenty = 0;

        public int currentuser = 2;
        public string currentcolor = "BLACK";

        public Board()
        {
            mozliwebicia = new int[sizex+1,sizey+1];
            
            piony = new int[sizex+1, sizey+1];
            piony[3, 3] = 1;
            piony[3, 4] = 2;
            piony[4, 4] = 1;
            piony[4, 3] = 2;
        }
        public int CzyMoznaBic(int x, int y, int enemy)
        {
            //prawo=gora
            int count = 0;
            currentx = x;
            currenty = y;
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
        public bool Bicie(int x, int y, int enemy)
        {
            //prawo=gora
            bool bilo = false;
            currentx = x;
            currenty = y;
            while (true)
            {
                if (currentx + 1 > sizex - 1 || currenty +1 > sizey-1)
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
                        if (piony[x + i, y+i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x + i, y+i] = 3 - enemy;
                        
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
                        if (piony[x - i, y+i] == enemy)
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
                if (currentx - 1 < 0 || currenty - 1 <0)
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
                    int wynik = x-currentx;
                    for (int i = 0; i < wynik; i++)
                    {
                        if (piony[x - i, y -i] == enemy)
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
                if (currentx + 1 > sizex-1 || currenty - 1 < 0)
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
                if (currentx + 1 > sizex-1)
                {
                    break;
                }
                currentx++;
                if (piony[currentx, y] == 0)
                {
                    break;
                }                
                else if (piony[currentx, y] == 3-enemy)
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
                        if (piony[x-i, y] == enemy)
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
                        if (piony[x, y-i] == enemy)
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
                if(currenty + 1 > sizey-1)
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
                        if (piony[x, y+i] == enemy)
                        {
                            bilo = true;
                        }
                        piony[x, y + i] = 3 - enemy;
                        
                    }
                }
            }
            return bilo;

        }
        
        public int getblackscore()
        {
            int user1count = 0, user2count = 0;
            for (int x = 0; x < sizex; x++)
            {
                for(int y = 0; y < sizey; y++)
                {
                    if (piony[x,y] == 1)
                    {
                        user1count++;
                    }
                    if (piony[x, y] == 1)
                    {
                        user2count++;
                    }
                }
            }
            return user1count;
        }

        public int getwhitescore()
        {
            int user1count = 0, user2count = 0;
            for (int x = 0; x < sizex; x++)
            {
                for (int y = 0; y < sizey; y++)
                {
                    if (piony[x, y] == 1)
                    {
                        user1count++;
                    }
                    if (piony[x, y] == 2)
                    {
                        user2count++;
                    }
                }
            }
            return user2count;
        }


        public bool Move(int x, int y)
        {
            for (int i = 0; i < sizex; i++)
            {
                for (int o = 0; o < sizey; o++)
                {
                    if(x>i*width && x<i*width + width && y>o*height && y<o*height + height)
                    {
                        
                                if (piony[i, o] == 0)
                                {
                                    piony[i, o] = 1;

                                    if (Bicie(i, o, 2) == true)
                                    {
                                        currentcolor = "BLACK";
                                        return true;
                                    }
                                    else
                                    {
                                        piony[i, o] = 0;
                                        return false;
                                        

                                    }

                                    
                                }
                                return false;
                            }
                        }
                        //int[,] oldPiony = new int[sizex,sizey]; 
                        //oldPiony= (int[,]) piony.Clone();
                        //Bicie(i,o, enemy);


                        

                        
                        
                        
                        


                    



                
            }
            return false;
        }

        public void moveai(int[] ruch)
        {
            
            piony[ruch[0], ruch[1]] = 2;
            Bicie(ruch[0], ruch[1], 1);

        }


        public void Draw(Graphics g)
        {
            int currentx = 0;
            int currenty = 0;

            g.FillRectangle(Brushes.Red, 28 * width, 8 * height, width, height);

            while (currentx - width < width * sizex)
            {
                g.DrawLine(Pens.Black, currentx, currenty, currentx, currenty + height * sizey);
                currentx += width;
            }

            while (currenty - height < height * sizey)
            {
                currentx = 0;
                g.DrawLine(Pens.Black, currentx, currenty, currentx + width * sizex, currenty);
                currenty += height;
            }

            for(int x = 0; x < sizex; x++)
            {
                for(int y = 0; y < sizey; y++)
                {
                    mozliwebicia[x, y] = 0;
                    
                    if(CzyMoznaBic(x,y,2) != 0 && piony[x,y] == 0)
                    {
                        
                        g.DrawEllipse(Pens.Black, x * width, y * height, width, height);
                    }
                    if(CzyMoznaBic(x, y,1) != 0 && piony[x,y] == 0)
                    {
                        mozliwebicia[x, y] = CzyMoznaBic(x, y, 1);
                    }
                    if (piony[x,y] == 1)
                    {
                        g.FillEllipse(Brushes.Black, x*width, y*height, width, height);
                    }
                    else if (piony[x,y] == 2)
                    {
                        g.FillEllipse(Brushes.White, x*width, y*height, width, height);
                    }
                }
            }
            using (Font myFont = new Font("Arial", 14))
            {
                g.DrawString($"YOU ARE PLAYING AS COLOR: {currentcolor}", myFont, Brushes.Black, new Point(2, 2));
            }
            int player1score = getblackscore();
            int player2score = getwhitescore();
            string winning = "White";
            if(player1score > player2score)
            {
                winning = "Black";
            }
            using (Font myFont = new Font("Arial", 15))
            {
                g.DrawString($"Black score: {player1score}", myFont, Brushes.Orange, new Point(50, 50));
                g.DrawString($"White score: {player2score}", myFont, Brushes.Orange, new Point(50, 100));
                if (getblackscore() == 0 || getblackscore() == 64)
                {
                    g.DrawString($"Game ended: {winning} WINS!!", myFont, Brushes.Orange, new Point(2, 2));
                }
                


            }



        }
    }
}
