using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class BrakeTestForm : Form
    {
        private NewTripForm tripForm;
        private int trainNumber;
        private bool isMainTestBrakeAdded;
        private int additionalBrakeTestNumber;

        public BrakeTestForm(NewTripForm tripForm, int trainNumber)
        {
            InitializeComponent();
            this.tripForm = tripForm;
            this.trainNumber = trainNumber;
            isMainTestBrakeAdded = true;
            additionalBrakeTestNumber = 0;
        }

        private void LoadSuitableBrakeTests()
        {
            brakeTestSelect.Items.Clear();
            brakeTestSelect.ResetText();

            int isEven = (trainNumber % 2) == 0 ? 1 : 0;

            string query = String.Empty;
            if (tripForm.doubleTrain.Checked)
            {
                query = "SELECT * FROM BrakeTests WHERE IsEvenNumberedDirection = @isEven" +
                    " AND RequiredSpeedForDoubleTrain != '-' ORDER BY RailwayLine";
            }
            else
            {
                query = "SELECT * FROM BrakeTests WHERE IsEvenNumberedDirection = @isEven " +
                    "AND RequiredSpeed != '-' ORDER BY RailwayLine";
            }

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@isEven", SqlDbType.Int).Value = isEven;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brakeTestSelect.Items.Add(new BrakeTest
                    {
                        Id = reader.GetInt32(0),
                        Depot = reader.GetInt32(1),
                        IsEvenNumberedDirection = reader.GetByte(2),
                        RailwayLine = reader.GetString(3),
                        RequiredSpeed = reader.GetString(4),
                        Point = reader.GetString(5),
                        RequiredSpeedForDoubleTrain = reader.GetString(6),
                        PointForDoubleTrain = reader.GetString(7)
                    });
                }
                reader.Close();

                brakeTestSelect.DisplayMember = "RailwayLine";
                brakeTestSelect.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                string trafficLightDir = isEven == 1 ? "чётных" : "нечётных";

                MessageBox.Show($"Не удалось загрузить список мест проб тормозов {trafficLightDir}" +
                    $" поездов:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Нет соединения с Базой Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            DataBase.CloseConnection();
        }

        private void ClickAdditionalBrakeTest(object sender)
        {
            Label label = (Label)sender;

            if (label.Text.StartsWith("Добавить"))
            {
                isMainTestBrakeAdded = false;
                label.Visible = false;

                int x = this.Width / 2 - brakeTestSelect.Width / 2;
                brakeTestSelect.Location = new(x, 80 + additionalBrakeTestNumber * 35);
                brakeTestSelect.Visible = true;
                brakeTestSelect.DroppedDown = true;
            }
        }

        private void SetBrakeTestRemoveButton()
        {
            if (additionalBrakeTestNumber == 0)
            {
                if (brakeTest.Text.StartsWith("Добавить"))
                {
                    removeBrakeTest.Visible = false;
                }
                else
                {
                    int x = this.Width / 2 - brakeTest.Width / 2 + brakeTest.Width + 2;
                    removeBrakeTest.Location = new(x, brakeTest.Location.Y);
                    removeBrakeTest.Visible = true;
                }
            }
            else
            {
                string name = "additionalBrakeTest" + additionalBrakeTestNumber;
                Label label = Controls?.Find(name, true)?.FirstOrDefault() as Label;

                int x = this.Width / 2 - label.Width / 2 + label.Width + 2;
                removeBrakeTest.Location = new(x, label.Location.Y);
            }
        }


        #region Interactive

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        private void labelMouseEnter(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.Yellow;
            label_.BackColor = Color.DimGray;
        }

        private void labelMouseLeave(object sender, EventArgs e)
        {
            Label label_ = sender as Label;

            label_.ForeColor = Color.YellowGreen;
            label_.BackColor = SystemColors.InfoText;
        }

        private void brakeTest_Click(object sender, EventArgs e)
        {
            isMainTestBrakeAdded = true;
            brakeTest.Visible = false;

            LoadSuitableBrakeTests();
            int x = this.Width / 2 - brakeTestSelect.Width / 2;
            brakeTestSelect.Location = new Point(x, 70);
            brakeTestSelect.Visible = true;
            brakeTestSelect.DroppedDown = true;
        }

        private void brakeTestSelect_DropDownClosed(object sender, EventArgs e)
        {
            BrakeTest test = (BrakeTest)brakeTestSelect.SelectedItem;

            string text = String.Empty;
            if (tripForm.doubleTrain.Checked)
            {
                text = $"({test.RequiredSpeedForDoubleTrain.Trim()} км/ч) " +
                $"{test.RailwayLine.Trim()} <{test.PointForDoubleTrain.Trim()}>";
            }
            else
            {
                text = $"({test.RequiredSpeed.Trim()} км/ч) " +
                $"{test.RailwayLine.Trim()} <{test.Point.Trim()}>";
            }

            if (isMainTestBrakeAdded)
            {
                brakeTest.Text = text;
                int x = this.Width / 2 - brakeTest.Width / 2;
                brakeTest.Location = new Point(x, 70);
                brakeTest.Visible = true;
                SetBrakeTestRemoveButton();
            }
            else
            {
                additionalBrakeTestNumber++;
                if (additionalBrakeTestNumber > 6) additionalBrakeTestNumber = 6;

                string labelName = "additionalBrakeTest" + additionalBrakeTestNumber;
                Label label = Controls?.Find(labelName, true)?.FirstOrDefault() as Label;

                if (label != null)
                {
                    label.Visible = true;
                    label.Text = text;
                    int x = this.Width / 2 - label.Width / 2;
                    label.Location = new Point(x, label.Location.Y);
                    label.ForeColor = Color.Goldenrod;

                    SetBrakeTestRemoveButton();
                }
            }

            brakeTestSelect.Visible = false;
            removeBrakeTest.Visible = true;
            string nextLabelName = "additionalBrakeTest" + (additionalBrakeTestNumber + 1);
            Label nextLabel = Controls?.Find(nextLabelName, true)?.FirstOrDefault() as Label;
            if (nextLabel != null) nextLabel.Visible = true;
        }

        private void addBrakeTestClick(object sender, EventArgs e)
        {
            ClickAdditionalBrakeTest(sender);
        }

        private void removeBrakeTest_MouseEnter(object sender, EventArgs e)
        {
            removeBrakeTest.ForeColor = Color.LightCoral;
            removeBrakeTest.BorderStyle = BorderStyle.FixedSingle;
        }

        private void removeBrakeTest_MouseLeave(object sender, EventArgs e)
        {
            removeBrakeTest.ForeColor = Color.Red;
            removeBrakeTest.BorderStyle = BorderStyle.None;
        }

        private void removeBrakeTest_Click(object sender, EventArgs e)
        {
            if (additionalBrakeTestNumber == 0)
            {
                brakeTest.Text = "Добавить основную пробу тормозов";
                int x = this.Width / 2 - brakeTest.Width / 2;
                brakeTest.Location = new(x, brakeTest.Location.Y);
                removeBrakeTest.Visible = false;
                additionalBrakeTest1.Visible = false;
            }
            else
            {
                string name = "additionalBrakeTest" + additionalBrakeTestNumber;
                Label label = Controls?.Find(name, true)?.FirstOrDefault() as Label;

                label.Text = "Добавить дополнительную пробу тормозов";
                int x = this.Width / 2 - label.Width / 2;
                label.Location = new(x, label.Location.Y);
                label.ForeColor = Color.Yellow;

                if (additionalBrakeTestNumber < 6)
                {
                    name = "additionalBrakeTest" + (additionalBrakeTestNumber + 1);
                    label = Controls?.Find(name, true)?.FirstOrDefault() as Label;
                    label.Visible = false;
                }

                --additionalBrakeTestNumber;
                SetBrakeTestRemoveButton();
            }
        }

        private void addBrakeTests_Click(object sender, EventArgs e)
        {
            tripForm.brakeTests.Clear();

            if (!brakeTest.Text.StartsWith("Добавить"))
                tripForm.brakeTests.Add(brakeTest.Text);

            if (additionalBrakeTestNumber != 0)
            {
                string name = "additionalBrakeTest";

                for (int i = 0; i < additionalBrakeTestNumber; i++)
                {
                    Label label = Controls?.Find(name + (i + 1), true).FirstOrDefault() as Label;
                    tripForm.brakeTests.Add(label.Text);
                }
            }

            tripForm.Enabled = true;
            Close();
            Dispose();
        }

        #endregion
    }
}
