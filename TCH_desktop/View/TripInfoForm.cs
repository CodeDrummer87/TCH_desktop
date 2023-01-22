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
            Train train = GetTrainData(trip.Train);
            Queue<string> brakeTests = GetBrakeTests(trip.Id);

            GroupBox tripGroupBox = new GroupBox();
            tripGroupBox.Text = $" Поездка \"{trip.TrafficRoute}\" от {trip.AttendanceTime.ToString("D")}";
            tripGroupBox.Font = new ("Courier New", 14.0F, FontStyle.Bold, GraphicsUnit.Point);
            tripGroupBox.ForeColor = Color.Orange;
            tripGroupBox.Location = new(13, 23);
            tripGroupBox.Size = new(1274, 767);
            tripGroupBox.Click += CloseForm;

            Label attendanceTime = new Label();
            attendanceTime.AutoSize = true;
            attendanceTime.ForeColor = Color.PaleGoldenrod;
            attendanceTime.Font = new ("Courier New", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            attendanceTime.Text = "Время явки:";
            attendanceTime.Location = new(22, 66);
            tripGroupBox.Controls.Add(attendanceTime);

            Label attendanceTimeValue = new Label();
            attendanceTimeValue.AutoSize = true;
            attendanceTimeValue.Font = new ("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            attendanceTimeValue.ForeColor = Color.PaleGreen;
            attendanceTimeValue.Location = new Point(193, 69);
            attendanceTimeValue.Size = new Size(70, 23);
            attendanceTimeValue.Text = $" {trip.AttendanceTime:t}";
            attendanceTimeValue.TextAlign = ContentAlignment.MiddleCenter;
            tripGroupBox.Controls.Add(attendanceTimeValue);

            Label locomotive = new Label();
            locomotive.Font = new ("Courier New", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            locomotive.ForeColor = Color.PaleGreen;
            locomotive.Location = new Point(374, 66);
            locomotive.Size = new Size(860, 27);
            locomotive.Text = locoType + ' ' + locoSeries + $"-{loco.Number} ({loco.Allocation})";
            locomotive.TextAlign = ContentAlignment.MiddleRight;
            tripGroupBox.Controls.Add(locomotive);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new(378, 288);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Location = new(857, 105);
            pictureBox.TabStop = false;
            string defaultPath = Environment.CurrentDirectory + @"\source\images\addLocoImg.png";
            if (loco.ImagePath == String.Empty)
            {
                pictureBox.Image = new Bitmap(defaultPath);
                ApplyLocoPhoto(pictureBox, locoType, locoSeries, loco.Number);
            }
            else
                pictureBox.Image = new Bitmap(loco.ImagePath);
            tripGroupBox.Controls.Add(pictureBox);


            GroupBox electricityGroupBox = new();
            electricityGroupBox.Font = new("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            electricityGroupBox.ForeColor = Color.Chocolate;
            electricityGroupBox.Location = new Point(6, 112);
            electricityGroupBox.Size = new Size(390, 77);
            electricityGroupBox.TabStop = false;
            electricityGroupBox.Text = "Электроэнергия, рекуперация";
            electricityGroupBox.Click += CloseForm;
            tripGroupBox.Controls.Add(electricityGroupBox);

            Label factor = new Label();
            factor.AutoSize = true;
            factor.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            factor.ForeColor = Color.PaleGoldenrod;
            factor.Location = new Point(12, 37);
            factor.Size = new Size(37, 20);
            factor.Text = "K=";
            electricityGroupBox.Controls.Add(factor);

            Label factorValue = new Label();
            factorValue.AutoSize = true;
            factorValue.Font = new("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            factorValue.ForeColor = Color.PaleGreen;
            factorValue.Location = new Point(44, 37);
            factorValue.Size = new Size(34, 23);
            factorValue.Text = trip.ElectricityFactor.ToString();
            factorValue.TextAlign = ContentAlignment.MiddleCenter;
            electricityGroupBox.Controls.Add(factorValue);

            Label electricityAmount = new Label();
            electricityAmount.AutoSize = true;
            electricityAmount.Font = new("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            electricityAmount.ForeColor = Color.PaleGoldenrod;
            electricityAmount.Location = new Point(139, 37);
            electricityAmount.Size = new Size(42, 20);
            electricityAmount.Text = "ЭЭ:";
            electricityGroupBox.Controls.Add(electricityAmount);

            Label electricityAmountValue = new Label();
            electricityAmountValue.AutoSize = true;
            electricityAmountValue.Font = new("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            electricityAmountValue.ForeColor = Color.PaleGreen;
            electricityAmountValue.Location = new Point(187, 37);
            electricityAmountValue.Size = new Size(46, 23);
            electricityAmountValue.Text = trip.ElectricityAmountRequired.ToString();
            electricityAmountValue.TextAlign = ContentAlignment.MiddleCenter;
            electricityGroupBox.Controls.Add(electricityAmountValue);

            Label electricityReovery = new Label();
            electricityReovery.AutoSize = true;
            electricityReovery.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            electricityReovery.ForeColor = Color.PaleGoldenrod;
            electricityReovery.Location = new Point(277, 37);
            electricityReovery.Size = new Size(36, 20);
            electricityReovery.Text = "Р=";
            electricityGroupBox.Controls.Add(electricityReovery);

            Label elRecoveryValue = new Label();
            elRecoveryValue.AutoSize = true;
            elRecoveryValue.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            elRecoveryValue.ForeColor = Color.PaleGreen;
            elRecoveryValue.Location = new Point(309, 37);
            elRecoveryValue.Size = new Size(46, 23);
            elRecoveryValue.Text = trip.ElectricityRecoveryRequired.ToString();
            elRecoveryValue.TextAlign = ContentAlignment.MiddleCenter;
            electricityGroupBox.Controls.Add(elRecoveryValue);


            GroupBox notesGroupBox = new();
            notesGroupBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            notesGroupBox.ForeColor = Color.Chocolate;
            notesGroupBox.Location = new Point(6, 195);
            notesGroupBox.Size = new Size(390, 185);
            notesGroupBox.TabStop = false;
            notesGroupBox.Text = "Заметки";
            tripGroupBox.Controls.Add(notesGroupBox);

            Label notes = new Label();
            notes.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            notes.ForeColor = Color.PaleGreen;
            notes.Location = new Point(6, 24);
            notes.Size = new Size(378, 158);
            notes.Text = trip.Notes;
            notes.TextAlign = ContentAlignment.MiddleCenter;
            notesGroupBox.Controls.Add(notes);


            GroupBox trainGroupBox = new GroupBox();
            trainGroupBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            trainGroupBox.ForeColor = Color.Chocolate;
            trainGroupBox.Location = new Point(402, 112);
            trainGroupBox.Size = new Size(289, 268);
            trainGroupBox.TabStop = false;
            trainGroupBox.Text = "Поезд";
            trainGroupBox.Click += CloseForm;
            tripGroupBox.Controls.Add(trainGroupBox);

            Label trainNumb = new Label();
            trainNumb.AutoSize = true;
            trainNumb.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            trainNumb.ForeColor = Color.PaleGoldenrod;
            trainNumb.Location = new Point(47, 46);
            trainNumb.Size = new Size(104, 20);
            trainNumb.Text = "N поезда:";
            trainGroupBox.Controls.Add(trainNumb);

            Label trainNumbValue = new Label();
            trainNumbValue.AutoSize = true;
            trainNumbValue.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            trainNumbValue.ForeColor = Color.PaleGreen;
            trainNumbValue.Location = new Point(157, 46);
            trainNumbValue.Size = new Size(58, 23);
            trainNumbValue.Text = train.Number;
            trainNumbValue.TextAlign = ContentAlignment.MiddleCenter;
            trainGroupBox.Controls.Add(trainNumbValue);

            Label weight = new Label();
            weight.AutoSize = true;
            weight.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            weight.ForeColor = Color.PaleGoldenrod;
            weight.Location = new Point(77, 83);
            weight.Size = new Size(74, 20);
            weight.Text = "Масса:";
            trainGroupBox.Controls.Add(weight);

            Label weightValue = new Label();
            weightValue.AutoSize = true;
            weightValue.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            weightValue.ForeColor = Color.PaleGreen;
            weightValue.Location = new Point(157, 83);
            weightValue.Size = new Size(58, 23);
            weightValue.Text = train.Weight.ToString();
            weightValue.TextAlign = ContentAlignment.MiddleCenter;
            trainGroupBox.Controls.Add(weightValue);

            Label axles = new Label();
            axles.AutoSize = true;
            axles.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            axles.ForeColor = Color.PaleGoldenrod;
            axles.Location = new Point(99, 119);
            axles.Size = new Size(52, 20);
            axles.Text = "Оси:";
            trainGroupBox.Controls.Add(axles);

            Label axlesValue = new Label();
            axlesValue.AutoSize = true;
            axlesValue.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            axlesValue.ForeColor = Color.PaleGreen;
            axlesValue.Location = new Point(157, 119);
            axlesValue.Size = new Size(46, 23);
            axlesValue.Text = train.Axles.ToString();
            axlesValue.TextAlign = ContentAlignment.MiddleCenter;
            trainGroupBox.Controls.Add(axlesValue);

            Label specLength = new Label();
            specLength.AutoSize = true;
            specLength.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            specLength.ForeColor = Color.PaleGoldenrod;
            specLength.Location = new Point(108, 156);
            specLength.Size = new Size(43, 20);
            specLength.Text = "УД:";
            trainGroupBox.Controls.Add(specLength);

            Label specLengthValue = new Label();
            specLengthValue.AutoSize = true;
            specLengthValue.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            specLengthValue.ForeColor = Color.PaleGreen;
            specLengthValue.Location = new Point(157, 156);
            specLengthValue.Size = new Size(34, 23);
            specLengthValue.Text = train.SpecificLength.ToString();
            specLengthValue.TextAlign = ContentAlignment.MiddleCenter;
            trainGroupBox.Controls.Add(specLengthValue);

            Label tailCar = new Label();
            tailCar.AutoSize = true;
            tailCar.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            tailCar.ForeColor = Color.PaleGoldenrod;
            tailCar.Location = new Point(108, 191);
            tailCar.Size = new Size(42, 20);
            tailCar.Text = "ХВ:";
            trainGroupBox.Controls.Add(tailCar);

            Label tailCarValue = new Label();
            tailCarValue.AutoSize = true;
            tailCarValue.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tailCarValue.ForeColor = Color.PaleGreen;
            tailCarValue.Location = new Point(157, 191);
            tailCarValue.Size = new Size(106, 23);
            tailCarValue.Text = train.TailCar;
            tailCarValue.TextAlign = ContentAlignment.MiddleCenter;
            trainGroupBox.Controls.Add(tailCarValue);

            Label fixation = new Label();
            fixation.AutoSize = true;
            fixation.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            fixation.ForeColor = Color.PaleGoldenrod;
            fixation.Location = new Point(7, 229);
            fixation.Size = new Size(143, 20);
            fixation.Text = "Закрепление:";
            trainGroupBox.Controls.Add(fixation);

            Label fixationValue = new Label();
            fixationValue.AutoSize = true;
            fixationValue.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            fixationValue.ForeColor = Color.PaleGreen;
            fixationValue.Location = new Point(157, 229);
            fixationValue.Size = new Size(118, 23);
            fixationValue.Text = train.TrainFixation;
            fixationValue.TextAlign = ContentAlignment.MiddleCenter;
            trainGroupBox.Controls.Add(fixationValue);


            GroupBox departureGroupBox = new GroupBox();
            departureGroupBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            departureGroupBox.ForeColor = Color.Chocolate;
            departureGroupBox.Location = new Point(697, 112);
            departureGroupBox.Size = new Size(154, 119);
            departureGroupBox.TabStop = false;
            departureGroupBox.Text = "Отправление";
            departureGroupBox.Click += CloseForm;
            tripGroupBox.Controls.Add(departureGroupBox);

            Label departure = new Label();
            departure.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            departure.ForeColor = Color.PaleGreen;
            departure.Location = new Point(6, 24);
            departure.Size = new Size(142, 82);
            departure.Text = trip.Departure;
            departure.TextAlign = ContentAlignment.MiddleCenter;
            departure.Click += CloseForm;
            departureGroupBox.Controls.Add(departure);


            GroupBox arrivalGroupBox = new GroupBox();
            arrivalGroupBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            arrivalGroupBox.ForeColor = Color.Chocolate;
            arrivalGroupBox.Location = new Point(697, 261);
            arrivalGroupBox.Size = new Size(154, 119);
            arrivalGroupBox.TabStop = false;
            arrivalGroupBox.Text = "Прибытие";
            arrivalGroupBox.Click += CloseForm;
            tripGroupBox.Controls.Add(arrivalGroupBox);

            Label arrival = new Label();
            arrival.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            arrival.ForeColor = Color.PaleGreen;
            arrival.Location = new Point(6, 24);
            arrival.Size = new Size(142, 79);
            arrival.Text = trip.Arrival;
            arrival.TextAlign = ContentAlignment.MiddleCenter;
            arrival.Click += CloseForm;
            arrivalGroupBox.Controls.Add(arrival);


            GroupBox brakeTestsGroupBox = new GroupBox();
            brakeTestsGroupBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            brakeTestsGroupBox.ForeColor = Color.Chocolate;
            brakeTestsGroupBox.Location = new Point(13, 411);
            brakeTestsGroupBox.Size = new Size(509, 339);
            brakeTestsGroupBox.TabStop = false;
            brakeTestsGroupBox.Text = "Пробы тормозов в пути следования";
            brakeTestsGroupBox.Click += CloseForm;
            tripGroupBox.Controls.Add(brakeTestsGroupBox);

            if (brakeTests.Count > 0)
            {
                int posY = 0;
                foreach(string data in brakeTests)
                {
                    Label label = new Label();

                    label.Font = new Font("Verdana", 9.2F, FontStyle.Regular, GraphicsUnit.Point);
                    label.ForeColor = Color.LightGoldenrodYellow;
                    label.Location = new Point(5, posY += 40);
                    label.Size = new Size(497, 23);
                    label.Text = data;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Click += CloseForm;

                    brakeTestsGroupBox.Controls.Add(label);
                }
            }


            GroupBox passedStationsGroupBox = new();
            passedStationsGroupBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            passedStationsGroupBox.ForeColor = Color.Chocolate;
            passedStationsGroupBox.Location = new Point(529, 411);
            passedStationsGroupBox.Size = new Size(250, 339);
            passedStationsGroupBox.TabStop = false;
            passedStationsGroupBox.Text = "Проследовали станции";
            passedStationsGroupBox.Click += CloseForm;
            tripGroupBox.Controls.Add(passedStationsGroupBox);

            Label passedStations = new Label();
            passedStations.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passedStations.ForeColor = Color.LightGoldenrodYellow;
            passedStations.Location = new Point(19, 40);
            passedStations.Size = new Size(212, 279);
            passedStations.Text = trip.PassedStations.Replace(";", "\n\n");
            passedStations.TextAlign = ContentAlignment.MiddleCenter;
            passedStations.Click += CloseForm;
            passedStationsGroupBox.Controls.Add(passedStations);


            GroupBox limitsGroupBox = new GroupBox();
            limitsGroupBox.Font = new Font("Verdana", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            limitsGroupBox.ForeColor = Color.Chocolate;
            limitsGroupBox.Location = new Point(785, 411);
            limitsGroupBox.Size = new Size(483, 339);
            limitsGroupBox.TabStop = false;
            limitsGroupBox.Text = "Ограничения";
            limitsGroupBox.Click += CloseForm;
            tripGroupBox.Controls.Add(limitsGroupBox);

            Label limits = new Label();
            limits.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point);
            limits.ForeColor = Color.LightGoldenrodYellow;
            limits.Location = new Point(20, 40);
            limits.Size = new Size(441, 279);
            limits.Text = trip.SpeedLimits.Replace(";", "\n\n");
            limits.TextAlign = ContentAlignment.MiddleCenter;
            limits.Click += CloseForm;
            limitsGroupBox.Controls.Add(limits);


            this.Controls.Add(tripGroupBox);
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

        private void ApplyLocoPhoto(PictureBox pictureBox, string type, string series, int number)
        {
            string path = Environment.CurrentDirectory + @$"\Фотографии\{type}ы\{series}";
            FileInfo image = new(path + $@"\{series}-{number}.jpg");

            if (image.Exists)
            {
                pictureBox.Image = new Bitmap(path + $@"\{series}-{number}.jpg");
            }
            else
            {
                path = Environment.CurrentDirectory + @"\source\images\addLocoImg.png";
                pictureBox.Image = new Bitmap(path);
            }
        }

        private Train GetTrainData(int trainId)
        {
            Train train = null;

            string query = "SELECT * FROM Trains WHERE Id=@trainId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@trainId", SqlDbType.Int).Value = trainId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    train = new Train
                    {
                        Id = reader.GetInt32(0),
                        Number = reader.GetString(1),
                        Weight = reader.GetInt32(2),
                        Axles = reader.GetInt32(3),
                        SpecificLength = reader.GetInt32(4),
                        TailCar = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        TrainFixation = reader.GetString(6)
                    };
                }

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные о поездe по ID:\n\"{ex.Message}\"\n" +
                    $"Обратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return train;
        }

        private Queue<string> GetBrakeTests(int tripId)
        {
            Queue<string> brakeTests = new Queue<string>();
            string query = "SELECT BrakeTest FROM TripsBrakeTests WHERE Trip=@tripId";

            try
            {
                SqlCommand command = new(query, DataBase.GetConnection());
                command.Parameters.Add("@tripId", SqlDbType.Int).Value = tripId;
                DataBase.OpenConnection();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brakeTests.Enqueue(reader.GetString(0));
                }

                reader.Close();
                DataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить список проб тормозов в поездке (ID={tripId}):" +
                    $"\n\"{ex.Message}\"\nОбратитесь к системному администратору для устранения ошибки.",
                    "Ошибка работы Базы Данных", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return brakeTests;
        }
    }
}
