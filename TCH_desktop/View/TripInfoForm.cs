using System.Data;
using System.Data.SqlClient;
using TCH_desktop.Models;

namespace TCH_desktop.View
{
    public partial class TripInfoForm : Form
    {
        private AllTripsForm allTripsForm;
        private int tripId;

        private bool isFinalForm;
        private bool isGrowingInWidth;
        private bool isGrowingInHeight;

        private System.Windows.Forms.Timer timer;


        public TripInfoForm(AllTripsForm allTripsForm, int tripId)
        {
            InitializeComponent();

            this.allTripsForm = allTripsForm;
            this.tripId = tripId;

            this.Controls.Clear();
            this.Width = 0;
            this.Height = 1;

            isFinalForm = false;
            isGrowingInWidth = true;
            isGrowingInHeight = false;

            timer = new System.Windows.Forms.Timer { Interval = 10 };
            timer.Tick += TimerTick;
        }

        private void DisplayInfo()
        {
            Trip trip = GetTripData();
            Locomotive loco = GetLocomotiveData(trip.Locomotive);
            string locoType = GetLocoType(loco.LocoType);
            string locoSeries = GetLocoSeries(loco.Series);

            GroupBox groupBox = new GroupBox();
            groupBox.Text = $" Поездка \"{trip.TrafficRoute}\" от {trip.AttendanceTime.ToString("D")}";
            groupBox.Font = new ("Courier New", 14.0F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox.ForeColor = Color.Orange;
            groupBox.Location = new(13, 23);
            groupBox.Size = new(1274, 767);
            groupBox.Click += CloseForm;

            Label attendanceTime = new Label();
            attendanceTime.AutoSize = true;
            attendanceTime.ForeColor = Color.LightSkyBlue;
            attendanceTime.Text = $"Время явки: {trip.AttendanceTime:t}";
            attendanceTime.Location = new(22, 66);
            groupBox.Controls.Add(attendanceTime);

            Label locomotive = new Label();
            locomotive.AutoSize = true;
            locomotive.ForeColor = Color.LightSkyBlue;
            locomotive.Text = locoType + ' ' + locoSeries + $"-{loco.Number} ({loco.Allocation})";
            locomotive.Location = new(22, 103);
            groupBox.Controls.Add(locomotive);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new(378, 288);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Location = new(857, 46);
            string defaultPath = Environment.CurrentDirectory + @"\source\images\addLocoImg.png";
            pictureBox.Image = loco.ImagePath == String.Empty ?
                new Bitmap(defaultPath) : new Bitmap(loco.ImagePath);
            groupBox.Controls.Add(pictureBox);


            this.Controls.Add(groupBox);
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            if (!isFinalForm)
            {
                if (isGrowingInWidth)
                {
                    this.Width += 40;
                    this.Location = new Point(this.Location.X - 23, this.Location.Y);
                    if (this.Width >= 1300)
                    {
                        this.Width = 1300;
                        isGrowingInWidth = false;
                        isGrowingInHeight = true;
                    }
                }

                if (isGrowingInHeight)
                {
                    this.Height += 40;
                    this.Location = new Point(this.Location.X, this.Location.Y - 21);
                    if (this.Height >= 800)
                    {
                        this.Height = 800;
                        isFinalForm = true;
                    }
                }
            }
            else
            {
                timer.Stop();
                DisplayInfo();
            }
        }

        private void TripInfoForn_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void CloseForm(object? sender, EventArgs e)
        {
            allTripsForm.Enabled = true;
            Close();
            Dispose();
        }

        private Trip GetTripData()
        {
            Trip trip = null;
            string query = "SELECT * FROM Trips WHERE Id=@tripId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@tripId", SqlDbType.Int).Value = tripId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    trip = new Trip
                    {
                        Id = reader.GetInt32(0),
                        AttendanceTime = reader.GetDateTime(1),
                        Locomotive = reader.GetInt32(2),
                        TrafficRoute = reader.GetString(3),
                        ElectricityFactor = reader.IsDBNull(4) ? 0.0f : reader.GetFloat(4),
                        Departure = reader.GetString(5),
                        Arrival = reader.GetString(6),
                        PassedStations = reader.IsDBNull(7) ? "" : reader.GetString(7),
                        SpeedLimits = reader.IsDBNull(8) ? "" : reader.GetString(8),
                        ElectricityAmountRequired = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        ElectricityRecoveryRequired = reader.IsDBNull(10) ? 0.0f : reader.GetFloat(10),
                        TechnicalSpeed = reader.IsDBNull(11) ? 0.0f : reader.GetFloat(11),
                        Notes = reader.IsDBNull(12) ? "" : reader.GetString(12),
                        Train = reader.GetInt32(13)
                    };
                }

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные о поездке по ID:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return trip;
        }

        private Locomotive GetLocomotiveData(int locoId)
        {
            Locomotive loco = null;
            string query = "SELECT * FROM Locomotives WHERE Id=@locoId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@locoId", SqlDbType.Int).Value = locoId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    loco = new Locomotive
                    {
                        Id = reader.GetInt32(0),
                        LocoType = reader.GetInt32(1),
                        Series = reader.GetInt32(2),
                        Number = reader.GetInt32(3),
                        Allocation = reader.GetString(4),
                        NumberOfBrakeHolders = reader.GetInt32(5),
                        ImagePath = reader.IsDBNull(6) ? "" : reader.GetString(6)
                    };
                }

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные о локомотиве по ID:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return loco;
        }

        private string GetLocoType(int locoTypeId)
        {
            string result = String.Empty;
            string query = "SELECT LocoType FROM LocomotiveTypes WHERE Id=@locoTypeId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@locoTypeId", SqlDbType.Int).Value = locoTypeId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные о типе локомотива по ID:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return result;
        }

        private string GetLocoSeries(int seriesId)
        {
            string result = String.Empty;
            string query = "SELECT Series FROM LocoSeries WHERE Id=@seriesId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@seriesId", SqlDbType.Int).Value = seriesId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные о серии локомотива по ID:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return result;
        }
    }
}
