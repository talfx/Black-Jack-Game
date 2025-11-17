using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int sum1 = 0, sum = 0, sumDealer = 0, sumDealer2 = 0;
        int cash = 2000;
        int time_finish = 60;
        int pot = 0;
        static int s1 = 0,s2=0;
        static int clicks = 0;
        SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.mu);
        int head = 0;

        int[] arr = new int[260];
        public Form1()
        {
            
            this.BackgroundImage = Properties.Resources.s1;
            
            InitializeComponent();
            
            simpleSound.Play();
            button10.BackColor = System.Drawing.Color.Green;
            put();
        }
        private void onesDealer()
        {
            while (s2 > 1 && sumDealer2 > 21)
            {
                s2--;
                sumDealer2 -= 10;
                if (sumDealer < sumDealer2 && sumDealer2 < 22)
                    label5.Text = sumDealer2.ToString();
                else
                    label5.Text = sumDealer.ToString();

            }
            

        }
        private void onesYou()
        {
            
            while(s1>1 && sum1>21)
            {
                sum1 -= 10;
                s1--;
                if (sum < sum1 && sum1 < 22)
                    label4.Text = sum1.ToString();
                else
                    label4.Text = sum.ToString();

            }
            




        }
        private void put()
        {
            button2.Enabled = false;
            label3.Text = cash.ToString();
            Random rng = new Random();
        int t = 80;
            
            for(int i=0;i<=79;i++)
            {
                arr[i] = 10;
                
            }
            for (int j =1; j < 10; j++)
            {
                for (int i = t; i <= t+19; i++)
                {
                    arr[i] = j;
                    
                }

                t = t + 20;
            }



            rng = new Random();
            int n = arr.Length;
            while (n > 1)
            {
                int k = rng.Next(n);
                n--;
                int temp = arr[n];
                arr[n] = arr[k];
                arr[k] = temp;
            }
            
        }
        
      private void button2_Click(object sender, EventArgs e)
        {
           
            if (sum1 > sum && sum1 < 22)
            {
                sum = sum1;
            }

            button1.Enabled = false;

                showDealer();
            
            onesDealer();
            label5.Visible = true;
            check();
            
            if ((sumDealer > sum && sumDealer>16) || (sumDealer2 > sum&&sumDealer2>16&& sumDealer2<22) )
            {
                lost();
                return;
            }
            
            if(head!=0)
            dealer();
               

                
                    
                
            
        }
        
        private void lost()
        {
            if (sumDealer < sumDealer2 && sumDealer2 < 22)
                label5.Text = sumDealer2.ToString();
            else
                label5.Text = sumDealer.ToString();
            timer1.Stop();
            MessageBox.Show("You Have Lost", "Better luck next time!", MessageBoxButtons.OK);
            
            if (cash == 0)
            {
                button9.Visible = true;
                button9.Enabled = true;
            }
            resetAll();
            invis();

        }
        private void tie()
        {
            if (sumDealer < sumDealer2 && sumDealer2 < 22)
                label5.Text = sumDealer2.ToString();
            else
                label5.Text = sumDealer.ToString();
            timer1.Stop();
            MessageBox.Show("tied", "Splitting cash!", MessageBoxButtons.OK);
            resetAll();
            cash += pot;
            invis();

        }
        private void won()
        {

            if (sumDealer < sumDealer2 && sumDealer2 < 22)
                label5.Text = sumDealer2.ToString();
            else
                label5.Text = sumDealer.ToString();
            timer1.Stop();
            MessageBox.Show("Congrats!","You won the round!",MessageBoxButtons.OK);
            cash += pot * 2;
            resetAll();
            invis();
        }
        private void invis()
        {
            label1.Text = null;
            label2.Text = null;
            label15.Text = null;
            label5.Text = null;
            label5.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label1.Visible = false;
            label8.Visible = false;
            label9.Visible = false;



            label6.Text = "bet:0";



        }
        private void showDealer()
        {
            
            sumDealer += arr[0];
            sumDealer2 += arr[0];
            if (arr[0] == 1)
            {
                sumDealer2 += 10;
                s2++;
            }
            label8.Visible = true;
            



            label2.Text += "   "+arr[0].ToString();
            label15.Visible = false;
        }
        private void resetAll()
        {
            button1.Enabled = false;
            button1.Text = "Place Bet!";
            sum = 0; sum1 = 0; sumDealer = 0; sumDealer2 = 0;
            
             head = 0;
            clicks = 0;
            s1 = 0;s2 = 0;
            pot = 0;
            counter = 0;
            
            if(cash>=100)
            button4.Enabled = true;
            if(cash>=50)
            button3.Enabled = true;
            if (cash >= 500)
                button7.Enabled = true;
            put();
            label10.Text = "Timer: 1:00";
            counter = 0;
            timer1.Stop();
        }
        
        private void start()
        {
            
                
                
            label15.Text = ("Card upside down");
            label15.Visible = true;
            
            
              

                label1.Text = (arr[head+1].ToString());
            label1.Visible = true;
            
            sum = arr[head + 1];
            sum1 = arr[head + 1];
            if(arr[head+1]==1)
            { sum1 += 10;s1++; }
            
                label2.Text = (arr[head+2].ToString());
            label2.Visible = true;

            sumDealer = arr[head + 2];
            sumDealer2 = arr[head + 2];
            if (arr[head + 2] == 1)
            { sumDealer2 += 10; s2++; }
            
           
            sum = sum + arr[head + 3];
            sum1 += arr[head + 3];
            label1.Text += "   " + (arr[head + 3].ToString());
            if (arr[head + 3] == 1)
            { sum1 += 10; s1++; }
            head += 3;

            onesDealer();
            onesYou();
            label9.Visible = true;
            
                label4.Text = sum1.ToString();
            
            if (sumDealer < sumDealer2)
                label5.Text = sumDealer2.ToString();
            else
                label5.Text = sumDealer.ToString();
            if (sum1 == 21 || sum == 21)
            {
                
                showDealer();
                if (sumDealer == 21 || sumDealer2 == 21)
                    tie();
                else won();
            }


            
            


        }
        private bool check()
        {
            int total;

            if (sum1 > sum && sum1 < 22)
            {
                total = sum1;

            }
            else
                total = sum;

            if(sumDealer2==total&& total!=21 && sumDealer2<17)
            {
                return true;
            }
            if ((total == sumDealer && sumDealer > 16) || (total == sumDealer2 && sumDealer2 > 16))
            { tie(); return true; }
            if (sumDealer == 21 || sumDealer2 == 21 || (sumDealer > total &&  sumDealer<22 && sumDealer >16) || (sumDealer2 > total&& sumDealer2<22&& sumDealer2>16))
            {
               
                if (((sumDealer == 21 || sumDealer == 21) && (sum == 21 || sum1 == 21))||((sum==sumDealer&& (sumDealer2>22||sumDealer2==sumDealer))||(sum==sumDealer2&&sumDealer2<22))){ tie(); return true; }


                else
                    lost();
                return true;
            }
            if (sumDealer > 21 && sumDealer2 > 21|| ((sumDealer2<=sum ||sumDealer2>22)&&(sumDealer<sum&& sumDealer>16)))
            {
                
                won();
                
                return true;
            }
            
            return false;
            
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cash >= 100)
            {
                button1.Enabled = true;
                pot += 100;
                cash -= 100;
                label3.Text = cash.ToString();
                label6.Text = ("bet:" + pot.ToString());
                if(pot>=500)
                button8.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
            else
                MessageBox.Show("Error! No more chips");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            cash += 50;
            pot -= 50;
            label3.Text = cash.ToString();
            label6.Text = ("bet:" + pot.ToString());
            if (pot < 500)
                button8.Enabled = false;
            if (pot < 50)
                button5.Enabled = false;
            if (pot < 100)
                button6.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cash += 100;
            pot -= 100;
            label3.Text = cash.ToString();
            label6.Text = ("bet:" + pot.ToString());
            if (pot < 500)
                button8.Enabled = false;
            if (pot < 50)
                button5.Enabled = false;
            if (pot < 100)
                button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (cash >= 500)
            {
                button1.Enabled = true;
                pot += 500;
                cash -= 500;
                label3.Text = cash.ToString();
                label6.Text = ("bet:" + pot.ToString());
                button8.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
            else
                MessageBox.Show("Error! No more chips");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cash += 500;
            pot -= 500;
            label3.Text = cash.ToString();
            label6.Text = ("bet:" + pot.ToString());
            if (pot < 500)
                button8.Enabled = false;
            if (pot < 50)
                button5.Enabled = false;
            if (pot < 100)
                button6.Enabled = false;
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("oh... you lost all the chips...Its ok! lets restart!");
            cash = 2000;
            label3.Text = cash.ToString();
            button3.Enabled = true;
            button4.Enabled = true;
            button7.Enabled = true;
            button9.Enabled = false;
            button9.Visible = false;

        }
         int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            int time_left = time_finish - counter;
            counter++;
            label10.Text="Timer: 0:"+time_left.ToString();
            if (time_left == 0)
            {
                timer1.Stop();
                MessageBox.Show("You lost! Time is over ");
                resetAll();
                invis();
                if (cash == 0)
                {
                    button9.Visible = true;
                    button9.Enabled = true;
                }
            }
        }
        int music = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            if (music == 0)
            {
                simpleSound.Stop();
                button10.BackColor = System.Drawing.Color.Red;
                music++;
                return;
            }
            else
            {
                simpleSound.Play();
                button10.BackColor = System.Drawing.Color.Green;
                music = 0;
            }
        }

        
        private void dealer()
        {
            bool t=false;
            while ((sumDealer<=16 && sumDealer2<=16) || (sumDealer<=16 && (sumDealer2<sum|| sumDealer2>21)))
            {

                
                
                head++;
                
                sumDealer += arr[head];
                sumDealer2 += arr[head];
                label2.Text += "   " + arr[head].ToString();
                if (arr[head] == 1)
                {
                    sumDealer2 += 10;
                    s2++;
                }
                onesDealer();

                
                
                
                


                if (t==true)
                    break;
            }
             t = check();




        }
        private void you()
        {
            head++;
            sum = sum + arr[head ];
            sum1 += arr[head];
            if (arr[head] == 1)
            { sum1 += 10; s1++; }
            onesYou();

            label1.Text += "   " + (arr[head].ToString());
            
            
            label4.Visible = true;
            if (sum < sum1 && sum1 < 22)
                label4.Text = sum1.ToString();
            else
                label4.Text = sum.ToString();
            if (sum1 == 21 || sum == 21)
            {
                if (sum1 > sum && sum1 < 22)
                {
                    sum = sum1;
                }
                showDealer();
                
                dealer();
                
                return;
                    }
            if (sum > 21)
            {
                
                showDealer();
                label5.Visible = true;
                label5.Text = sumDealer.ToString();
                lost();
            }
            

        }





        private void button1_Click(object sender, EventArgs e)
        {

          
            button1.Text = "Check";
            
            
            timer1.Start();

            if (clicks == 0)
                {

                    button2.Enabled = true;
                label4.Visible = true;
                label5.Visible = true;
                button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    clicks++;
                    start();
                    
                    


                }

                else
                  you();



                

            
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {

            if (cash >= 50)
            {

                button1.Enabled = true;
                pot += 50;
                cash -= 50;
                label3.Text = cash.ToString();
                label6.Text = ("bet:"+pot.ToString());
                if(pot>=500)
                button8.Enabled = true;
                
                button5.Enabled = true;
                if(pot>=100)
                button6.Enabled = true;
            }
            else
                MessageBox.Show("Error! No more chips");
        }
    }
}
