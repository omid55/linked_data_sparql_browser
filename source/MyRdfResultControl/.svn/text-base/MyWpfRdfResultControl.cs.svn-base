using System;
using System.Collections.Generic;
using System.Linq;
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
using VDS.RDF.Query;
using System.Threading;

namespace MyRdfResultControl
{
    public class MyWpfRdfResultControl : WrapPanel
    {
        #region Fields

        private ScrollViewer scroll;
        private StackPanel mainPanel;
        private SparqlResultSet resultSet;

        #endregion

        #region Properties

        public MouseButtonEventHandler Href_Click { get; set; }
        public System.Windows.Controls.Primitives.Popup _popUp;

        #endregion

        #region Methods

        static MyWpfRdfResultControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (MyWpfRdfResultControl),
                                                     new FrameworkPropertyMetadata(typeof (MyWpfRdfResultControl)));
        }

        public SparqlResultSet getResultSet()
        {
            return resultSet;
        }

        public void setResultSet(SparqlResultSet res)
        {
            resultSet = res;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //initForTripleBrowing();
        }

        public void initForTripleBrowing()
        {
            scroll = new ScrollViewer();
            mainPanel = new StackPanel();
            this.Children.Clear();

            for (int i = 0; i < resultSet.Count; i++)
            {
                SparqlResult result = resultSet[i];

                Grid internalGrid = new Grid();
                Rectangle rec = new Rectangle();
                StackPanel internalStackPanel = new StackPanel();

                Label titleLabel = new Label();
                titleLabel.Background = Brushes.LightBlue;
                titleLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                titleLabel.VerticalContentAlignment = VerticalAlignment.Center;
                titleLabel.HorizontalAlignment = HorizontalAlignment.Stretch;
                titleLabel.Content = i + 1;
                internalStackPanel.Children.Add(titleLabel);

                rec.Stroke = Brushes.Aqua;
                rec.StrokeThickness = 2;
                rec.VerticalAlignment = VerticalAlignment.Stretch;
                rec.HorizontalAlignment = HorizontalAlignment.Stretch;

                internalGrid.Children.Add(rec);
                internalGrid.Children.Add(internalStackPanel);

                foreach (string variableName in result.Variables.ToArray())
                {
                    Label promptLabel = new Label();
                    promptLabel.Content = variableName + " :  ";
                    promptLabel.Padding = new Thickness(10);

                    string data = result.Value(variableName).ToString();
                    Run href = new Run(data);
                    href.MouseDown += new MouseButtonEventHandler(Href_Click);
                    href.MouseEnter += new MouseEventHandler(href_MouseEnter);

                    TextBlock dataBlock = new TextBlock { TextWrapping = TextWrapping.Wrap };
                    string dataa = result.Value(variableName).ToString();
                    if (dataa.StartsWith("http://"))
                    {
                        Run hreff = new Run(dataa);
                        hreff.MouseDown += new MouseButtonEventHandler(Href_Click);
                        hreff.MouseEnter += new MouseEventHandler(href_MouseEnter);
                        dataBlock.Inlines.Add(hreff);
                    }
                    else
                    {
                        dataBlock.Text = dataa;
                    }
                    dataBlock.Padding = new Thickness(10);
                    dataBlock.Foreground = Brushes.Blue;

                    WrapPanel internalWrap = new WrapPanel();
                    internalWrap.Orientation = Orientation.Horizontal;
                    internalWrap.Children.Add(promptLabel);
                    internalWrap.Children.Add(dataBlock);

                    internalStackPanel.Children.Add(internalWrap);
                }

                internalGrid.Margin = new Thickness(10);

                mainPanel.Children.Add(internalGrid);
            }

            scroll.Content = mainPanel;
            this.Children.Add(scroll);
        }

        public void initForRdfTypeBrowing()
        {
            scroll = new ScrollViewer();
            mainPanel = new StackPanel();
            this.Children.Clear();

            int i = 0;
            StackPanel lastType = null;
            while (i < resultSet.Count)
            {
                SparqlResult result = resultSet[i];
                string type = result.Value("type").ToString();

                StackPanel internalSt = new StackPanel();
                internalSt.Orientation = Orientation.Vertical;
                internalSt.Margin = new Thickness(20);

                Label typePromptLabel = new Label();
                typePromptLabel.Content = type + " :  ";
                typePromptLabel.Padding = new Thickness(10);
                internalSt.Children.Add(typePromptLabel);

                while (i < resultSet.Count)
                {
                    if (resultSet[i].Value("type").ToString().CompareTo(type) == 0)
                    {
                        if(i >= resultSet.Count) break;

                        result = resultSet[i++];
                        foreach (string variableName in result.Variables.ToArray())
                        {
                            if (variableName.CompareTo("type") == 0) continue;

                            Label promptLabel = new Label();
                            promptLabel.Content = "-";
                            promptLabel.Padding = new Thickness(10);

                            TextBlock dataBlock=new TextBlock {TextWrapping = TextWrapping.Wrap};
                            string data = result.Value(variableName).ToString();
                            if (data.StartsWith("http://"))
                            {
                                Run href=new Run(data);
                                href.MouseDown += new MouseButtonEventHandler(Href_Click);
                                href.MouseEnter += new MouseEventHandler(href_MouseEnter);
                                dataBlock.Inlines.Add(href);
                            }
                            else
                            {
                                dataBlock.Text = data;
                            }
                            dataBlock.Padding = new Thickness(10);
                            dataBlock.Foreground = Brushes.Blue;

                            WrapPanel wp = new WrapPanel();
                            wp.Orientation = Orientation.Horizontal;
                            wp.Children.Add(promptLabel);
                            wp.Children.Add(dataBlock);

                            internalSt.Children.Add(wp);
                        }
                    }
                    else
                    {
                        mainPanel.Children.Add(internalSt);
                        type = resultSet[i].Value("type").ToString();
                        break;
                    }
                }
                if(i>=resultSet.Count)
                {
                    lastType = internalSt;
                }
            }
            if (lastType != null)
            {
                mainPanel.Children.Add(lastType);
            }

            scroll.Content = mainPanel;
            this.Children.Add(scroll);
        }

        void href_MouseEnter(object sender, MouseEventArgs e)
        {
            Run _run = (Run) e.Source;
            _popUp.Tag = _run.Text;
            _popUp.IsEnabled = true;
            //_popUp.IsOpen = true;
            //_popUp.StaysOpen = true;
        }

        /*void href_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Done ;)");
        }*/

        #endregion
    }
}