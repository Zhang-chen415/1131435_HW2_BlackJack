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

namespace _1131435_HW2_BlackJack
{
    public partial class Form1 : Form
    {
        private Deck currentDeck;            // 目前的牌堆
        private List<Card> playerHand;       // 玩家手上的牌
        private List<Card> dealerHand;       // 莊家手上的牌
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }
        private void StartNewGame()
        {
            // 初始化牌堆與雙方的手牌
            currentDeck = new Deck();
            playerHand = new List<Card>();
            dealerHand = new List<Card>();

            // 清空畫面上的撲克牌 (假設你前面拉的 Panel 叫做 flpPlayer 和 flpDealer)
            flpPlayer.Controls.Clear();
            flpDealer.Controls.Clear();
            lblStatus.Text = "遊戲開始！請選擇要牌或停牌。";
            btnHit.Enabled = true;
            btnStand.Enabled = true;

            System.Media.SoundPlayer startPlayer = new System.Media.SoundPlayer(Properties.Resources.洗牌);
            startPlayer.Play();
            // 雙方各抽兩張牌
            DrawCardFor(playerHand, flpPlayer);
            DrawCardFor(playerHand, flpPlayer);

            // 莊家的部分，第一張牌通常要蓋著
            DrawCardFor(dealerHand, flpDealer, true);
            DrawCardFor(dealerHand, flpDealer);

            UpdateScoreUI(true);
        }
        private void DrawCardFor(List<Card> hand, FlowLayoutPanel panel, bool isHidden = false)
        {
            Card newCard = currentDeck.DrawCard();
            if (newCard != null)
            {
                hand.Add(newCard);

                PictureBox picCard = new PictureBox();

                // 判斷是否要蓋牌
                if (isHidden)
                {
                    picCard.Image = Properties.Resources.back; // 呼叫你的牌背圖片
                }
                else
                {
                    picCard.Image = newCard.GetCardImage();
                }

                picCard.SizeMode = PictureBoxSizeMode.StretchImage;
                picCard.Width = 80;
                picCard.Height = 120;
                panel.Controls.Add(picCard);
            }
        }
        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            int aceCount = 0;

            foreach (Card card in hand)
            {
                score += card.GetPoint();
                if (card.Rank == 1) aceCount++; // 記錄有幾張 A
            }

            // 如果總分超過 21 點，且手上有 A，就把 A 當作 1 點 (扣回 10 分)
            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }
        private void UpdateScoreUI(bool hideDealerScore = false)
        {
            int playerScore = CalculateScore(playerHand);
            int dealerScore = CalculateScore(dealerHand);

            lblPlayerScore.Text = $"玩家：{playerScore} 點";

            // 判斷是否要隱藏莊家分數
            if (hideDealerScore)
            {
                // 只顯示莊家第二張牌的分數
                lblDealerScore.Text = $"莊家：{dealerHand[1].GetPoint()} + ? 點";
            }
            else
            {
                lblDealerScore.Text = $"莊家：{dealerScore} 點";
            }

            if (playerScore > 21)
            {
                System.Media.SoundPlayer losePlayer = new System.Media.SoundPlayer(Properties.Resources.輸了);
                losePlayer.Play();
                lblStatus.Text = "你爆牌了！莊家獲勝。";
                btnHit.Enabled = false;
                btnStand.Enabled = false;

                // 玩家爆牌結束遊戲時，順便把莊家的底牌翻開
                FlipDealerHoleCard();
                lblDealerScore.Text = $"莊家：{dealerScore} 點";
            }
        }
        private void FlipDealerHoleCard()
        {
            // 抓取莊家區域 (flpDealer) 裡面的第一張圖 (Controls[0])
            PictureBox holeCardPic = (PictureBox)flpDealer.Controls[0];
            // 將圖片替換回原本正確的牌面
            holeCardPic.Image = dealerHand[0].GetCardImage();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer hitPlayer = new System.Media.SoundPlayer(Properties.Resources.要牌);
            hitPlayer.Play();
            DrawCardFor(playerHand, flpPlayer); // 幫玩家抽一張牌
            UpdateScoreUI(true);                    // 更新分數
        }

        private async void btnStand_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer standPlayer = new System.Media.SoundPlayer(Properties.Resources.停牌);
            standPlayer.Play();
            btnHit.Enabled = false;
            btnStand.Enabled = false;

            // 1. 玩家停牌後，第一件事就是翻開莊家底牌！
            FlipDealerHoleCard();

            // 讓介面顯示莊家真實的總分
            UpdateScoreUI(false);

            int playerScore = CalculateScore(playerHand);
            int dealerScore = CalculateScore(dealerHand);

            // 莊家 AI 補牌邏輯保持不變
            while (dealerScore < 17)
            {
                await Task.Delay(1000);
                System.Media.SoundPlayer dealPlayer = new System.Media.SoundPlayer(Properties.Resources.要牌);
                dealPlayer.Play();
                DrawCardFor(dealerHand, flpDealer);
                dealerScore = CalculateScore(dealerHand);
                UpdateScoreUI(false); // 補完牌後再更新一次總分
            }



            // 下方的勝負判斷邏輯維持你原本的程式碼即可...
            if (dealerScore > 21)
            {
                lblStatus.Text = "莊家爆牌！恭喜你贏了！";
                System.Media.SoundPlayer winPlayer = new System.Media.SoundPlayer(Properties.Resources.贏了);
                winPlayer.Play();
            }
            else if (playerScore > dealerScore)
            {
                lblStatus.Text = "你的點數大於莊家！恭喜獲勝！";
                System.Media.SoundPlayer winPlayer = new System.Media.SoundPlayer(Properties.Resources.贏了);
                winPlayer.Play();
            }
            else if (dealerScore > playerScore)
            {
                lblStatus.Text = "莊家點數大於你！莊家獲勝。";
                System.Media.SoundPlayer winPlayer = new System.Media.SoundPlayer(Properties.Resources.輸了);
                winPlayer.Play();
            }
            else
            {
                lblStatus.Text = "雙方平手 (Push)！";
            }
        }
        public class Card
        {
            // 1. 屬性：花色與數字
            // 花色: 0=梅花, 1=方塊, 2=愛心, 3=黑桃
            public int Suit { get; set; }
            // 數字: 1=A, 2~10, 11=J, 12=Q, 13=K
            public int Rank { get; set; }

            // 2. 建構子 (建立卡牌時要傳入花色與數字)
            public Card(int suit, int rank)
            {
                Suit = suit;
                Rank = rank;
            }

            // 3. 取得 21 點的實際分數
            public int GetPoint()
            {
                if (Rank > 10) return 10; // J, Q, K 都是 10 點
                if (Rank == 1) return 11; // A 先預設為 11 點 (後續爆牌再算成 1 點)
                return Rank;              // 2~10 維持原分數
            }

            // 4. 動態抓取這張牌對應的圖片！
            public Image GetCardImage()
            {
                // 套用剛剛推導出的公式
                int picNumber = (Rank - 1) * 4 + Suit + 1;
                string imageName = "pic" + picNumber;

                // 透過 ResourceManager 利用字串動態從 Resources 抓取圖片
                object imgObject = Properties.Resources.ResourceManager.GetObject(imageName);

                return (Image)imgObject;
            }
        }
        public class Deck
        {
            // 宣告一個 List 來儲存牌堆裡的卡牌
            private List<Card> cards;

            // 宣告亂數產生器，用於洗牌
            private Random random = new Random();

            // 建構子：當產生 Deck 物件時，自動初始化並洗牌
            public Deck()
            {
                InitializeDeck();
                Shuffle();
            }

            // 1. 產生 52 張牌
            public void InitializeDeck()
            {
                cards = new List<Card>();

                // 外層迴圈：4 種花色 (0~3)
                for (int suit = 0; suit < 4; suit++)
                {
                    // 內層迴圈：13 種點數 (1~13)
                    for (int rank = 1; rank <= 13; rank++)
                    {
                        // 每次迴圈產生一張新牌，並加入 List 中
                        cards.Add(new Card(suit, rank));
                    }
                }
            }

            // 2. 洗牌 (使用經典的 Fisher-Yates 演算法)
            public void Shuffle()
            {
                int n = cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1); // 隨機挑選一個位置

                    // 將隨機挑選到的牌與目前的牌交換位置
                    Card temp = cards[k];
                    cards[k] = cards[n];
                    cards[n] = temp;
                }
            }

            // 3. 發一張牌 (從牌堆最上方抽取)
            public Card DrawCard()
            {
                // 如果牌堆空了，回傳 null 作為防呆機制
                if (cards.Count == 0) return null;

                // 取出 List 中的第一張牌 (索引 0)
                Card topCard = cards[0];

                // 將這張牌從牌堆中移除
                cards.RemoveAt(0);

                return topCard;
            }
        }

    }
}
