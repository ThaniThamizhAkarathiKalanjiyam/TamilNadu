using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamilNadu
{
    public class tnDateTime
    {

        public List<string> getTamilMonths()
        {
            List<string> objMonthNames = new List<string>();
            objMonthNames.Add("சித்திரை");
            objMonthNames.Add("வைகாசி");
            objMonthNames.Add("ஆனி");
            objMonthNames.Add("ஆடி");
            objMonthNames.Add("ஆவணி");
            objMonthNames.Add("புரட்டாசி");
            objMonthNames.Add("ஐப்பசி");
            objMonthNames.Add("கார்த்திகை");
            objMonthNames.Add("மார்கழி");
            objMonthNames.Add("தை");
            objMonthNames.Add("மாசி");
            objMonthNames.Add("பங்குனி");

            return objMonthNames;
        }

        public List<TamilYear> getTamilYears()
        {
            List<TamilYear> objTamilYearNames = new List<TamilYear>();
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

            return objTamilYearNames;
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
}
