using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZTube.Views.Query_And_Processing
{
    /// <summary>
    /// Interaction logic for QueryBoxView.xaml
    /// </summary>
    public partial class QueryBoxView : UserControl
    {
        public QueryBoxView()
        {
            InitializeComponent();
        }

        private void UrlName_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Avoid New Line For TextBox if User Only Clicked Enter
            if (e.KeyboardDevice.Modifiers != ModifierKeys.Shift && e.KeyboardDevice.IsKeyDown(Key.Enter))
                e.Handled = true;
        }
    }
}
