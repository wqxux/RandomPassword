using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace RandomPassW
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string password = string.Empty;
        private string number = "0123456789";
        private string upperCase = "QWERTYUIOPASDFHJKLZXCVBNM";
        private string lowerCase = "qwertyuiopasdfghjklzxcvbnm";
        private string specialChar = "!@#$%^&*()_+-=[];'',./{}:<>";
        int a;
        string randomChars;
        public bool isNum, isUpper, isLower, isSpecial;

        public MainPage()
        {
            this.InitializeComponent();
        }

        //获取随机密码
        public string GetRandomPassword(int passwordLen)
        {
            clearTextBlock();
            getLastChar();

            int randomNum;
            Random random = new Random();
            for (int i = 0; i < passwordLen; i++)
            {
                randomNum = random.Next(randomChars.Length);
                password += randomChars[randomNum];
            }
            return password;
        }
        //清空文本框
        public void clearTextBlock()
        {
            password = string.Empty;
            randomChars = string.Empty;
        }
        //按钮动作
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            GetRandomPassword(a);
            newtextBlock.Text = password;
        }
        //按钮选择密码位数
        private void six_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            a = 6;
        }

        private void ten_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            a = 10;
        }
        private void eight_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            a = 8;
        }

        private void tel_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            a = 12;
        }


        private void number_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            isNum = true;
        }

        private void upperCase_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            isUpper = true;
        }

        private void lowerCase_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            isLower = true;
        }

        private void specialChar_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isSpecial = false;
        }

        private void lowerCase_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isLower = false;
        }

        private void upperCase_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isUpper = false;
        }

        private void number_checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            isNum = false;
        }

        private void specialChar_checkBox_Checked(object sender, RoutedEventArgs e)
        {
            isSpecial = true;
        }


        public void getLastChar()
        {


            if (isNum)
            {
                randomChars += number;
            }
            if (isUpper)
            {
                randomChars += upperCase;
            }

            if (isLower)
            {
                randomChars += lowerCase;
            }
            if (isSpecial)
            {
                randomChars += specialChar;
            }
            return;
        }


        //复制按钮
        private void copy_Button_Click(object sender, RoutedEventArgs e)
        {
            Edi.UWP.Helpers.Utils.CopyToClipBoard(password);
        }
        //切换主题
        private void ToggleTheme_OnToggled(object sender, RoutedEventArgs e)
        {
            if (null != ToggleTheme)
            {
                this.RequestedTheme = ToggleTheme.IsOn ? ElementTheme.Dark : ElementTheme.Light;

                if (ToggleTheme.IsOn)
                {
                    Edi.UWP.Helpers.UI.ApplyColorToTitleBar(Color.FromArgb(255, 43, 43, 43), Colors.White, Colors.DimGray, Colors.White);
                    Edi.UWP.Helpers.UI.ApplyColorToTitleButton(Color.FromArgb(255, 43, 43, 43), Colors.White, Colors.DimGray, Colors.White, Colors.DimGray, Colors.White, Colors.DimGray, Colors.White);
                    Edi.UWP.Helpers.Mobile.SetWindowsMobileStatusBarColor(Color.FromArgb(255, 0, 0, 0), Colors.White);
                }
                else
                {
                    Edi.UWP.Helpers.Mobile.SetWindowsMobileStatusBarColor(Color.FromArgb(255, 0, 114, 188), Colors.White);
                    Edi.UWP.Helpers.UI.ApplyColorToTitleBar(
                    Color.FromArgb(255, 0, 114, 188),
                    Colors.White,
                    Colors.LightGray,
                    Colors.Gray);

                    Edi.UWP.Helpers.UI.ApplyColorToTitleButton(
                        Color.FromArgb(255, 0, 114, 188), Colors.White,
                        Color.FromArgb(255, 51, 148, 208), Colors.White,
                        Color.FromArgb(255, 0, 114, 188), Colors.White,
                        Colors.LightGray, Colors.Gray);
                }
            }
        }

    }
}
