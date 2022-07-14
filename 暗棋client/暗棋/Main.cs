using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using log4net;
using System.Resources;
using System.Collections;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace 暗棋
{
    public partial class Main : Form
    {
        public readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Socket SK;
        public Thread Td;
        public IPEndPoint EP;
        String strCase;
        byte[] data = new byte[1024];
        //bool IsConnect = false;
        string NickName = "";
        List<Image> pickImgList = new List<Image>();

        public Main()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Main_Closed);
            ResourceManager rm = new ResourceManager(typeof(暗棋.Properties.Resources)); 

            //put pictureBox into array
            //winPattern[0, 0] = rm.GetObject("_0") as Image ;
            int px=260;
            int py=170;
            int ix=79;
            int iy=73;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board[i, 0] = px + ix * (i%8)+10;
                    board[i, 1] = py + iy * (i/8)+7;
                    board[i, 2] = px + ix * (i%8 +1);
                    board[i, 3] = py + iy * (i/8+1) ;
                }
             }
            px = 12;
            py = 136;
            ix = 66;
            iy = 66;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    originRed[i, 0] = px + ix * (i % 3);
                    originRed[i, 1] = py + iy * (i/3);
                    originRed[i, 2] = px + ix * (i % 3 + 1);
                    originRed[i, 3] = py + iy * (i/3 + 1);
                }
            }
            px = 948;
            py = 136;
            ix = 66;
            iy = 66;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    originBlack[i, 0] = px + ix * (i % 3);
                    originBlack[i, 1] = py + iy * (i / 3);// ((int)Math.Floor(i / 3.0));
                    originBlack[i, 2] = px + ix * (i % 3 + 1);
                    originBlack[i, 3] = py + iy * (i/3 + 1);
                }
            }
             for (int i = 0; i < 32; i++)
            {
                BasicPic p = new BasicPic((Image)rm.GetObject("_" + i.ToString()), (Image)rm.GetObject("_000"));
                p.ID = i;
                p.setToFront();
               if(i < 16)
                    p.setPos(originRed[i, 0], originRed[i, 1]);
               else
                   p.setPos(originBlack[i-16, 0], originBlack[i-16, 1]);

                p.MouseDown += pic_MouseDown;
                allChess[i] = p;
                p.BackColor = System.Drawing.Color.Transparent;
                this.Controls.Add(p);
                switch (i)
                {
                    case 0:
                        p.priority = 7;
                        break;
                    case 1:
                    case 2:
                        p.priority = 6;
                        break;
                    case 3:
                    case 4:
                        p.priority = 5;
                        break;
                    case 5:
                    case 6:
                        p.priority = 4;
                        break;
                    case 7:
                    case 8:
                        p.priority = 3;
                        break;
                    case 9:
                    case 10:
                        p.priority = 2;
                        break;
                    default :
                        p.priority = 1;
                        break;
                }
            }
            //for (int i = 0; i < 16; i++)
            //{
            //    BasicPic p = new BasicPic(imageList1.Images[i], imageList2.Images[16]);
            //    p.ID = i;
            //    p.setToFront();
            //    p.setPos(originRed[i, 0], originRed[i, 1]);
            //    p.MouseDown += pic_MouseDown;
            //    allChess[i] = p;
            //    p.BackColor = System.Drawing.Color.Transparent;
            //    this.Controls.Add(p);
            //    switch (i)
            //    {
            //        case 0:
            //            p.priority = 7;
            //            break;
            //        case 1:
            //        case 2:
            //            p.priority = 6;
            //            break;
            //        case 3:
            //        case 4:
            //            p.priority = 5;
            //            break;
            //        case 5:
            //        case 6:
            //            p.priority = 4;
            //            break;
            //        case 7:
            //        case 8:
            //            p.priority = 3;
            //            break;
            //        case 9:
            //        case 10:
            //            p.priority = 2;
            //            break;
            //        default :
            //            p.priority = 1;
            //            break;
            //    }
            //}
            //for (int i = 0; i < 16; i++)
            //{
            //    BasicPic p = new BasicPic(imageList2.Images[i], imageList2.Images[16]);
            //    p.ID = i+16;
            //    p.setToFront();
            //    p.setPos(originBlack[i, 0], originBlack[i, 1]);
            //    p.MouseDown += pic_MouseDown;
            //    allChess[i+16] = p;
            //    p.BackColor = System.Drawing.Color.Transparent;
            //    this.Controls.Add(p);
            //    switch (i)
            //    {
            //        case 0:
            //            p.priority = 7;
            //            break;
            //        case 1:
            //        case 2:
            //            p.priority = 6;
            //            break;
            //        case 3:
            //        case 4:
            //            p.priority = 5;
            //            break;
            //        case 5:
            //        case 6:
            //            p.priority = 4;
            //            break;
            //        case 7:
            //        case 8:
            //            p.priority = 3;
            //            break;
            //        case 9:
            //        case 10:
            //            p.priority = 2;
            //            break;
            //        default:
            //            p.priority = 1;
            //            break;
            //    }
            //}



        }
        private void Main_Closed(object sender, System.EventArgs e)
        {
            Form1.isClose = true;
        }
        ////NetworkStream stream;
        private void Main_Shown(object sender, EventArgs e)
        {
            //SK.ReceiveAsync
            //Td = new Thread(socketReceive);
            //Td.IsBackground = true;
            //Td.Start();
            try
            {

                //stream = new NetworkStream(SK);
                //stream.BeginRead(data, 0, 1024, new AsyncCallback(this.socketReceive), stream);
                LingerOption sckoptLinger = new LingerOption(true,3);
                SK.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, sckoptLinger);
                SK.BeginReceive(data, 0, 1024, SocketFlags.None, new AsyncCallback(this.socketReceive), SK);
                log.Info("Socket ready to receive message!");
                //IsConnect = true;
                NickName = Form1.NickName;
                addMessage("歡迎 " + NickName + " 先生/小姐 您的加入");
                addMessage("請稍後..................................");

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        public void socketSend(string sendData)
        {
            //if (IsConnect)
            {
                try
                {
                    SK.Send(Encoding.UTF8.GetBytes(sendData));
                    //addMessage("Send out :[" + sendData + "]");
                    log.Info("Send out :[" + sendData + "]");
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    //每隔3秒try connecting to Server
                    int tryCount = 1;
                    while (tryCount < 4)
                    {
                        try
                        {
                            addMessage("等3秒...第" + tryCount.ToString() + "次重送Server！");
                            Thread.Sleep(3000);
                            if (SK == null)
                            {
                                SK.Connect(EP);
                                //stream = new NetworkStream(SK);
                                //stream.BeginRead(data, 0, 1024, new AsyncCallback(this.socketReceive), stream);
                                LingerOption sckoptLinger = new LingerOption(true, 3);
                                SK.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, sckoptLinger);
                                SK.BeginReceive(data, 0, 1024, SocketFlags.None, new AsyncCallback(this.socketReceive), SK);
                                log.Info("Socket ready to receive message again !");
                            }
                            //if (stream == null)
                            //{
                            //    stream = new NetworkStream(SK);
                            //    stream.BeginRead(data, 0, 1024, new AsyncCallback(this.socketReceive), stream);
                            //    log.Info("Socket ready to receive message again !");
                            //}
                            SK.Send(Encoding.UTF8.GetBytes(sendData)); return;

                        }
                        catch
                        {
                            addMessage("第" + tryCount.ToString() + "次重送Server, 失敗！");
                            tryCount++;
                        }
                    }
                    SK.Shutdown(SocketShutdown.Both);
                    SK.Close();
                    //Close();

                }
            }
            //else
            //    log.Error("請等待對方連線");
        }


        public void socketReceive(IAsyncResult ar)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            int recvLength = 0;

            //stream = ((NetworkStream)(ar.AsyncState));
            try
            {
            //    if (((stream == null) || !stream.CanRead))
            //    {
            //        return;
            //    }

                recvLength  = SK.EndReceive(ar);

                if (recvLength > 0)
                {
                    string msg = Encoding.UTF8.GetString(data, 0, recvLength).Trim();
                    log.Info("Receive message:[" + msg + "]");
                    Receive(msg);
                    Array.Clear(data, 0, data.Length);
                    //stream.BeginRead(data, 0, 1024, new AsyncCallback(this.socketReceive), stream);
                    SK.BeginReceive(data, 0, 1024, SocketFlags.None, new AsyncCallback(this.socketReceive), SK);
                }
                else
                {
                    log.Info("Server 關閉連線!!");
                    //if (stream != null)
                    //{
                    //    stream.Close();
                    //    SK.Shutdown(SocketShutdown.Both);
                    //    SK.Close();
                    //}
                    if (SK != null)
                    {
                        SK.Shutdown(SocketShutdown.Both);
                        SK.Close();

                    }
                    //stream = null;
                    SK = null;
                    Close();
                    //IsConnect = false;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                if (SK != null && SK.Connected )
                {
                    SK.Shutdown(SocketShutdown.Both);
                    SK.Close();

                }
                //stream = null;
                SK = null;
                Close();
           }
        }
        public void Receive(string recvData) //接收資料判斷輸贏
        {
            Panel.CheckForIllegalCrossThreadCalls = false;
            try
            {
                strCase = recvData.Substring(0, 1);
                char token = ',';
                string[] pt = recvData.Split(token);
                //string str = "";
                //for (int i = 1; i < pt.Length; i++)
                //{
                //    str += pt[i];
                //}
                switch (strCase)
                {
                    case "G":
                        //IsConnect = true;
                        addMessage("連線完成...，準備洗牌並選擇那一方先下第一步!");

                        //有時GS會一起接收
                        if (recvData.Length > 1)
                            Receive(recvData.Substring(1, 1));
                        break;
                    //case "T":
                    //    addMessage(str);
                    //    break;
                    case "S":
                        shuffChess();
                        putAllChessToBoard(pt[1]);
                        gameStart = true;
                        myTurn = true;
                        addMessage("遊戲開始！");
                        addMessage("請您先下！");
                        break;
                    case "W":
                        shuffChess();
                        putAllChessToBoard(pt[1]);
                        gameStart = true;
                        addMessage("遊戲開始！");
                        addMessage("對方下第一步中...！");
                        break;
                    //case "C":
                    //    if (myTurn)
                    //    {
                    //        addMessage("遊戲開始！");
                    //        if (myColor == "紅棋")
                    //        {
                    //            lblB.Text = pt[1];
                    //            lblB.Visible = true;
                    //        }
                    //        else
                    //        {
                    //            lblR.Text = pt[1];
                    //            lblR.Visible = true;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        String msg;
                    //        if (pt[2] == "紅棋")
                    //        {
                    //            socketSend("C," + NickName + ",黑棋,");
                    //            myColor = "黑棋";
                    //            lblR.Text = pt[1];
                    //            lblB.Text = NickName;
                    //            lblR.Visible = true;
                    //            lblB.Visible = true;
                    //            msg="對方:" + pt[1] + "選到了紅棋 . 所以您是黑棋";

                    //        }
                    //        else
                    //        {
                    //            socketSend("C," + NickName + ",紅棋,");
                    //            myColor = "紅棋";
                    //            lblB.Text = pt[1];
                    //            lblR.Text = NickName;
                    //            lblR.Visible = true;
                    //            lblB.Visible = true;
                    //            msg = "對方:" + pt[1] + "選到了黑棋 . 所以您是紅棋";
                    //        }
                    //        addMessage("遊戲開始！, " + pt[1] + "正在下...");
                    //    }
                    //    break;
                    case "P": //期局進行中
                        if (gameStart)
                        {
                            gameStart = false;
                            if (occupation[Convert.ToInt32(pt[2])].ID / 16 == 0)  //對方紅棋
                            {
                                lblR.Text = pt[1];
                                lblB.Text = NickName;
                                myColor = "黑棋";
                            }
                            else
                            {
                                lblB.Text = pt[1];
                                lblR.Text = NickName;
                                myColor = "紅棋";

                            }
                        }
                        pic = null;
                        progressBoard(Convert.ToInt32(pt[2]), Convert.ToInt32(pt[3]));  //2nd argument = -1 , means 翻牌
                        myTurn = true;
                        addMessage(NickName + ", 該您下！ 您是 " + myColor);
                        break;
                    case "A"://要求再一盤
                        if (MessageBox.Show(pt[1] + " 邀請再來一局！好嗎？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            socketSend("Y," + NickName + ",");
                            btnReNew.Enabled = false;
                        }
                        else
                            socketSend("N," + NickName + ",");
                        refresh();

                        break;
                    case "F"://比賽有結果
                        btnReNew.Enabled = true;
                        progressBoard(Convert.ToInt32(pt[2]), Convert.ToInt32(pt[3]));
                        myTurn = false;
                        addMessage("可惜 !" + pt[1] + "贏了！ 要再來一局嗎?");
                        break;
                    //case "D"://比賽和局
                    //    btnReNew.Enabled = true;
                    //    progressBoard(Convert.ToInt32(pt[2]), Convert.ToInt32(pt[3]));
                    //    myTurn = false;
                    //    gameStart = false;
                    //    addMessage("這局平手!! 要再來一局嗎?");
                    //    break;

                    case "N"://收到A回覆不接受
                        addMessage(pt[1] + "不玩了 !");
                        break;
                    case "Y":
                        addMessage(pt[1] + ",接受您的邀請再來一局 !");
                        refresh();
                        btnReNew.Enabled = false;
                        break;
                    case "E":
                        addMessage(pt[1] + ",已離線 !");
                        refresh();
                        break;


                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }


        private void progressBoard(int idx, int outidx)
        {
            BasicPic p1,p2;
            try
            {
                p1 = occupation[idx];
                if (outidx >= 0 && occupation[outidx] != null)
                {
                    //對方符號
                    p2 = occupation[outidx];
                    occupation[idx].Location = occupation[outidx].Location;
                    occupation[outidx] = occupation[idx];
                    occupation[idx] = null;
                    p1.prePos = p1.boardPos;
                    p1.boardPos = p2.boardPos;
                    p2.prePos = p2.boardPos;
                    p2.boardPos = -1;
                    if (p2.ID/16==0)
                    {
                        p2.setPos(originRed[p2.ID, 0], originRed[p2.ID, 1]);
                    }
                    else
                    {
                        p2.setPos(originBlack[p2.ID - 16, 0], originBlack[p2.ID - 16, 1]);
                    }
                }
                else
                {
                    if (outidx >= 0 && occupation[outidx] == null) //移位
                    {
                        occupation[idx].setPos(board[outidx, 0], board[outidx, 1]);
                        occupation[outidx] = occupation[idx];
                        occupation[idx] = null;
                        p1.prePos = p1.boardPos;
                        p1.boardPos = outidx;

                    }
                    else
                    {
                        p1.setToFront();

                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
          }

        private void putAllChessToBoard(string orderString)
        {
            string [] odr = orderString.Split(';');
            for (int i = 0; i < 32; i++)
            {
                int ChessID=Convert.ToInt32 (odr[i]);
                //allChess[ChessID].setToBack();
                allChess[ChessID].setPos(board[i, 0], board[i, 1]);
                allChess[ChessID].prePos = -1;
                allChess[ChessID].BringToFront();
                allChess[ChessID].BackColor = System.Drawing.Color.Transparent;
                allChess[ChessID].boardPos = i;
                occupation[i] = allChess[ChessID];
                Thread.Sleep(50);
            }
        }


        private void shuffChess()
        {
            for (int i = 0; i < 32; i++)
            {
                allChess[i].setToBack();
                Thread.Sleep(100);
            }
            for (int k = 0; k < 10; k++)
            {
                Random Rnd = new Random();
                int c1 = Rnd.Next(0, 16);
                int c2 = Rnd.Next(0, 16);
                BasicPic p1 = allChess[c1];
                BasicPic p2 = allChess[c2];
                p1.BackColor = System.Drawing.Color.Transparent;
                p2.BackColor = System.Drawing.Color.Transparent;
                Point cp1 = p1.Location;
                Point cp2 = p2.Location;
                int dx = (int)Math.Ceiling((cp1.X - cp2.X) / 10.0);
                int dy = (int)Math.Ceiling((cp1.Y - cp2.Y) / 10.0);
                for (int i = 0; i < 10; i++)
                {
                    p1.Left = p1.Left - dx;
                    p2.Left = p2.Left + dx;

                    p1.Top = p1.Top - dy;
                    p2.Top = p2.Top + dy;
                    Thread.Sleep(20);
                }
                p1.Location = cp2;
                p2.Location = cp1;
                c1 = Rnd.Next(16, 32);
                c2 = Rnd.Next(16, 32);
                p1 = allChess[c1];
                p2 = allChess[c2];
                p1.BackColor = System.Drawing.Color.Transparent;
                p2.BackColor = System.Drawing.Color.Transparent;

                cp1 = p1.Location;
                cp2 = p2.Location;
                dx = (int)Math.Ceiling((cp1.X - cp2.X) / 10.0);
                dy = (int)Math.Ceiling((cp1.Y - cp2.Y) / 10.0);
                for (int i = 0; i < 10; i++)
                {
                    p1.Left = p1.Left - dx;
                    p2.Left = p2.Left + dx;
                    p1.Top = p1.Top - dy;
                    p2.Top = p2.Top + dy;
                    Thread.Sleep(20);
                }
                p1.Location = cp2;
                p2.Location = cp1;

            }
            //timer1.Enabled = true;
            //Thread.Sleep(15000);
            //timer1.Enabled = false;


        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (pic == null || gameStart ==false) return;
        //    if (pic.BackColor == System.Drawing.Color.Transparent) return;
        //    pic.EnableTM(false);
        //    pic.BackColor = System.Drawing.Color.Transparent;
        //    myTurn = false;
        //    myPicture.Enabled = false;
        //    imageOccupation[CurrPos] = pic;
        //    if (CalculateFinal())
        //    {
        //        socketSend("F," + NickName + "," + CurrPos.ToString() + "," + pattern.ToString() + ",");
        //        setPattern();
        //        addMessage(NickName + ", 恭喜,您贏了!! 要再來一局嗎?");
        //        gameStart = false;
        //        btnReNew.Enabled = true;
        //    }
        //    else
        //    {
        //        if (checkDrawDTie())
        //        {
        //            socketSend("D," + NickName + "," + CurrPos.ToString() + "," + pattern.ToString() + ",");
        //            addMessage(NickName + ", 這局平手!! 要再來一局嗎?");
        //            gameStart = false;
        //            btnReNew.Enabled = true;

        //        }
        //        else
        //        {
        //            socketSend("P," + NickName + "," + CurrPos.ToString() + ",");
        //            addMessage(NickName + ", 對方正在下...");
        //        }
        //    }
        //}

        /// <summary>
        /// 將提示訊息填入畫面上方的ListBox，並維持僅保留4筆
        /// </summary>
        /// <param name="message"></param>
        private void addMessage(String message)
        {
            listBox1.Items.Add(message);
            if (listBox1.Items.Count > 4)
            {
                listBox1.Items.RemoveAt(0);
            }
        }

  

        bool myTurn = false;    //維持雙方僅其中一方取得myTurn =true, 以便下棋，下完傳P訊息換對方取得myTurn =true
        BasicPic pic;           //在走每一步時作用的圖形符號儲存於此(記憶體儲存位址)
        string myColor = "紅棋";      //選擇紅棋
        bool gameStart = false;
        BasicPic[] occupation = new BasicPic[32]; //棋盤32格每格是那一棋子佔據，沒有則填E
        //{上，下，左，右}座標相對於Form的座標
        int[,] board = new int[32, 4];
        int[,] originRed = new int[16, 4];
        int[,] originBlack = new int[16, 4];
        BasicPic[] allChess = new BasicPic[32];
        int[,] row = new int[4, 8];
        int[,] col = new int[8, 4];


 

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            BasicPic  p1 = (BasicPic)sender;
            int pos1, pos2;
            if (!myTurn) return;
            if (pic == null)
            {
                    if (gameStart)
                    {
                        gameStart = false;
                        if(p1.ID/16==0)
                        {
                            myColor = "紅棋";
                            lblR.Text  = NickName;
                        }
                        else
                        {
                            myColor = "黑棋";
                            lblB.Text = NickName;
                        }
                    }
                    pic = p1;
                    if (!pic.openState)
                    {
                        pic.setToFront();
                        int pos = pic.boardPos;
                         myTurn = false;
                         if (isFinalize())
                         {
                             socketSend("F," + NickName + "," + pos.ToString() + ",-1,");
                         }
                         else
                             socketSend("P," + NickName + "," + pos.ToString() + ",-1,");
                        addMessage("對方正在下棋子！");

                        pic = null;

                    }
                    else
                    {
                        if ((pic.ID / 16 == 0 && myColor == "紅棋") || (pic.ID / 16 == 1 && myColor == "黑棋"))
                        {
                            pic.EnableTM(true);
                            addMessage("請再選要吃的對方棋子！或是移位！");
                        }
                        else
                        {
                            pic = null;
                            addMessage("您是" + myColor +"喔!");
                            addMessage("請重選！");
                        }
                    }
                    return;
            }
           if (pic == p1)
                    {
                        pic.EnableTM(false);
                        pic = null;
                        return;
                    }
           if (p1.openState == false)
                  {
                      addMessage("該子未翻開!");
                      return;
                  }
           if (p1.ID /16 == pic.ID/16)
                  {
                      addMessage("同色喔！!");
                      return;
                  }

           pos1 = pic.boardPos;
           pos2 = p1.boardPos;
           if (pic.priority == 2)  //炮
               {
                          //if same col
                          if (pos1 % 8 == pos2 % 8 && 
                             ( ( Math.Abs(pos1-pos2) == 16 && occupation [(pos1+pos2)/2] != null ) ||
                               (Math.Abs(pos1 - pos2) == 24 &&
                               oneOfIsNull(occupation[rtnSmall(pos1, pos2) +8],occupation[rtnSmall(pos1, pos2) +16]))))
                               // same col
                          {
                              myTurn = false;
                              pic.EnableTM(false);
                              progressBoard(pos1, pos2);
                              if (isFinalize())
                              {
                                  socketSend("F," + NickName + "," + pos1 + "," + pos2.ToString() + ",");
                              }
                              else
                              socketSend("P," + NickName + "," + pos1 + "," + pos2.ToString() + ",");
                                  addMessage("對方正在下棋子！");
                          }
                          //if same row
                          if (pos1 / 8 == pos2 / 8) 
                          // &&  ((Math.Abs(pos1 - pos2) == 8 && occupation[(pos1 + pos2) / 2] != null) ||
                          //     (Math.Abs(pos1 - pos2) == 16 &&
                          //     oneOfIsNull(occupation[rtnSmall(pos1, pos2) + 8], occupation[rtnSmall(pos1, pos2) + 16]))))
                          // same row
                          {
                              int increment = (pos2 - pos1) / Math.Abs(pos1 - pos2);
                              int count = 0;
                              for (int i = pos1 + increment; i * increment < pos2 * increment; i = i + increment)
                              {
                                  if (occupation[i] != null) count += 1;
                              }
                              if (count == 1)//炮可吃
                              {
                              myTurn = false;
                              pic.EnableTM(false);
                              progressBoard(pos1, pos2);
                              if (isFinalize())
                              {
                                  socketSend("F," + NickName + "," + pos1.ToString() + "," + pos2.ToString() + ",");
                              }
                              else
                                  socketSend("P," + NickName + "," + pos1.ToString() + "," + pos2.ToString() + ",");
                              addMessage("對方正在下棋子！");
                              }
                          }
                          pic = null;
                           return;
              } // if pic.priority == 2


              if ((Math.Abs(pos1 - pos2) == 1 || Math.Abs(pos1 - pos2) == 8) && (pic.priority >= p1.priority || (pic.priority ==1 && p1.priority ==7)))
              {
              
                      myTurn = false;
                      pic.EnableTM(false);
                  
                      pic = null;
                      progressBoard(pos1, pos2);
                      if (isFinalize())
                      {
                          socketSend("F," + NickName + "," + pos1.ToString() + "," + pos2.ToString() + ",");
                      }
                      else
                        socketSend("P," + NickName + "," + pos1.ToString() + "," + pos2.ToString() + ",");
                      addMessage("對方正在下棋子！");
              }


            }
 
        private bool isFinalize() //放在棋子移動後
        {
            //return false;
            int Opponentgroup = 0;
            if(myColor =="紅棋")
                Opponentgroup=1;
            else
                Opponentgroup = 0;

            for(int i=0; i<32; i++){
                if (occupation[i] != null && occupation[i].ID / 16 == Opponentgroup)
               {
                   return false;
               }
            }
            return true;
        }


        private int rtnSmall(int a, int b)
        {
            if (a >= b) return b;
            else return a;
        }

        private bool oneOfIsNull(Object a, Object b)
        {
            if ((a == null && b == null) || (a != null && b != null)) return false;
            else return true;
        }
  

        private void btnEnd_Click_1(object sender, EventArgs e)
        {
            socketSend("E," + NickName + ",");
            
            SK.Shutdown(SocketShutdown.Both);
            SK.Close();
            //Close();

        }

        private void btnReNew_Click(object sender, EventArgs e)
        {
           
            //要求從新來一局
            socketSend("A," + NickName + ",");


        }
        private void refresh()
        {
            //Panel.CheckForIllegalCrossThreadCalls = false;
            //BasicPic.CheckForIllegalCrossThreadCalls = false; 
            myTurn = false;
            pic = null;
            myColor = "紅棋";
            lblR.Text = "";
            lblB.Text = "";
            //清空棋盤記錄

            for (int i = 0; i < 16; i++) { 
                occupation[i]= null ;
                allChess[i].setPos(originRed[i, 0], originRed[i, 1]);
                allChess[i].setToFront();
            }
            //清空棋盤圖像
            for (int i = 16; i < 32; i++)
            {
                occupation[i] = null;
                allChess[i].setPos(originBlack[i-16, 0], originBlack[i-16, 1]);
                allChess[i].setToFront();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            PictureBox.CheckForIllegalCrossThreadCalls = false; 
            Random Rnd = new Random();
            int c1=Rnd.Next(0, 16);
            int c2 = Rnd.Next(0, 16);
            BasicPic p1 = allChess[c1];
            BasicPic p2= allChess[c2];

            Point cp1=p1.Location;
            Point cp2 = p2.Location;
            int dx = (int)Math.Ceiling ((cp1.X - cp2.X)/10.0);
            int dy = (int)Math.Ceiling((cp1.Y - cp2.Y) / 10.0);
            for (int i = 0; i < 10; i++)
            {
                p1.Left = p1.Left - dx;
                p2.Left = p2.Left + dx;

                p1.Top = p1.Top - dy;
                p2.Top = p2.Top + dy;
                Thread.Sleep(200);
            }
            p1.Location = cp2;
            p2.Location = cp1;
            c1 = Rnd.Next(16, 32);
            c2 = Rnd.Next(16, 32);
             p1 = allChess[c1];
            p2 = allChess[c2];

            cp1 = p1.Location;
            cp2 = p2.Location;
            dx = (int)Math.Ceiling((cp1.X - cp2.X) / 10.0);
            dy = (int)Math.Ceiling((cp1.Y - cp2.Y) / 10.0);
            for (int i = 0; i < 10; i++)
            {
                p1.Left = p1.Left - dx;
                p2.Left = p2.Left + dx;

                p1.Top = p1.Top - dy;
                p2.Top = p2.Top + dy;
                Thread.Sleep(200);
            }
            p1.Location = cp2;
            p2.Location = cp1;

        }

        private void pnlBoard_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (pic == null) return;
                int pos = pic.prePos;
                Point pt = this.PointToClient(pnlBoard.PointToScreen(new Point(e.X, e.Y)));
                for (int i = 0; i < 32; i++)
                {
                    if (pt.X >= board[i, 0]-10 && pt.X <= board[i, 2] && pt.Y >= board[i, 1]-7 && pt.Y <= board[i, 3])
                    {
                        if (occupation[i] != null) return;
                        progressBoard(pic.boardPos, i);
                        if (isFinalize())
                        {
                            socketSend("F," + NickName + "," + pos.ToString() + "," + i.ToString() + ",");
                        }
                        else
                            socketSend("P," + NickName + "," + pos.ToString() + "," + i.ToString() + ",");
                        addMessage("對方正在下棋子！");
                        pic.EnableTM(false);
                        pic = null;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }


    public class BasicPic : PictureBox
    {
        private System.Timers.Timer tm;
        public int ID;
        public int priority;
        public int prePos;
        public int boardPos=-1;
        private Image backp;
        private Image forep;
        private int turn = 0;
        public bool openState = false;//代表蓋住  
        public BasicPic(Image fp,Image bp)
        {
            BackColor = System.Drawing.Color.Transparent;
            Size =new System.Drawing.Size(60, 60);
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            forep = fp;
            backp = bp;
            tm = new System.Timers.Timer();
            tm.Interval = 10;
            this.tm.Elapsed += new System.Timers.ElapsedEventHandler(this.tm_Tick);
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            tm.Interval = 500;
            switch (turn)
            {
                case 0:
                    this.BackColor = System.Drawing.Color.Magenta;
                    break;
                case 1:
                    this.BackColor = System.Drawing.Color.Cyan;
                    break;
                case 2:
                    this.BackColor = System.Drawing.Color.Yellow;
                    break;
            }
            turn++;
            if (turn > 2) turn = 0;
        }
        public void EnableTM(bool set)
        {
            tm.Interval = 10;

            tm.Enabled = set;
            if (!set) BackColor = System.Drawing.Color.Transparent;
        }
        public void setToFront()
        {
            this.BackgroundImage = forep;
            if (!tm.Enabled) BackColor = System.Drawing.Color.Transparent;
            openState = true;
        }
        public void setToBack()
        {
            this.BackgroundImage = backp;
            if (!tm.Enabled) BackColor = System.Drawing.Color.Transparent;
            openState = false;
        }
        public void setPos(int x, int y)
        {
            this.Left = x;
            this.Top = y;
        }
    }
}

