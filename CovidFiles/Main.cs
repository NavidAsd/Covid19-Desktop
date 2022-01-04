using Bunifu.DataViz.WinForms;
using Bunifu.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;


namespace Covid19_data
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        private void Mute()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        private void VolDown()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }
        DataTable countryDataTable = new DataTable();
        DataTable historydatatable = new DataTable();
        clsWorldStat worldStat;
        //datavize
        DataPoint newcasesdataPoint = new DataPoint(BunifuDataViz._type.Bunifu_column);
        DataPoint criticalcasesdataPoint = new DataPoint(BunifuDataViz._type.Bunifu_column);
        DataPoint deathcasesdataPoint = new DataPoint(BunifuDataViz._type.Bunifu_column);
        DataPoint recaveredcasesdataPoint = new DataPoint(BunifuDataViz._type.Bunifu_column);
        string httpFeedback, countryName;
        private void Main_Load(object sender, EventArgs e)
        {

            btnlang.BackColor = Color.FromArgb(45, 45, 48);
            panel2.Location = new Point(7, btndashboard.Location.Y);
            pldash4.Visible = true; pldash5.Visible = true; pldash6.Visible = true; pldash7.Visible = true; dgvmain.Visible = true; btncountry.Visible = true;
            plstting1.Visible = false; plsetting3.Visible = false; plseeting4.Visible = false; plsetting2.Visible = false;
            pldash2.Location = new Point(912, 365);
            pldash3.Location = new Point(1117, 365);
            pldash1.Location = new Point(708, 558);
            plsetting5.Location = new Point(1996, 996);
            //
            toast1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            bunifuLabel7.Visible = false;


        }
        private void Pershian()
        {
            lblweek.Text = "هفته براساس";
            lblmonth.Text = "ماه براساس";
            lblactivecases.Text = "فعال موارد";
            lblcritical.Text = "بحرانی موارد";
            lblcriticalcases.Text = "بحرانی موارد";
            lbldeathc.Text = "مرگ";
            lbldeathcases.Text = "مرگ";
            lblfreesoftware.Text = " شهریور در شده نوشته رایگان نرم افزار2020 ";
            lblchangelang.Text = "کلیک با فقط یک زبان تغییر";
            lblvlume.Text = "صدا";
            lblinformationss.Text = "ما با ارتباط";
            lblmind.Text = "کرده تغییری شما نظر ایا؟";
            lblmoredetails.Text = "بیشتر جزئیات..";
            lblnewc.Text = "جدید موارد";
            lblnullcombo.Text = "باشد خالی نمتواند ورودی متن";
            lbloptionss.Text = "امکانات";
            lblproblemload.Text = "اطلاعات بارگذاری در مشکلی ):";
            lblrates.Text = "امتیاز";
            lblrecoveredc.Text = "یافته بهبود موارد";
            lblselectedcountry.Text = "شده انتخاب کشور";
            lblSetting.Text = "تنظیمات";
            lblsevendayhistory.Text = "گذشته روز هفت های داده";
            lblsource.Text = "پدیا ویکی اطلاعات منبع";
            lblthanksrate.Text = "کردید اهدا ستاره ما به که ممنونیم شما از";
            lbltotalcases.Text = " موارد همه";
            lbltotaldeath.Text = "مرگ";
            lblTotalrecovered.Text = "یافته بهبود موارد همه";
            lblusemask.Text = "کنید استفاده ماسک از لطفا";
            lblwekendly.Text = "هفتگی";
            lblworldstat.Text = "جهانی آمار";
            lblcountryname00.Text = "کشور اسم";
            btnrating.Text = "امتیاز";
            btncolor.Text = "رنگ";
            btnlang.Text = "زبان";
            btnaudio.Text = "صدا";
            btnrefresh.ButtonText = "تازه سازی";
            btncountry.ButtonText = "انتخاب کشور";
            lblaudios.Text = "صدا تنظیمات";
            lbllangs.Text = "زبان تنظیمات";
            lblcolors.Text = "رنگ تنظیمات";
            bunifuLabel7.Text = "کنید انتخاب را کشوری  لطفا";
        }
        private void English()
        {
            lblweek.Text = "post one week";
            lblmonth.Text = "post one month";
            lblactivecases.Text = "Active cases";
            lblcritical.Text = "Critical cases";
            lblcriticalcases.Text = "Critical cases";
            lbldeathc.Text = "Death cases";
            lbldeathcases.Text = "Death cases";
            lblfreesoftware.Text = " Free software made in September 2020 ";
            lblchangelang.Text = "Change language with just one click";
            lblvlume.Text = "Vloume";
            lblinformationss.Text = "Contact Us";
            lblmind.Text = "Did you change your mind?";
            lblmoredetails.Text = "more details..";
            lblnewc.Text = "new cases";
            lblnullcombo.Text = "text box cannot be null";
            lbloptionss.Text = "Options";
            lblproblemload.Text = "problem in Loading data ):";
            lblrates.Text = "Rate Us";
            lblrecoveredc.Text = "Recovered cases";
            lblselectedcountry.Text = "Selected Country";
            lblSetting.Text = "Setting";
            lblsevendayhistory.Text = "Seven-day history data";
            lblsource.Text = "Wikipedia information source";
            lblthanksrate.Text = "Thank you for giving us a star !";
            lbltotalcases.Text = " Total cases";
            lbltotaldeath.Text = "Total Death";
            lblTotalrecovered.Text = "Total Recovered";
            lblusemask.Text = "Please use a mask ):";
            lblwekendly.Text = "Weekendly";
            lblworldstat.Text = "Worldwide Statistics";
            lblcountryname00.Text = "Country Name: ";
            btnrating.Text = "Rating";
            btncolor.Text = "Color";
            btnlang.Text = "Language";
            btnaudio.Text = "Audio";
            btnrefresh.ButtonText = "Refresh Data";
            btncountry.ButtonText = "choose country";
            lblaudios.Text = "Audio Setting";
            lbllangs.Text = "Language Setting";
            lblcolors.Text = "Color Setting";
            bunifuLabel7.Text = "Please Select a Country";
            lblhealth.Text = "Health items";
            lblh1.Text = "Constant washing of hands and face";
            lblh2.Text = "Accompanying disinfectant solutions";
            lblh3.Text = "Stay at home";
            lblh4.Text = "Use a mask";
            lblh5.Text = "Stay away from the infected person";
            lblh6.Text = "Follow health advice";
            lblh7.Text = "See your doctor if you have symptoms";
        }
        private void Espanish()
        {
            lblweek.Text = "publicar una semana";
            lblmonth.Text = "publicar un mes";
            lblactivecases.Text = "Casos activos";
            lblcritical.Text = "Casos críticos";
            lblcriticalcases.Text = "Casos críticos";
            lbldeathc.Text = "Casos de muerte";
            lbldeathcases.Text = "Casos de muerte";
            lblfreesoftware.Text = " Software gratuito creado en septiembre de 2020 ";
            lblchangelang.Text = "Cambie de idioma con un solo clic";
            lblvlume.Text = "Volumen";
            lblinformationss.Text = "Contacta con nosotros/as";
            lblmind.Text = "¿Cambiaste de opinión?";
            lblmoredetails.Text = "más detalles..";
            lblnewc.Text = "nuevos casos";
            lblnullcombo.Text = "el cuadro de texto no puede ser nulo";
            lbloptionss.Text = "Opciones";
            lblproblemload.Text = "problema en la carga de datos ):";
            lblrates.Text = "Nos califica";
            lblrecoveredc.Text = "Casos recuperados";
            lblselectedcountry.Text = "País seleccionado";
            lblSetting.Text = "Ajuste";
            lblsevendayhistory.Text = "Datos históricos de siete días";
            lblsource.Text = "Fuente de información de Wikipedia";
            lblthanksrate.Text = "Gracias por darnos una estrella !";
            lbltotalcases.Text = " Casos totales";
            lbltotaldeath.Text = "Muerte total";
            lblTotalrecovered.Text = "Total recuperado/a";
            lblusemask.Text = "Por favor use una mascarilla ):";
            lblwekendly.Text = "Fin de semana";
            lblworldstat.Text = "Estadísticas mundiales";
            lblcountryname00.Text = "Nombre del país: ";
            btnrating.Text = "Clasificación";
            btncolor.Text = "Color";
            btnlang.Text = "Idioma";
            btnaudio.Text = "Audio";
            btnrefresh.ButtonText = "Actualizar datos";
            btncountry.ButtonText = "elige país";
            lblaudios.Text = "Configuracion de audio";
            lbllangs.Text = "Configuración de idioma";
            lblcolors.Text = "Ajuste de color";
            lblhealth.Text = "Artículos de salud";
            lblh1.Text = "Lavado constante de manos y rostro.";
            lblh2.Text = "Soluciones desinfectantes acompañantes";
            lblh3.Text = "Quédate en casa";
            lblh4.Text = "Usa una mascarilla";
            lblh5.Text = "Manténgase alejado de la persona infectada";
            lblh6.Text = "Siga los consejos de salud";
            lblh7.Text = "Consulte a su médico si tiene síntomas";
        }
        private void France()
        {
            lblweek.Text = "poster une semaine";
            lblmonth.Text = "poster un mois";
            lblactivecases.Text = "Cas actifs";
            lblcritical.Text = "Cas critiques";
            lblcriticalcases.Text = "Cas critiques";
            lbldeathc.Text = "Cas de décès";
            lbldeathcases.Text = "Cas de décès";
            lblfreesoftware.Text = " Logiciel gratuit réalisé en septembre 2020 ";
            lblchangelang.Text = "Changez de langue en un seul clic";
            lblvlume.Text = "Le volume";
            lblinformationss.Text = "Nous contacter";
            lblmind.Text = "As-tu changé d'avis?";
            lblmoredetails.Text = "plus de détails..";
            lblnewc.Text = "nouveaux cas";
            lblnullcombo.Text = "la zone de texte ne peut pas être nulle";
            lbloptionss.Text = "Options";
            lblproblemload.Text = "problème de chargement des données ):";
            lblrates.Text = "Évaluez nous";
            lblrecoveredc.Text = "Cas récupérés";
            lblselectedcountry.Text = "Pays sélectionné";
            lblSetting.Text = "Réglage";
            lblsevendayhistory.Text = "Données d'historique de sept jours";
            lblsource.Text = "Source d'information Wikipedia";
            lblthanksrate.Text = "Merci de nous avoir accordé une étoile !";
            lbltotalcases.Text = " Total des cas";
            lbltotaldeath.Text = "Mort totale";
            lblTotalrecovered.Text = "Total récupéré";
            lblusemask.Text = "Veuillez utiliser un masque ):";
            lblwekendly.Text = "Le week-end";
            lblworldstat.Text = "Statistiques mondiales";
            lblcountryname00.Text = "Nom du pays: ";
            btnrating.Text = "Évaluation";
            btncolor.Text = "Couleur";
            btnlang.Text = "Langue";
            btnaudio.Text = "l'audio";
            btnrefresh.ButtonText = "Actualiser les données";
            btncountry.ButtonText = "choisissez un pays";
            lblaudios.Text = "Réglage audio";
            lbllangs.Text = "Paramètres de langue";
            lblcolors.Text = "Réglage de la couleur";
            bunifuLabel7.Text = "Veuillez sélectionner un pays";
            lblhealth.Text = "Articles de santé";
            lblh1.Text = "Lavage constant des mains et du visage";
            lblh2.Text = "Accompagnement des solutions désinfectantes";
            lblh3.Text = "Reste à la maison";
            lblh4.Text = "Utilisez un masque";
            lblh5.Text = "Éloignez-vous de la personne infectée";
            lblh6.Text = "Suivez les conseils de santé";
            lblh7.Text = "Consultez votre médecin si vous présentez des symptômes";
        }
        private void German()
        {
            lblweek.Text = "poste eine Woche";
            lblmonth.Text = "poste einen Monat";
            lblactivecases.Text = "Aktuelle Fälle";
            lblcritical.Text = "Kritische Fälle";
            lblcriticalcases.Text = "Kritische Fälle";
            lbldeathc.Text = "Todesfälle";
            lbldeathcases.Text = "Todesfälle";
            lblfreesoftware.Text = " Freie Software hergestellt im September 2020 ";
            lblchangelang.Text = "Ändern Sie die Sprache mit nur einem Klick";
            lblvlume.Text = "Volumen";
            lblinformationss.Text = "Kontaktiere uns";
            lblmind.Text = "Hast du deine Meinung geändert?";
            lblmoredetails.Text = "mehr Details..";
            lblnewc.Text = "neue Fälle";
            lblnullcombo.Text = "Textfeld darf nicht null sein";
            lbloptionss.Text = "Optionen";
            lblproblemload.Text = "Problem beim Laden von Daten ):";
            lblrates.Text = "Bewerten Sie uns";
            lblrecoveredc.Text = "Wiederhergestellte Fälle";
            lblselectedcountry.Text = "Ausgewähltes Land";
            lblSetting.Text = "Rahmen";
            lblsevendayhistory.Text = "Sieben-Tage-Verlaufsdaten";
            lblsource.Text = "Wikipedia-Informationsquelle";
            lblthanksrate.Text = "Danke, dass Sie uns einen Stern gegeben haben !";
            lbltotalcases.Text = " Fälle insgesamt";
            lbltotaldeath.Text = "Totaler Tod";
            lblTotalrecovered.Text = "Insgesamt wiederhergestellt";
            lblusemask.Text = "Bitte benutzen Sie eine Maske ):";
            lblwekendly.Text = "Wochenend";
            lblworldstat.Text = "Weltweite Statistik";
            lblcountryname00.Text = "Ländername: ";
            btnrating.Text = "Bewertung";
            btncolor.Text = "Farbe";
            btnlang.Text = "Sprache";
            btnaudio.Text = "Audio";
            btnrefresh.ButtonText = "Daten aktualisieren";
            btncountry.ButtonText = "Land auswählen";
            lblaudios.Text = "Audioeinstellung";
            lbllangs.Text = "Spracheinstellungen";
            lblcolors.Text = "Farbeinstellung";
            bunifuLabel7.Text = "Bitte wähle ein Land";
            lblhealth.Text = "Gesundheitsartikel";
            lblh1.Text = "Ständiges Waschen von Händen und Gesicht";
            lblh2.Text = "Begleitende Desinfektionslösungen";
            lblh3.Text = "Bleib zuhause";
            lblh4.Text = "Verwenden Sie eine Maske";
            lblh5.Text = "Halten Sie sich von der infizierten Person fern";
            lblh6.Text = "Befolgen Sie die Gesundheitsempfehlungen";
            lblh7.Text = "Wenden Sie sich an Ihren Arzt, wenn Sie Symptome haben";
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(7, btndashboard.Location.Y);
             pldash5.Visible = true; pldash6.Visible = true; pldash7.Visible = true; dgvmain.Visible = true; btncountry.Visible = true;
            plstting1.Visible = false; plsetting3.Visible = false; plseeting4.Visible = false; plsetting2.Visible = false;
            pldash2.Location = new Point(912, 365);
            pldash3.Location = new Point(1117, 365);
            pldash1.Location = new Point(708, 558);
            plsetting5.Location = new Point(1996, 996);
            pldash4.Location = new Point(1, 52);
            pldash6.Location = new Point(88, 52);
            lblcovid19.Text = "Covid19 Analysis";
            Timersettingpage.Enabled = false;
            Timercolor.Enabled = false;
            plinfo.Visible = false;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(7, btnshurtcut.Location.Y);

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            panel2.Location = new Point(7, btnrealtime.Location.Y);
            System.Diagnostics.Process.Start(@"https://coronavirus-monitor.com/");
        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void btncountry_Click(object sender, EventArgs e)
        {
            Timersettingpage.Enabled = false;
            Timercolor.Enabled = false;
            Frmcountry sho = new Frmcountry();
            sho.countryData = countryDataTable;
            sho.Location = new Point(mysearch.Location.X, mysearch.Location.Y + 113);
            sho.ShowDialog();
            if (sho.result == DialogResult.OK)
            {
                lblcountryshow.Text = sho.country0;
                countryName = sho.country0;
                lblselectcountry.Text = sho.country0;
                toast1.Visible = true;
                if (historydatatable.Columns.Count > 0)
                {
                    historydatatable.Columns.Clear();
                }
                if (historydatatable.Rows.Count > 0)
                {
                    historydatatable.Rows.Clear();
                }
                dgvmain.DataSource = null;
                //clear datapoints
                newcasesdataPoint.clear();
                recaveredcasesdataPoint.clear();
                deathcasesdataPoint.clear(); criticalcasesdataPoint.clear();
                bunifuDataViz1.Visible = false;
                backgroundWorker1.RunWorkerAsync();

            }
            if (string.IsNullOrEmpty(countryName) && btnretry.Visible == false && toast1.Visible == false)
            {
                bunifuLabel7.Visible = true;
            }
            else
            {
                bunifuLabel7.Visible = false;

            }

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {


            if (backgroundWorker1.CancellationPending)

            {
                backgroundWorker1.RunWorkerAsync();
            }

            if (string.IsNullOrEmpty(countryName) && btnretry.Visible == false && toast1.Visible == false)
            {
                bunifuLabel7.Visible = true;
            }
            else
            {
                bunifuLabel7.Visible = false;

            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        bool getcountry = false;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            if (!string.IsNullOrEmpty(countryName))
            {
                GetCountryCovid19History(countryName);
            }
            if (getcountry == false)
            {
                GetAllCountries();
                getcountry = true;
            }
            GetWorldStat();


            if (backgroundWorker1.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
            lblDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            panel2.Location = new Point(7, btnsetting.Location.Y);
             pldash5.Visible = false;  pldash7.Visible = false; dgvmain.Visible = false; btncountry.Visible = false;
            plstting1.Visible = true; plsetting3.Visible = true; plseeting4.Visible = true; plsetting2.Visible = true;
            pldash2.Location = new Point(1999, 999);
            pldash3.Location = new Point(1998, 998);
            pldash1.Location = new Point(1899, 989);
            pldash6.Location = new Point(2000, 1500);
            plsetting5.Location = new Point(88, 559);
           // pldash4.Location = new Point(1995,991);
            lblcovid19.Text = "Setting";
            Timersettingpage.Enabled = true;
            plinfo.Visible = false;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                MessageBox.Show(httpFeedback);
                this.Invoke(new Action(() =>
                {
                    bunifuLabel7.Visible = false;
                    toast1.Visible = false;
                    btnretry.Visible = true;
                    lblproblemload.Visible = true;
                    lblmoredetails.Visible = true;
                    btncountry.Enabled = false;
                    lblac1.Text = "--";
                    lbltc1.Text = "--";
                    lblac2.Text = "--";
                    lblac3.Text = "--";
                    lbltc3.Text = "--";
                    lbltc2.Text = "--";
                    bunifuCircleProgressbar1.Value = 0;
                    bunifuCircleProgressbar2.Value = 0;
                    bunifuGauge1.Value = 0;
                    Music.Enabled = true;
                }));

            }
            else
            {
                //MessageBox.Show("data loaded...");
                this.Invoke(new Action(() =>
                {

                    Music.Enabled = true;



                    lblac1.Text = "--";
                    lbltc1.Text = "--";
                    lblac2.Text = "--";
                    lblac3.Text = "--";
                    lbltc3.Text = "--";
                    lbltc2.Text = "--";

                    if (historydatatable.Rows.Count > 0)
                    {

                        dgvmain.DataSource = historydatatable;
                        //expend first columns
                        dgvmain.Columns[0].Width = 110;
                        bunifuDataViz1.Visible = true;
                        //write lable text 
                        lblac1.Text = historydatatable.Rows[0]["active_cases"].ToString();
                        lbltc1.Text = historydatatable.Rows[0]["total_cases"].ToString();
                        lblac2.Text = historydatatable.Rows[0]["critical_cases"].ToString();
                        lblac3.Text = historydatatable.Rows[0]["total_deaths"].ToString();
                        lbltc3.Text = historydatatable.Rows[0]["total_cases"].ToString();
                        lbltc2.Text = historydatatable.Rows[0]["total_cases"].ToString();

                        #region zero lbls for safe in error
                        if (string.IsNullOrEmpty(lblac1.Text))
                        {
                            lblac1.Text = "0";
                        }
                        if (string.IsNullOrEmpty(lbltc1.Text))
                        {
                            lbltc1.Text = "0";
                        }
                        if (string.IsNullOrEmpty(lblac2.Text))
                        {
                            lblac2.Text = "0";
                        }
                        if (string.IsNullOrEmpty(lblac3.Text))
                        {
                            lblac3.Text = "0";
                        }
                        if (string.IsNullOrEmpty(lbltc3.Text))
                        {
                            lbltc3.Text = "0";
                        }
                        if (string.IsNullOrEmpty(lbltc2.Text))
                        {
                            lbltc2.Text = "0";
                        }
                        #endregion
                        //cirecle progress run and fixed
                        int activecasesNumber = int.Parse(lblac1.Text, System.Globalization.NumberStyles.AllowThousands);
                        int criticalcasesNumber = int.Parse(lblac2.Text, System.Globalization.NumberStyles.AllowThousands);
                        int deathscasesNumber = int.Parse(lblac3.Text, System.Globalization.NumberStyles.AllowThousands);
                        int totalcasesNumber = int.Parse(lbltc2.Text, System.Globalization.NumberStyles.AllowThousands);

                        int activeCasesPercentage = (100 * activecasesNumber) / totalcasesNumber;
                        int criticalCasesPercentage = (100 * criticalcasesNumber) / totalcasesNumber;
                        int deathsCasesPercentage = (100 * deathscasesNumber) / totalcasesNumber;

                        //set values in progreses
                        bunifuCircleProgressbar1.Value = activeCasesPercentage;
                        bunifuCircleProgressbar2.Value = deathsCasesPercentage;
                        bunifuGauge1.Value = criticalCasesPercentage;

                        //add datapoints to canvas
                        Canvas statisticsCanvas = new Canvas();
                        statisticsCanvas.addData(newcasesdataPoint);
                        statisticsCanvas.addData(criticalcasesdataPoint);
                        statisticsCanvas.addData(recaveredcasesdataPoint);
                        statisticsCanvas.addData(deathcasesdataPoint);
                        //set colors in dataviz 
                        bunifuDataViz1.colorSet.Add(Color.FromArgb(159, 134, 255));
                        bunifuDataViz1.colorSet.Add(Color.FromArgb(0, 122, 255));
                        bunifuDataViz1.colorSet.Add(Color.FromArgb(243, 249, 210));
                        bunifuDataViz1.colorSet.Add(Color.FromArgb(44, 43, 60));
                        //render canvas to dataviz
                        bunifuDataViz1.Render(statisticsCanvas);
                    }

                    btncountry.Enabled = true;
                    btnretry.Visible = false;
                    lblproblemload.Visible = false;
                    lblmoredetails.Visible = false;
                    toast1.Visible = false;

                    //set worldstat in labels
                    lblworldtotal.Text = worldStat.total_cases;
                    lblworldrecovered.Text = worldStat.total_recovered;
                    lblworlddeah.Text = worldStat.total_death;
                    if (string.IsNullOrEmpty(countryName) && btnretry.Visible == false && toast1.Visible == false)
                    {
                        bunifuLabel7.Visible = true;
                    }
                    else
                    {
                        bunifuLabel7.Visible = false;

                    }
                }));


            }
        }
        private void btncountry_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnretry_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void bunifuLabel29_Click(object sender, EventArgs e)
        {
            Frmdetail open = new Frmdetail();
            open.ShowDialog();
        }

        private void lblac2_Click(object sender, EventArgs e)
        {

        }
        //Api Methodes
        private void GetAllCountries()
        {
            var client = new RestClient("https://restcountries-v1.p.rapidapi.com/all");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "restcountries-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "9c11d404f5msh334423c9c7ef75fp1e312cjsn4325ef1041dd");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content;
                var countries = JsonConvert.DeserializeObject<List<Country>>(content);
                //add data
                countryDataTable.Columns.Add("Name");
                foreach (var country in countries)
                {
                    countryDataTable.Rows.Add(country.name);
                }

            }
            else
            {
                httpFeedback = response.ErrorMessage;
                backgroundWorker1.CancelAsync();
            }
        }

        private void btnsuport_Click(object sender, EventArgs e)
        {
            Frmsuport open = new Frmsuport();
            open.ShowDialog();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Timercolor.Enabled = true;
            btncolor.BackColor = Color.FromArgb(45, 45, 48);
            btnrating.BackColor = Color.FromArgb(24, 26, 36);
            btnaudio.BackColor = Color.FromArgb(24, 26, 36);
            btnlang.BackColor = Color.FromArgb(24, 26, 36);
            plcolor.BackColor = Color.FromArgb(24, 26, 36);
            plaudio.BackColor = Color.FromArgb(28, 28, 28);
            pllang.BackColor = Color.FromArgb(28, 28, 28);
            plcolor.Enabled = true;
            pllang.Enabled = false;
            plaudio.Enabled = false;
        }

        private void swfarsi_Click(object sender, EventArgs e)
        {
            if (swfarsi.Value == true)
            {
                Pershian();
                swenglish.Value = false; swarab.Value = false; swrus.Value = false; swgerman.Value = false;
            }
            else
            {
                swfarsi.Value = true;
            }
        }

        private void swenglish_Click(object sender, EventArgs e)
        {
            if (swenglish.Value == true)
            {
                English();
                swfarsi.Value = false; swarab.Value = false; swrus.Value = false; swgerman.Value = false;
            }
            else
            {
                swenglish.Value = true;
            }
        }

        private void swarab_Click(object sender, EventArgs e)
        {
            if (swarab.Value == true)
            {
                Espanish();
                swenglish.Value = false; swfarsi.Value = false; swrus.Value = false; swgerman.Value = false;
            }
            else
            {
                swarab.Value = true;
            }
        }

        private void swrus_Click(object sender, EventArgs e)
        {
            if (swrus.Value == true)
            {
                France();

                swenglish.Value = false; swarab.Value = false; swfarsi.Value = false; swgerman.Value = false;
            }
            else
            {
                swrus.Value = true;
            }
        }

        private void swgerman_Click(object sender, EventArgs e)
        {
            if (swgerman.Value == true)
            {
                German();
                swenglish.Value = false; swarab.Value = false; swrus.Value = false; swfarsi.Value = false;
            }
            else
            {
                swgerman.Value = true;
            }
        }

        private void GetCountryCovid19History(string country)
        {
            var client = new RestClient($"https://coronavirus-monitor.p.rapidapi.com/coronavirus/cases_by_particular_country.php?country={country}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "coronavirus-monitor.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "9c11d404f5msh334423c9c7ef75fp1e312cjsn4325ef1041dd");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content;
                var historydata = JsonConvert.DeserializeObject<clsHistory_state>(content);
                if (historydata != null)
                {
                    //add data
                    DataColumn[] datacolumns = new DataColumn[]
                    {
                        new DataColumn("record_date"),
                        new DataColumn("total_cases"),
                        new DataColumn("new_cases"),
                        new DataColumn("active_cases"),
                        new DataColumn("total_deaths"),
                        new DataColumn("totall_recovered"),
                        new DataColumn("critical_cases"),

                    };
                    //add columns
                    historydatatable.Columns.AddRange(datacolumns);
                    //reverse the list
                    historydata.stat_by_country.Reverse();
                    //get last 7dates from today
                    DateTime[] last_seven_days = Enumerable.Range(0, 7).Select(i => DateTime.Now.Date.AddDays(-i)).ToArray();
                    //creating dictionary for dataviz
                    Dictionary<string, int> newCasesDictionary = new Dictionary<string, int>();
                    Dictionary<string, int> criticalCasesDictionary = new Dictionary<string, int>();
                    Dictionary<string, int> deathCasesDictionary = new Dictionary<string, int>();
                    Dictionary<string, int> recaveredCasesDictionaryt = new Dictionary<string, int>();
                    foreach (var day in last_seven_days)
                    {
                        foreach (var data in historydata.stat_by_country)
                        {

                            if (data.record_date.Contains($"{day:yyyy-MM-dd}"))
                            {
                                DateTime datetime = new DateTime(day.Date.Year, day.Date.Month, day.Date.Day);
                                historydatatable.Rows.Add($"{day:dd-MM-yyyy}" + "" + datetime.ToString("ddd"), data.total_cases, data.new_cases, data.active_cases, data.total_death, data.total_recovered, data.serious_critical);
                                //add data TO Dictionary
                                newCasesDictionary.Add(datetime.ToString("ddd"), int.Parse(data.new_cases, System.Globalization.NumberStyles.AllowThousands));
                                recaveredCasesDictionaryt.Add(datetime.ToString("ddd"), int.Parse(data.total_recovered, System.Globalization.NumberStyles.AllowThousands));
                                if (data.total_death != null)
                                {
                                    deathCasesDictionary.Add(datetime.ToString("ddd"), int.Parse(data.total_death, System.Globalization.NumberStyles.AllowThousands));

                                }
                                else
                                {
                                    lblworlddeah.Text = "--";
                                }
                                criticalCasesDictionary.Add(datetime.ToString("ddd"), int.Parse(data.serious_critical, System.Globalization.NumberStyles.AllowThousands));

                                break;
                            }
                            #region datagrid_change in zero
                            if (data.new_cases == "")
                            {
                                data.new_cases = "0";
                            }
                            if (data.new_deaths == "")
                            {
                                data.new_deaths = "0";
                            }
                            if (data.serious_critical == "")
                            {
                                data.serious_critical = "0";
                            }
                            if (data.total_cases == "")
                            {
                                data.total_cases = "0";
                            }
                            if (data.total_death == "")
                            {
                                data.total_death = "0";
                            }
                            if (data.total_recovered == "")
                            {
                                data.total_recovered = "0";
                            }
                            if (data.active_cases == "")
                            {
                                data.active_cases = "0";
                            }
                            #endregion

                        }
                    }

                    //reverse data in Dictionary
                    var reveseedNewCases = newCasesDictionary.Reverse();
                    var reveseedRecoveredCases = recaveredCasesDictionaryt.Reverse();
                    var reveseedDeathCases = deathCasesDictionary.Reverse();
                    var reveseedCriticalCases = criticalCasesDictionary.Reverse();

                    //add  reversed data to bunifudataviz
                    foreach (var NewCases in reveseedNewCases)
                    {
                        newcasesdataPoint.addLabely(NewCases.Key, NewCases.Value);
                    }
                    foreach (var RecoveredCases in reveseedRecoveredCases)
                    {
                        recaveredcasesdataPoint.addLabely(RecoveredCases.Key, RecoveredCases.Value);
                    }
                    foreach (var Deathcases in reveseedDeathCases)
                    {
                        deathcasesdataPoint.addLabely(Deathcases.Key, Deathcases.Value);
                    }
                    foreach (var CriticalCases in reveseedCriticalCases)
                    {
                        criticalcasesdataPoint.addLabely(CriticalCases.Key, CriticalCases.Value);
                    }

                }
                else
                {
                    httpFeedback = "No Data";

                    this.Invoke(new Action(() =>
                    {
                        toast1.Visible = false;
                        btnretry.Visible = true;
                        lblproblemload.Visible = true;
                        lblmoredetails.Visible = true;
                        btncountry.Enabled = false;
                        backgroundWorker1.CancelAsync();
                    }));

                }

            }
            else
            {
                httpFeedback = response.StatusDescription;
                this.Invoke(new Action(() =>
                {
                    toast1.Visible = false;
                    btnretry.Visible = true;
                    lblproblemload.Visible = true;
                    lblmoredetails.Visible = true;
                    btncountry.Enabled = false;
                    backgroundWorker1.CancelAsync();
                }));
            }
        }
        private void btnvoice_Click(object sender, EventArgs e)
        {
            btnvoice.Visible = false;
            btnmute.Visible = true;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            if (music1 == 1)
            {
                player.Stream = Properties.Resources.Serhat_Durmus;
                player.PlayLooping();
            }
            else
            {
                player.Stream = Properties.Resources.Sura_İskenderli_Niye;
                player.PlayLooping();
            };

        }

        private void btnlang_Click(object sender, EventArgs e)
        {
            btnlang.BackColor = Color.FromArgb(45, 45, 48);
            btnrating.BackColor = Color.FromArgb(24, 26, 36);
            btnaudio.BackColor = Color.FromArgb(24, 26, 36);
            btncolor.BackColor = Color.FromArgb(24, 26, 36);
            pllang.BackColor = Color.FromArgb(24, 26, 36);
            plaudio.BackColor = Color.FromArgb(28, 28, 28);
            plcolor.BackColor = Color.FromArgb(28, 28, 28);
            pllang.Enabled = true;
            plcolor.Enabled = false;
            plaudio.Enabled = false;
            Timercolor.Enabled = false;
        }

        private void btnaudio_Click(object sender, EventArgs e)
        {
            btnaudio.BackColor = Color.FromArgb(45, 45, 48);
            btnrating.BackColor = Color.FromArgb(24, 26, 36);
            btncolor.BackColor = Color.FromArgb(24, 26, 36);
            btnlang.BackColor = Color.FromArgb(24, 26, 36);
            plaudio.BackColor = Color.FromArgb(24, 26, 36);
            plcolor.BackColor = Color.FromArgb(28, 28, 28);
            pllang.BackColor = Color.FromArgb(28, 28, 28);
            plcolor.Enabled = false;
            pllang.Enabled = false;
            plaudio.Enabled = true;
            Timercolor.Enabled = false;
        }

        private void btnrating_Click(object sender, EventArgs e)
        {
            Timersettingpage.Enabled = true;
            a = 0; b = 0; c = 0; d = 0;
        }
        byte a = 0, b = 0, c = 0, d = 0, music1 = 1, music2 = 0;


        private void plcolor_Click(object sender, EventArgs e)
        {
        }

        private void Timercolor_Tick(object sender, EventArgs e)
        {

            this.Invoke(new Action(() =>
            {
                bunifuLabel40.Text = trackred.Value.ToString();
                bunifuLabel41.Text = trackgreen.Value.ToString();
                bunifuLabel45.Text = trackblue.Value.ToString();
                if (comboBox1.Text != null && comboBox1.Text != "" && comboBox1.Text != " ")
                {
                    #region Color Changed
                    lblnullcombo.Visible = false;
                    if (comboBox1.Text == "Panel (Setting)")
                    {
                        plsetting1.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Title")
                    {
                        plseeting4.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Contact")
                    {
                        plcontact.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel covid19_info")
                    {
                        plinfo.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Health")
                    {
                        plhealth.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Options")
                    {
                        plsetting3.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Color")
                    {
                        plcolor.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Language")
                    {
                        pllang.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Audio")
                    {
                        plaudio.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel Rate it")
                    {
                        plsetting5.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel info")
                    {
                        plsetting2.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel menu")
                    {
                        plmenu.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel worldstat")
                    {
                        pldash1.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel  Statistical info1")
                    {
                        pldash3.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel  Statistical info2")
                    {
                        pldash2.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "Panel  Statistical info3")
                    {
                        pldash7.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "btn country")
                    {
                        btncountry.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    else if (comboBox1.Text == "btn refresh")
                    {
                        btnrefresh.BackColor = Color.FromArgb(trackred.Value, trackgreen.Value, trackblue.Value);
                    }
                    #endregion
                }
                else
                {
                    lblnullcombo.Visible = true;
                }

            }));
        }

        private void btnmute_Click(object sender, EventArgs e)
        {
            Mute();
            btnvoice.Visible = true;
            btnmute.Visible = false;

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            VolUp();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            VolDown();
        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.Stop();
            btnpause.Visible = false;
            btnplay.Visible = true;
            playmusic = false;
            Music.Enabled = false;
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            playmusic = false;
            Music.Enabled = true;
            
            btnplay.Visible = false;
            btnpause.Visible = true;
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            panel2.Location = new Point(7, btnhypertension.Location.Y);
            plstting1.Visible = false; plsetting3.Visible = false; plseeting4.Visible = false; plsetting2.Visible = false;
             pldash5.Visible = false; pldash7.Visible = false; dgvmain.Visible = false; btncountry.Visible = false;
            pldash2.Location = new Point(1999, 999);
            pldash3.Location = new Point(1998, 998);
            pldash1.Location = new Point(1899, 989);
            pldash4.Location = new Point(2000, 1500);
            pldash6.Location = new Point(2000, 1500);
            plinfo.Visible = true;
            lblcovid19.Text = "Coronavirus Disease";
            Timercolor.Enabled = false;
            Timersettingpage.Enabled = false;

           
        }
        private void btnprevious_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            if (toast1.Visible == false && countryName != null)
            {
                if (music2 == 1)
                {
                    playmusic = true;
                    music2 = 0;
                    music1 = 1;
                    player.Stream = Properties.Resources.Serhat_Durmus;
                    player.PlayLooping();
                }
                else if (music1 == 1)
                {
                    playmusic = true;
                    music2 = 1;
                    music1 = 0;
                    player.Stream = Properties.Resources.Sura_İskenderli_Niye;
                    player.PlayLooping();
                }
            }
            else
            {
                playmusic = false;
                player.Stop();
            }
        }
        bool playmusic = false;
        private void Music_Tick(object sender, EventArgs e)
        {
            if (toast1.Visible == false && countryName != null)
            {

                if (playmusic == false)
                {
                    btnmute.Visible = true;
                    if (music1 == 1)
                    {
                        System.Media.SoundPlayer player = new SoundPlayer();
                        music1 = 1;
                        music2 = 0;
                        player.Stream = Properties.Resources.Serhat_Durmus;
                        player.PlayLooping();
                        playmusic = true;
                    }
                    else if (music2 == 1)
                    {
                        System.Media.SoundPlayer player = new SoundPlayer();
                        playmusic = true;
                        music2 = 1;
                        music1 = 0;
                        player.Stream = Properties.Resources.Sura_İskenderli_Niye;
                        player.PlayLooping();
                    }
                }
            }
            else
            {
                playmusic = false;
                System.Media.SoundPlayer player = new SoundPlayer();
                player.Stop();

            }
        }

        private void bunifuRating1_onValueChanged(object sender, EventArgs e)
        {
            btnlang.BackColor = Color.FromArgb(45, 45, 48);
            btnrating.BackColor = Color.FromArgb(24, 26, 36);
            btnaudio.BackColor = Color.FromArgb(24, 26, 36);
            btncolor.BackColor = Color.FromArgb(24, 26, 36);
            pllang.BackColor = Color.FromArgb(24, 26, 36);
            plaudio.BackColor = Color.FromArgb(28, 28, 28);
            plcolor.BackColor = Color.FromArgb(28, 28, 28);
            pllang.Enabled = true;
            plcolor.Enabled = false;
            plaudio.Enabled = false;
            Timercolor.Enabled = false;
        }

        private void bunifuLabel22_Click(object sender, EventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {


            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            if (toast1.Visible == false && countryName != null)
            {
                if (music2 == 1)
                {
                    playmusic = true;
                    music2 = 0;
                    music1 = 1;
                    player.Stream = Properties.Resources.Serhat_Durmus;
                    player.PlayLooping();
                }
                else if (music1 == 1)
                {
                    playmusic = true;
                    music2 = 1;
                    music1 = 0;
                    player.Stream = Properties.Resources.Sura_İskenderli_Niye;
                    player.PlayLooping();
                }
            }
            else
            {
                playmusic = false;
                player.Stop();
            }

        }

        private void plcolor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblmind_Click(object sender, EventArgs e)
        {
            a = 0; b = 0; c = 0; d = 0;
            bunifuRating1.Visible = true;
            lblthanksrate.Visible = false;
            bunifuRating1.Value = 0;
            Timersettingpage.Enabled = true;
            lblmind.Visible = false;

            btnlang.BackColor = Color.FromArgb(45, 45, 48);
            btnrating.BackColor = Color.FromArgb(24, 26, 36);
            btnaudio.BackColor = Color.FromArgb(24, 26, 36);
            btncolor.BackColor = Color.FromArgb(24, 26, 36);
            pllang.BackColor = Color.FromArgb(24, 26, 36);
            plaudio.BackColor = Color.FromArgb(28, 28, 28);
            plcolor.BackColor = Color.FromArgb(28, 28, 28);
            pllang.Enabled = true;
            plcolor.Enabled = false;
            plaudio.Enabled = false;
            Timercolor.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
                lblDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                //Timercolor.Enabled = false;
                picrating1.Visible = true;
                picrating2.Visible = true;
                a++;
                if (a == 2 && c <= 5)
                {
                    picrating1.Visible = false;
                    picrating2.Visible = false;
                    a = 0;
                    c++;

                }
                if (bunifuRating1.Value > 0)
                {
                    bunifuRating1.Visible = false;
                    lblthanksrate.Visible = true;
                    b++;
                    if (b == 2 && d <= 2)
                    {
                        lblthanksrate.Visible = false;
                        b = 0;
                        d++;
                    }
                    lblmind.Visible = true;
                }
            }));
        }

        private void GetWorldStat()
        {
            var client = new RestClient("https://coronavirus-monitor.p.rapidapi.com/coronavirus/worldstat.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "coronavirus-monitor.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "9c11d404f5msh334423c9c7ef75fp1e312cjsn4325ef1041dd");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content;
                worldStat = JsonConvert.DeserializeObject<clsWorldStat>(content);
            }
            else
            {
                httpFeedback = response.ErrorMessage;
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
