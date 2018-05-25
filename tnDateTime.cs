using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;

namespace TamilNadu
{
    public class tnDateTime
    {
        private int _Year;
        private int _Month;
        private int _Day;
        private Eras tamilNaatkattikal;

        private static tnDateTime objtnDateTime = null;

        public Eras TamilNaatkattikal
        {
            get { return tamilNaatkattikal; }
            set { tamilNaatkattikal = value; }
        }

        public string getTamilSiruPoluthukalToString(DateTime dateTime, bool inTamilLetters)
        {
            TamilSiruPoluthu objTamilSiruPoluthu = getTamilSiruPoluthukal(dateTime);
            if (inTamilLetters == true)
            {
                return objTamilSiruPoluthu.SiruPoluthuName + ", " + ConvertToTamilNumerals(dateTime.ToLongTimeString());                
            }
            else
            {
                return objTamilSiruPoluthu.SiruPoluthuName + ", " + DateTime.Now.ToLongTimeString();
            }
        }

        static StringBuilder objStringBuilder = new StringBuilder();
        private static string ConvertToTamilNumerals(string givenEngNum)
        {
            objStringBuilder = new StringBuilder();
            objStringBuilder.Append( givenEngNum
                .Replace("1", "௧")
                .Replace("2", "௨")
                .Replace("3", "௩")
                .Replace("4", "௪")
                .Replace("5", "௫")
                .Replace("6", "௬")
                .Replace("7", "௭")
                .Replace("8", "௮")
                .Replace("9", "௯")
                .Replace("PM","")
                .Replace("AM",""));


            return objStringBuilder.ToString();
        }

        public string getTamilSiruPoluthukalToString(DateTime dateTime)
        {
           TamilSiruPoluthu objTamilSiruPoluthu = getTamilSiruPoluthukal(dateTime);

           return objTamilSiruPoluthu.SiruPoluthuName +", "+ DateTime.Now.ToLongTimeString();
        }

        public TamilSiruPoluthu getTamilSiruPoluthukal(DateTime dateTime)
        {
            List<TamilSiruPoluthu> tamilSiruPoluthukal = getTamilSiruPoluthukal();


            TamilSiruPoluthu objTamilSiruPoluthu = tamilSiruPoluthukal
                .Where(w => DateTime.Now.Hour >= w.SiruPoluthuMinTime
                    && DateTime.Now.Hour < w.SiruPoluthuMaxTime)
                .FirstOrDefault();

            //foreach (TamilSiruPoluthu tsp in tamilSiruPoluthukal)
            //{ 

            //    if(tsp.SiruPoluthuMinTime >= DateTime.Now.Hour)

            //}


            return objTamilSiruPoluthu;
        }
        //public tnDateTime getCurrentTamilDate()
        //{

        //}
        private tnDateTime()
        {
            setYearInfos();
            _MinYear = _YearInfos.Min(m => m.YearNumber);
            _MaxYear = _YearInfos.Max(m => m.YearNumber);
        }
        public static tnDateTime CreateObject()
        {
            if (objtnDateTime == null)
            {
                objtnDateTime = new tnDateTime();
            }
            return objtnDateTime;
        }

   
        public List<TamilSiruPoluthu> getTamilSiruPoluthukal()
        {
            List<TamilSiruPoluthu> tamilSiruPoluthukal = new List<TamilSiruPoluthu>();


            tamilSiruPoluthukal.Add(new TamilSiruPoluthu
            {
                SiruPoluthuMinTime = 2,
                SiruPoluthuMaxTime = 6,
                SiruPoluthuName = "வைகறை"
            });
            tamilSiruPoluthukal.Add(new TamilSiruPoluthu
            {
                SiruPoluthuMinTime = 6,
                SiruPoluthuMaxTime = 10,
                SiruPoluthuName = "காலை"
            });
            tamilSiruPoluthukal.Add(new TamilSiruPoluthu
            {
                SiruPoluthuMinTime = 10,
                SiruPoluthuMaxTime = 14,
                SiruPoluthuName = "நண்பகல்"
            });
            tamilSiruPoluthukal.Add(new TamilSiruPoluthu
            {
                SiruPoluthuMinTime = 14,
                SiruPoluthuMaxTime = 18,
                SiruPoluthuName = "எற்பாடு"
            });
            tamilSiruPoluthukal.Add(new TamilSiruPoluthu
            {
                SiruPoluthuMinTime = 18,
                SiruPoluthuMaxTime = 22,
                SiruPoluthuName = "மாலை"
            });
            tamilSiruPoluthukal.Add(new TamilSiruPoluthu
            {
                SiruPoluthuMinTime = 22,
                SiruPoluthuMaxTime = 24,
                SiruPoluthuName = "யாமம்"
            });
            tamilSiruPoluthukal.Add(new TamilSiruPoluthu
            {
                SiruPoluthuMinTime = 0,
                SiruPoluthuMaxTime = 2,
                SiruPoluthuName = "யாமம்"
            });

            return tamilSiruPoluthukal;
        }

        public List<TamilMonth> getTamilMonthsWithPeruPoluthu(Eras eraName)
        {
            List<TamilMonth> objMonthNames = new List<TamilMonth>();
            if (eraName == Eras.ChithiraiBased)
            {
                objMonthNames.Add(new TamilMonth() { MonthNo = 1, MonthName = "சித்திரை", PeruPoluthu = "இளவேனில்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 2, MonthName = "வைகாசி", PeruPoluthu = "இளவேனில்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 3, MonthName = "ஆனி", PeruPoluthu = "முதுவேனில்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 4, MonthName = "ஆடி", PeruPoluthu = "முதுவேனில்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 5, MonthName = "ஆவணி", PeruPoluthu = "கார்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 6, MonthName = "புரட்டாசி", PeruPoluthu = "கார்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 7, MonthName = "ஐப்பசி", PeruPoluthu = "கூதிர்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 8, MonthName = "கார்த்திகை", PeruPoluthu = "கூதிர்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 9, MonthName = "மார்கழி", PeruPoluthu = "முன்பனி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 10, MonthName = "தை", PeruPoluthu = "முன்பனி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 11, MonthName = "மாசி", PeruPoluthu = "பின்பனி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 12, MonthName = "பங்குனி", PeruPoluthu = "பின்பனி" });
            }
            else if (eraName == Eras.ThaiBased)
            {
                objMonthNames.Add(new TamilMonth { MonthNo = 10, MonthName = "தை" });
                objMonthNames.Add(new TamilMonth { MonthNo = 11, MonthName = "மாசி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 12, MonthName = "பங்குனி" });
                objMonthNames.Add(new TamilMonth() { MonthNo = 1, MonthName = "சித்திரை" });
                objMonthNames.Add(new TamilMonth { MonthNo = 2, MonthName = "வைகாசி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 3, MonthName = "ஆனி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 4, MonthName = "ஆடி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 5, MonthName = "ஆவணி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 6, MonthName = "புரட்டாசி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 7, MonthName = "ஐப்பசி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 8, MonthName = "கார்த்திகை" });
                objMonthNames.Add(new TamilMonth { MonthNo = 9, MonthName = "மார்கழி" });
            }
            else
            {
                objMonthNames.Add(new TamilMonth { MonthNo = 1, MonthName = "மேழம்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 2, MonthName = "விடை" });
                objMonthNames.Add(new TamilMonth { MonthNo = 3, MonthName = "இரட்டை" });
                objMonthNames.Add(new TamilMonth { MonthNo = 4, MonthName = "கடகம்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 5, MonthName = "மடங்கல்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 6, MonthName = "கன்னி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 7, MonthName = "துலை" });
                objMonthNames.Add(new TamilMonth { MonthNo = 8, MonthName = "நளி" });
                objMonthNames.Add(new TamilMonth { MonthNo = 9, MonthName = "சிலை" });
                objMonthNames.Add(new TamilMonth { MonthNo = 10, MonthName = "சுறவம்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 11, MonthName = "கும்பம்" });
                objMonthNames.Add(new TamilMonth { MonthNo = 12, MonthName = "மீனம்" });
            }

            return objMonthNames;
        }

        public List<TamilYear> getTamilYears(Eras era)
        {
            List<TamilYear> objTamilYearNames = new List<TamilYear>();
            if (era == Eras.ChithiraiBased)
            {
                objTamilYearNames.Add(new TamilYear(01, "பிரபவ", "நற்றோன்றல்"));
                objTamilYearNames.Add(new TamilYear(02, "விபவ", "உயர்தோன்றல்"));
                objTamilYearNames.Add(new TamilYear(03, "சுக்ல", "வெள்ளொளி"));
                objTamilYearNames.Add(new TamilYear(04, "பிரமோதூத", "பேருவகை"));
                objTamilYearNames.Add(new TamilYear(05, "பிரசோற்பத்தி", "மக்கட்செல்வம்"));
                objTamilYearNames.Add(new TamilYear(06, "ஆங்கீரச", "அயல்முனி"));
                objTamilYearNames.Add(new TamilYear(07, "ஸ்ரீமுக", "திருமுகம்"));
                objTamilYearNames.Add(new TamilYear(08, "பவ", "தோற்றம்"));
                objTamilYearNames.Add(new TamilYear(09, "யுவ", "இளமை"));
                objTamilYearNames.Add(new TamilYear(10, "தாது", "மாழை"));
                objTamilYearNames.Add(new TamilYear(11, "ஈஸ்வர", "ஈச்சுரம்"));
                objTamilYearNames.Add(new TamilYear(12, "வெகுதானிய", "கூலவளம்"));
                objTamilYearNames.Add(new TamilYear(13, "பிரமாதி", "முன்மை"));
                objTamilYearNames.Add(new TamilYear(14, "விக்கிரம", "நேர்நிரல்"));
                objTamilYearNames.Add(new TamilYear(15, "விஷு", "விளைபயன்"));
                objTamilYearNames.Add(new TamilYear(16, "சித்திரபானு", "ஓவியக்கதிர்"));
                objTamilYearNames.Add(new TamilYear(17, "சுபானு", "நற்கதிர்"));
                objTamilYearNames.Add(new TamilYear(18, "தாரண", "தாங்கெழில்"));
                objTamilYearNames.Add(new TamilYear(19, "பார்த்திப", "நிலவரையன்"));
                objTamilYearNames.Add(new TamilYear(20, "விய", "விரிமாண்பு"));
                objTamilYearNames.Add(new TamilYear(21, "சர்வசித்து", "முற்றறிவு யாவுந்திறல்"));
                objTamilYearNames.Add(new TamilYear(22, "சர்வதாரி", "முழுநிறைவு"));
                objTamilYearNames.Add(new TamilYear(23, "விரோதி", "தீர்பகை"));
                objTamilYearNames.Add(new TamilYear(24, "விக்ருதி", "வளமாற்றம்"));
                objTamilYearNames.Add(new TamilYear(25, "கர", "செய்நேர்த்தி"));
                objTamilYearNames.Add(new TamilYear(26, "நந்தன", "நற்குழவி"));
                objTamilYearNames.Add(new TamilYear(27, "விஜய", "உயர்வாகை"));
                objTamilYearNames.Add(new TamilYear(28, "ஜய", "வாகை"));
                objTamilYearNames.Add(new TamilYear(29, "மன்மத", "காதன்மை"));
                objTamilYearNames.Add(new TamilYear(30, "துன்முகி", "வெம்முகம்"));
                objTamilYearNames.Add(new TamilYear(31, "ஹேவிளம்பி", "பொற்றடை"));
                objTamilYearNames.Add(new TamilYear(32, "விளம்பி", "அட்டி"));
                objTamilYearNames.Add(new TamilYear(33, "விகாரி", "எழில்மாறல்"));
                objTamilYearNames.Add(new TamilYear(34, "சார்வரி", "வீறியெழல்"));
                objTamilYearNames.Add(new TamilYear(35, "பிலவ", "கீழறை"));
                objTamilYearNames.Add(new TamilYear(36, "சுபகிருது", "நற்செய்கை"));
                objTamilYearNames.Add(new TamilYear(37, "சோபகிருது", "மங்கலம்"));
                objTamilYearNames.Add(new TamilYear(38, "குரோதி", "பகைக்கேடு"));
                objTamilYearNames.Add(new TamilYear(39, "விசுவாசுவ", "உலகநிறைவு"));
                objTamilYearNames.Add(new TamilYear(40, "பரபாவ", "அருட்டோற்றம்"));
                objTamilYearNames.Add(new TamilYear(41, "பிலவங்க", "நச்சுப்புழை"));
                objTamilYearNames.Add(new TamilYear(42, "கீலக", "பிணைவிரகு"));
                objTamilYearNames.Add(new TamilYear(43, "சௌமிய", "அழகு"));
                objTamilYearNames.Add(new TamilYear(44, "சாதாரண", "பொதுநிலை"));
                objTamilYearNames.Add(new TamilYear(45, "விரோதகிருது", "இகல்வீறு"));
                objTamilYearNames.Add(new TamilYear(46, "பரிதாபி", "கழிவிரக்கம்"));
                objTamilYearNames.Add(new TamilYear(47, "பிரமாதீச", "நற்றலைமை"));
                objTamilYearNames.Add(new TamilYear(48, "ஆனந்த", "பெருமகிழ்ச்சி"));
                objTamilYearNames.Add(new TamilYear(49, "ராட்சச", "பெருமறம்"));
                objTamilYearNames.Add(new TamilYear(50, "நள", "தாமரை"));
                objTamilYearNames.Add(new TamilYear(51, "பிங்கள", "பொன்மை"));
                objTamilYearNames.Add(new TamilYear(52, "காளயுக்தி", "கருமைவீச்சு"));
                objTamilYearNames.Add(new TamilYear(53, "சித்தார்த்தி", "முன்னியமுடிதல்"));
                objTamilYearNames.Add(new TamilYear(54, "ரௌத்திரி", "அழலி"));
                objTamilYearNames.Add(new TamilYear(55, "துன்மதி", "கொடுமதி"));
                objTamilYearNames.Add(new TamilYear(56, "துந்துபி", "பேரிகை"));
                objTamilYearNames.Add(new TamilYear(57, "ருத்ரோத்காரி", "ஒடுங்கி"));
                objTamilYearNames.Add(new TamilYear(58, "ரக்தாட்சி", "செம்மை"));
                objTamilYearNames.Add(new TamilYear(59, "குரோதன", "எதிரேற்றம்"));
                objTamilYearNames.Add(new TamilYear(60, "அட்சய", "வளங்கலன்"));
            }
            else
            {

            }
            return objTamilYearNames;
        }


        private List<YearInfo> _YearInfos;

        public List<YearInfo> YearInfos
        {
            get { return _YearInfos; }
            set { _YearInfos = value; }
        }

        public int getMonthDaysCount(int eng_year, int tamilMonthCount)
        {
            YearInfo objYearInfo = _YearInfos.Where(w => w.YearNumber == eng_year)
                .FirstOrDefault();

            return objYearInfo.MonthDaysCount[tamilMonthCount];
        }

        public DayOfWeek getMonthFirstDay(int eng_year, int tamilMonthCount)
        {
            tamilMonthCount = tamilMonthCount - 1;
                 
            YearInfo objYearInfo = _YearInfos
                .Where(w => w.YearNumber == eng_year)
                .FirstOrDefault();

            DateTime objDateTime = new DateTime(eng_year,
                4,
                objYearInfo.ChithiraiStartAprlDay);

            int TotalDays = 0;

            for (int i = 0; i < tamilMonthCount; i++)
            {
                TotalDays += objYearInfo.MonthDaysCount[i];
            }

            objDateTime = objDateTime.AddDays(TotalDays);

            //if (objDateTime.DayOfWeek == DayOfWeek.)

            return objDateTime.DayOfWeek;
        }

        public void setYearInfos()
        {
            _YearInfos = new List<YearInfo>();
            //_YearInfos.Add(new YearInfo
            //{
            //    YearNumber = 2018,
            //    ChithiraiStartAprlDay = 14,
            //    MonthDaysCount = new int[] { 31, 31, 32, 31, 31, 31, 30, 29, 29, 30, 30, 30 }
            //});
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\YearInfo.txt";
            foreach (string line in File.ReadAllLines(filePath))
            {
                YearInfo objYearInfo = new YearInfo();
                string[] splitedContent = line.Split(',');
                for (int i = 0; i < 14; i++)
                {
                    if (i == 0)
                    {
                        objYearInfo.YearNumber = Convert.ToInt32(splitedContent[i]);
                    }
                    else if (i == 1)
                    {
                        objYearInfo.ChithiraiStartAprlDay = Convert.ToInt32(splitedContent[i]);
                    }
                    else
                    {
                        objYearInfo.MonthDaysCount[i - 2] = Convert.ToInt32(splitedContent[i]);
                    }
                }
                _YearInfos.Add(objYearInfo);
            }

            //At last line set the MinYear and MaxYear
            
        }

        private int _MinYear;

        public int MinYear
        {
            get { return _MinYear; }
            set { _MinYear = value; }
        }
        private int _MaxYear;

        public int MaxYear
        {
            get { return _MaxYear; }
            set { _MaxYear = value; }
        }

        public TamilDate getTamilDate(DateTime dateTime, Eras ers)
        {
            TamilDate objTodayTamilDate = new TamilDate();
            YearInfo objYearInfo = _YearInfos
                .Where(w => w.YearNumber == dateTime.Year)
                .FirstOrDefault();

            //Set April Month start date
            DateTime aprDateTime = new DateTime(dateTime.Year,
                4, objYearInfo.ChithiraiStartAprlDay);
            DateTime objTodayDateOnly = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            double TotalDaysFromAprilStart = (objTodayDateOnly - aprDateTime).TotalDays;

            
            int tamilMonthDaysCounter = 0,
                tamilMonthDaysAntiCounter = 0;
            int tamilMonthCounter = 0;
           //objTodayTamilDate.MonthNo = getChithiraiAprilStartDate(dateTime);
            for (int i = 0; i < objYearInfo.MonthDaysCount.Length; i++)
            {
                if (tamilMonthDaysCounter < TotalDaysFromAprilStart)
                {
                    tamilMonthDaysCounter += getMonthDaysCount(dateTime.Year, i);
                    tamilMonthCounter++;
                    if (tamilMonthDaysCounter < TotalDaysFromAprilStart)
                    {
                        tamilMonthDaysAntiCounter = Convert.ToInt16(Math.Floor(TotalDaysFromAprilStart)) - tamilMonthDaysCounter;
                        tamilMonthDaysAntiCounter++;
                    }
                }
            }

            objTodayTamilDate.tamilMonth = getTamilMonthsWithPeruPoluthu(ers)
                .Where(w => w.MonthNo == tamilMonthCounter)
                .FirstOrDefault();
            objTodayTamilDate.DayNo = tamilMonthDaysAntiCounter;

            objTodayTamilDate.tamilYear = getTamilYears(ers)
                .Where(w => w.yearCount == (dateTime.Year - 1986))
                .FirstOrDefault();

            //return ", ௨௫, ௨0௧௮";
            return objTodayTamilDate;
        }

        private int getChithiraiAprilStartDate(DateTime dateTime)
        {
            return 12;
        }
    }

    public class TamilYear
    {
        public int yearCount { get; set; }
        public string yearName { get; set; }
        public string yearNameInTamil { get; set; }
        public TamilYear(int _yearCount,
            string _yearName,
            string _yearNameInTamil)
        {
            yearCount = _yearCount;
            yearName = _yearName;
            yearNameInTamil = _yearNameInTamil;
        }
    }
    public class TamilDate
    {
        public int DayNo { get; set; }
        public TamilMonth tamilMonth { get; set; }
        public TamilYear tamilYear { get; set; }
        
        public override string ToString()
        {
            return tamilYear.yearName.ToString() 
                +"/"
                + tamilMonth.MonthName.ToString()
                + "/"
                + DayNo;
        }
    }
    public enum Eras
    {
        ChithiraiBased,
        ThaiBased
    }
    public class TamilMonth
    {
        public int MonthNo { get; set; }
        public string MonthName { get; set; }
        public string PeruPoluthu { get; set; }
    }

    public class TamilSiruPoluthu
    {
        public int SiruPoluthuMinTime { get; set; }
        public int SiruPoluthuMaxTime { get; set; }
        public string SiruPoluthuName { get; set; }
    }
    public class TamilPeruPoluthu
    {
        public int PeruPoluthuMinMonth { get; set; }
        public int PeruPoluthuMaxMonth { get; set; }
        public string PeruPoluthuName { get; set; }
    }

    public class YearInfo
    {
        public YearInfo()
        {
            MonthDaysCount = new int[12];
        }
        public int YearNumber { get; set; }
        public int[] MonthDaysCount { get; set; }
        public int ChithiraiStartAprlDay { get; set; }
        //public int ChithiraiCount { get; set; }
        //public int VaikasiCount { get; set; }
        //public int AaniCount { get; set; }
        //public int AadiCount { get; set; }
        //public int AavaniCount { get; set; }
        //public int PurataasiCount { get; set; }
        //public int AipasiCount { get; set; }
        //public int KarthikaiCount { get; set; }
        //public int MarkazhiCount { get; set; }
        //public int ThaiCount { get; set; }
        //public int MaasiCount { get; set; }
        //public int PanguniCount { get; set; }

    }
}
