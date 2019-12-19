using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleXiangqi;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        control game = new control();
        TextBlock Message = new TextBlock();
        public MainWindow()
        {
            InitializeComponent();
            createGridWithBoard();
            RedrawGrid();
            /**Grid grid = new Grid();//new window
            for(int i=0; i<=8; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i <= 9; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for(int col = 0; col <= 8; col++)
            {
                for(int row = 0; row <= 9; row++)
                {
                    Button btn = new Button();
                    btn.Name = "Button" + col.ToString() + row.ToString();
                    Grid.SetRow(btn, row);
                    Grid.SetColumn(btn, col);
                    btn.Click += Btn_Click;
                    btn.SetValue(XQRowProperty, Convert.ToString(row));
                    grid.Children.Add(btn);
                }
            }
            Button btnDCI = new Button();
            btnDCI.FontSize = 50;
            btnDCI.Height = 100;
            btnDCI.Width = 200;


            WrapPanel wrPnl = new WrapPanel();

            TextBlock txtBlk = new TextBlock();

            txtBlk.Text = "DGUT";
            txtBlk.Foreground = Brushes.Blue;

            wrPnl.Children.Add(txtBlk);

            btnDCI.Content = wrPnl;


            this.Content = grid;
            **/
        }


        public void createGridWithBoard()
        {
            grid.RowDefinitions.Add(new RowDefinition());
            Message.Text = "Start";
            Message.FontSize = 30;
            Message.TextAlignment = TextAlignment.Center;
            Grid.SetColumnSpan(Message, 9);
            Grid.SetRow(Message, 10);
            grid.Children.Add(Message);
            this.Content = grid;
            game.Board.InitializeBorad();
            for (int i = 0; i <= 8; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for(int j = 0; j <= 9; j++)
            {

                grid.RowDefinitions.Add(new RowDefinition());
            }

            for(int row = 0; row <= 9; row++)
            {
                for(int col = 0; col <= 8; col++)
                {
                    Button button = new Button();
                    button.Name = "Button" + Convert.ToString(col) + Convert.ToString(row); 
                    button.SetValue(XQRowProperty, row);
                    button.SetValue(XQColProperty, col);
                    button.Click += Button_Click;
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    grid.Children.Add(button);
                }
            }


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int btnRow = (int)(((Button)sender).GetValue(XQRowProperty));
            int btnCol = (int)(((Button)sender).GetValue(XQColProperty));
            MessageBox.Show("Button is " + ((Button)sender).Name+ " . Row is "+ btnRow.ToString()+"  .Column is "+btnCol.ToString());
            handleclick(btnRow, btnCol);
        }

        public static readonly DependencyProperty XQRowProperty =
            DependencyProperty.Register("XQRow", typeof(int), typeof(Button));

        public static readonly DependencyProperty XQColProperty =
        DependencyProperty.Register("XQCol", typeof(int), typeof(Button));

        public void RedrawGrid()
        {
            int z = 1;
            foreach(chess i in game.Board.Chess)
            {
                    Button btnSelected = (Button)grid.Children[z];
                    if (i.Getname() == "nochess")
                    {
                        btnSelected.SetValue(ContentProperty, "");
                    }
                    else
                    {
                        btnSelected.SetValue(ContentProperty, i.Getname());
                        if (i.Getcolor() == "red")
                        {
                            btnSelected.SetValue(ForegroundProperty, Brushes.Red);
                        }
                        else if (i.Getcolor() == "black")
                        {
                            btnSelected.SetValue(ForegroundProperty, Brushes.Black);
                        }
                    }
                    if(i.Cango == true)
                {
                    btnSelected.SetValue(BackgroundProperty, Brushes.Aqua);
                }
                else
                {
                    btnSelected.SetValue(BackgroundProperty, Brushes.Gray);
                }
                z++;
            }

        }

        public void handleclick(int row, int col)
        {
            try
            {
                switch (game.state)
                {
                    case true:
                        game.Playchoose(row, col);
                        game.Board.Wherecanchessgo(col, row);
                        ChangeState();
                        break;

                    case false:
                        game.Movechess(row, col);
                        ChangeState();
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ChangeState();
            }
            RedrawGrid();
        }

        public void ChangeState()
        {
            switch (game.state)
            {
                case false:
                    Message.Text = "Select Move";
                    break;

                case true:
                    Message.Text = "select Piece";
                    break;
            }
        }
        /** private void Button_Click(object sender, RoutedEventArgs e)
         {
             MessageBox.Show(((Button)sender).GetValue());
         }

         public void CreateGrid(){
             GameBoardGrid.ColumnDefinitions.Add(new ColumnDefinition());     
         }**/
    }
}
