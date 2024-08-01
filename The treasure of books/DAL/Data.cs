namespace The_treasure_of_books.DAL
{
    public class Data
    {
        //מחרוזת חיבור לשמירת נתונים
        string ConnctionString = "server=REDNER\\SQLEXPRESS ;" +
            " initial catalog=The treasure of wisdom ; " +
            "user id=sa ;" +
            " password=1234 ;" +
            " TrustServerCertificate=yes ";

        //קונסטרקטור פרטי למניעת יצירת מופעים מחוץ למחלקה
        private Data()
        {
            //יצירת מופע של שכבת הנתונים עם מחרוזת חיבור
            Layer = new DataLayer(ConnctionString);
        }




        //משתנה סטטי לשמירת מופע יחיד של המחלקה
        static Data GetData;

        //מאפיין סטטי לקבלת שכבת הנתונים
        public static DataLayer Get
        {
            get
            {
                //יצירת מופע חדש של המחלקה אם לא קיים
                if (GetData == null)

                {
                    GetData = new Data();

                }
                //החזרת שכבת הנתונים
                return GetData.Layer;
            }
        }
        //מאפיין לשמירת שכבת הנתונים
        public DataLayer Layer { get; set; }


    }   }
